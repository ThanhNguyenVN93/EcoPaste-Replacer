using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Microsoft.Win32;

namespace frm_ecopaste.Helpers
{
    /// <summary>
    /// Pipeline steps 3-6: check/install EcoPaste, overwrite settings.json, launch and enable auto-start.
    /// </summary>
    internal static class EcoPasteInstaller
    {
        private const string GithubLatestReleaseApiUrl = "https://api.github.com/repos/EcoPasteHub/EcoPaste/releases/latest";
        private const string LocalAppDataFolderName = "com.ayangweb.eco-paste";
        private const string EmbeddedSettingsResourceName = "frm_ecopaste.Resources.settings.json";
        private const string AutoStartValueName = "EcoPaste";
        private const string WingetPackageId = "EcoPasteHub.EcoPaste";

        /// <summary>
        /// Installed executable file name (e.g. C:\Program Files\EcoPaste\EcoPaste.exe) — PascalCase,
        /// NO hyphen, unlike the local app data folder name "com.ayangweb.eco-paste".
        /// </summary>
        private static readonly string[] ExeFileNameCandidates = { "EcoPaste.exe", "eco-paste.exe" };

        /// <summary>
        /// Scans %LOCALAPPDATA%\com.ayangweb.eco-paste\*\config\settings.json.
        /// The version is not hardcoded because the subfolder name varies per install (e.g. "prod").
        /// </summary>
        public static string FindSettingsJsonPath()
        {
            string baseDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                LocalAppDataFolderName);

            if (!Directory.Exists(baseDir))
            {
                return null;
            }

            foreach (string subDir in Directory.GetDirectories(baseDir))
            {
                string candidate = Path.Combine(subDir, "config", "settings.json");
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }

            return null;
        }

        public static string WaitForSettingsJsonPath(TimeSpan timeout)
        {
            DateTime deadline = DateTime.UtcNow + timeout;
            string path;

            while ((path = FindSettingsJsonPath()) == null && DateTime.UtcNow < deadline)
            {
                Thread.Sleep(1000);
            }

            return path;
        }

        public static async Task<string> DownloadLatestInstallerAsync(Action<string> log)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("frm_ecopaste-installer");

                log("Querying GitHub Releases API...");
                string json = await client.GetStringAsync(GithubLatestReleaseApiUrl);

                var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
                var release = serializer.Deserialize<Dictionary<string, object>>(json);

                string tagName = release.ContainsKey("tag_name") ? (string)release["tag_name"] : "unknown";
                log($"Latest version: {tagName}");

                string downloadUrl = null;
                foreach (object assetObj in (IEnumerable)release["assets"])
                {
                    var asset = (Dictionary<string, object>)assetObj;
                    string name = (string)asset["name"];
                    if (name.EndsWith("_x64-setup.exe", StringComparison.OrdinalIgnoreCase))
                    {
                        downloadUrl = (string)asset["browser_download_url"];
                        break;
                    }
                }

                if (downloadUrl == null)
                {
                    throw new InvalidOperationException("Could not find an x64-setup.exe asset in the latest release.");
                }

                string destPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(downloadUrl));
                log("Downloading: " + Path.GetFileName(downloadUrl));

                byte[] data = await client.GetByteArrayAsync(downloadUrl);
                File.WriteAllBytes(destPath, data);

                return destPath;
            }
        }

        /// <summary>
        /// TODO (see CLAUDE.md): the real silent-install flag for the EcoPaste installer is not
        /// confirmed yet; assuming NSIS-style /S based on the "*_x64-setup.exe" asset name.
        /// Only used when winget is not available on the machine (see InstallViaWinget).
        /// </summary>
        public static void RunInstallerSilently(string installerPath)
        {
            var psi = new ProcessStartInfo(installerPath, "/S")
            {
                UseShellExecute = true,
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit(120000);
            }
        }

        public static bool IsWingetAvailable()
        {
            try
            {
                var psi = new ProcessStartInfo("winget", "--version")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit(10000);
                    return process.ExitCode == 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Installs EcoPaste via winget (verifies hash and is always silent), preferred over
        /// downloading directly from GitHub.
        /// </summary>
        public static bool InstallViaWinget(Action<string> log)
        {
            var psi = new ProcessStartInfo(
                "winget",
                $"install --id {WingetPackageId} -e --silent --accept-package-agreements --accept-source-agreements")
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };

            using (Process process = Process.Start(psi))
            {
                process.OutputDataReceived += (s, e) => { if (!string.IsNullOrEmpty(e.Data)) log(e.Data); };
                process.ErrorDataReceived += (s, e) => { if (!string.IsNullOrEmpty(e.Data)) log(e.Data); };
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit(180000);
                return process.ExitCode == 0;
            }
        }

        /// <summary>
        /// Looks up the install path via the registry Uninstall key first (more reliable, especially
        /// when installed via winget); falls back to guessing a few common paths if not found.
        /// </summary>
        public static string FindEcoPasteExePath()
        {
            string fromRegistry = FindExePathFromUninstallRegistry();
            if (fromRegistry != null)
            {
                return fromRegistry;
            }

            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

            string[] installDirs =
            {
                Path.Combine(programFiles, "EcoPaste"),
                Path.Combine(programFilesX86, "EcoPaste"),
                Path.Combine(localAppData, "Programs", "EcoPaste"),
                Path.Combine(localAppData, "EcoPaste"),
            };

            return installDirs
                .SelectMany(dir => ExeFileNameCandidates.Select(exeName => Path.Combine(dir, exeName)))
                .FirstOrDefault(File.Exists);
        }

        private static string FindExePathFromUninstallRegistry()
        {
            RegistryKey[] roots = { Registry.LocalMachine, Registry.CurrentUser };
            string[] uninstallSubKeyPaths =
            {
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
                @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall",
            };

            foreach (RegistryKey root in roots)
            {
                foreach (string uninstallSubKeyPath in uninstallSubKeyPaths)
                {
                    using (RegistryKey uninstallKey = root.OpenSubKey(uninstallSubKeyPath))
                    {
                        if (uninstallKey == null)
                        {
                            continue;
                        }

                        foreach (string subKeyName in uninstallKey.GetSubKeyNames())
                        {
                            using (RegistryKey appKey = uninstallKey.OpenSubKey(subKeyName))
                            {
                                string displayName = appKey?.GetValue("DisplayName") as string;
                                if (displayName == null ||
                                    displayName.IndexOf("EcoPaste", StringComparison.OrdinalIgnoreCase) < 0)
                                {
                                    continue;
                                }

                                // Uninstall entries can have malformed/unexpected InstallLocation or
                                // DisplayIcon values (stray quotes, icon-index suffixes, etc.) that make
                                // Path.Combine/File.Exists throw. Skip a bad entry instead of crashing
                                // the whole pipeline — the guessed-path fallback still covers the real install.
                                try
                                {
                                    string installLocation = appKey.GetValue("InstallLocation") as string;
                                    if (!string.IsNullOrEmpty(installLocation))
                                    {
                                        string exeCandidate = ExeFileNameCandidates
                                            .Select(exeName => Path.Combine(installLocation, exeName))
                                            .FirstOrDefault(File.Exists);
                                        if (exeCandidate != null)
                                        {
                                            return exeCandidate;
                                        }
                                    }

                                    string displayIcon = appKey.GetValue("DisplayIcon") as string;
                                    if (!string.IsNullOrEmpty(displayIcon))
                                    {
                                        string exePath = displayIcon.Split(',')[0].Trim('"');
                                        if (File.Exists(exePath))
                                        {
                                            return exePath;
                                        }
                                    }
                                }
                                catch (ArgumentException)
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Overwrites settings.json with the embedded resource. Falls back to takeown/icacls if the
        /// file is permission-locked. Call this AFTER killing the eco-paste.exe process, otherwise the
        /// app will flush its old config back over ours on exit.
        /// </summary>
        public static void OverwriteSettingsJson(string settingsPath)
        {
            try
            {
                CopyEmbeddedSettingsTo(settingsPath);
            }
            catch (UnauthorizedAccessException)
            {
                RunHidden("takeown.exe", $"/f \"{settingsPath}\"");
                RunHidden("icacls.exe", $"\"{settingsPath}\" /grant *S-1-5-32-544:F");
                CopyEmbeddedSettingsTo(settingsPath);
            }
        }

        private static void CopyEmbeddedSettingsTo(string destinationPath)
        {
            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(EmbeddedSettingsResourceName))
            {
                if (resourceStream == null)
                {
                    throw new InvalidOperationException("Embedded resource not found: " + EmbeddedSettingsResourceName);
                }

                using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                {
                    resourceStream.CopyTo(fileStream);
                }
            }
        }

        private static void RunHidden(string fileName, string arguments)
        {
            var psi = new ProcessStartInfo(fileName, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit(30000);
            }
        }

        public static void Launch(string exePath)
        {
            Process.Start(new ProcessStartInfo(exePath) { UseShellExecute = true });
        }

        public static void SetAutoStart(string exePath)
        {
            RegistryHelper.SetAutoStart(AutoStartValueName, exePath);
        }
    }
}
