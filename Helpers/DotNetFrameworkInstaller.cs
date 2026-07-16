using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace frm_ecopaste.Helpers
{
    /// <summary>
    /// Silently installs .NET Framework 4.7.2 when it's missing, using Microsoft's official
    /// web installer fwlink (as published on the .NET Framework 4.7.2 download page).
    /// </summary>
    internal static class DotNetFrameworkInstaller
    {
        private const string WebInstallerUrl = "https://go.microsoft.com/fwlink/?LinkId=863262";

        public static async Task<bool> InstallAsync(Action<string> log)
        {
            log("Downloading .NET Framework 4.7.2...");
            string installerPath = await DownloadAsync();

            log("Installing .NET Framework 4.7.2 (this can take a few minutes)...");
            return RunSilently(installerPath);
        }

        private static async Task<string> DownloadAsync()
        {
            string destPath = Path.Combine(Path.GetTempPath(), "ndp472-web.exe");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("frm_ecopaste-installer");
                byte[] data = await client.GetByteArrayAsync(WebInstallerUrl);
                File.WriteAllBytes(destPath, data);
            }

            return destPath;
        }

        private static bool RunSilently(string installerPath)
        {
            var psi = new ProcessStartInfo(installerPath, "/q /norestart")
            {
                UseShellExecute = true,
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit(30 * 60 * 1000);

                // 0 = success, 3010/1641 = success, reboot required.
                return process.ExitCode == 0 || process.ExitCode == 3010 || process.ExitCode == 1641;
            }
        }
    }
}
