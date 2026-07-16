using System;
using System.Diagnostics;
using System.Windows.Forms;
using frm_ecopaste.Helpers;

namespace frm_ecopaste
{
    internal static class Program
    {
        private const string DotNetFrameworkDownloadPageUrl = "https://dotnet.microsoft.com/download/dotnet-framework/net472";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!RuntimeCheck.IsSupportedFrameworkInstalled() && !EnsureFrameworkInstalled())
            {
                return;
            }

            Application.Run(new MainForm());
        }

        /// <summary>
        /// Offers to silently install .NET Framework 4.7.2 when it's missing. Returns true only
        /// if the framework ends up installed and ready to use in this same process run.
        /// </summary>
        private static bool EnsureFrameworkInstalled()
        {
            DialogResult confirm = MessageBox.Show(
                "EcoPaste Replacer requires .NET Framework 4.7.2 or later, which isn't installed on this PC." +
                "\n\nInstall it now? This needs an internet connection and may take a few minutes.",
                "EcoPaste Replacer",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
            {
                return false;
            }

            bool installed;
            using (var setupForm = new FrameworkSetupForm())
            {
                installed = setupForm.ShowDialog() == DialogResult.OK && setupForm.Success;
            }

            if (!installed)
            {
                DialogResult openPage = MessageBox.Show(
                    "Automatic install didn't complete. Open the download page instead?",
                    "EcoPaste Replacer",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (openPage == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo(DotNetFrameworkDownloadPageUrl) { UseShellExecute = true });
                }

                return false;
            }

            MessageBox.Show(
                ".NET Framework 4.7.2 was installed. EcoPaste Replacer will now restart.",
                "EcoPaste Replacer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Process.Start(new ProcessStartInfo(Application.ExecutablePath) { UseShellExecute = true });
            return false;
        }
    }
}
