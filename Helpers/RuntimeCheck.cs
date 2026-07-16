using Microsoft.Win32;

namespace frm_ecopaste.Helpers
{
    /// <summary>
    /// Preflight guard: the app is built for .NET Framework 4.7.2, which ships in-box with
    /// Windows 10 1809+, but older or stripped-down Windows installs may not have it.
    /// </summary>
    internal static class RuntimeCheck
    {
        // Release value for .NET Framework 4.7.2, see:
        // https://learn.microsoft.com/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed
        private const int MinimumRelease = 461808;

        public static bool IsSupportedFrameworkInstalled()
        {
            using (RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full"))
            {
                object release = ndpKey?.GetValue("Release");
                return release is int releaseValue && releaseValue >= MinimumRelease;
            }
        }
    }
}
