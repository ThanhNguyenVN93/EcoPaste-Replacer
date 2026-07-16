using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using frm_ecopaste.Helpers;

namespace frm_ecopaste
{
    public partial class MainForm : Form
    {
        private const string FeedbackFormUrl = "https://forms.gle/HJYPERBgk8Uyya1RA";

        private enum StepState
        {
            Pending,
            Active,
            Done,
            Error,
        }

        private static readonly Color ColorPending = Color.FromArgb(90, 90, 100);
        private static readonly Color ColorActive = Color.White;
        private static readonly Color ColorDone = Color.FromArgb(120, 200, 150);
        private static readonly Color ColorError = Color.FromArgb(230, 90, 90);

        private Label[] _stepLabels;
        private bool _exitConfirmed;

        public MainForm()
        {
            InitializeComponent();
            _stepLabels = new[] { lblStep1, lblStep2, lblStep3, lblStep4, lblStep5, lblStep6 };
            trayIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void linkFeedback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(FeedbackFormUrl) { UseShellExecute = true });
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_exitConfirmed)
            {
                e.Cancel = true;
                ExitApplication();
                return;
            }

            base.OnFormClosing(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        /// <summary>
        /// Asks whether the user wants to support the developer before actually exiting.
        /// </summary>
        private void ExitApplication()
        {
            DialogResult result = MessageBox.Show(
                this,
                "Would you like to support the developer with a small donation before you go?",
                "Support the developer",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var donateForm = new DonateForm())
                {
                    donateForm.ShowDialog(this);
                }
            }

            _exitConfirmed = true;
            trayIcon.Visible = false;
            Close();
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.Enabled = false;
            btnRun.Text = "Running...";
            progressBar.Value = 0;

            foreach (Label label in _stepLabels)
            {
                label.Text = string.Empty;
            }

            try
            {
                await RunPipelineAsync();
                SetSubtitle("Done — Windows V has been replaced with EcoPaste.");
                btnRun.Text = "Run again";
            }
            catch (Exception ex)
            {
                SetSubtitle("Error: " + ex.Message);
                btnRun.Text = "Retry";
            }
            finally
            {
                btnRun.Enabled = true;
            }
        }

        /// <summary>
        /// The 6 steps that replace Windows Clipboard History with EcoPaste, see CLAUDE.md.
        /// </summary>
        public async Task RunPipelineAsync()
        {
            SetStep(1, "Lock Windows V (registry)", StepState.Active);
            RegistryHelper.DisableWindowsClipboardHistory();
            SetStep(1, "Windows V locked", StepState.Done);

            SetStep(2, "Restart explorer.exe", StepState.Active);
            ExplorerHelper.Restart();
            SetStep(2, "explorer.exe restarted", StepState.Done);

            SetStep(3, "Check whether EcoPaste is installed", StepState.Active);
            string settingsPath = EcoPasteInstaller.FindSettingsJsonPath();
            bool alreadyInstalled = settingsPath != null;
            SetStep(3, alreadyInstalled ? "EcoPaste is already installed" : "EcoPaste is not installed", StepState.Done);

            if (!alreadyInstalled)
            {
                SetStep(4, "Install EcoPaste", StepState.Active);
                bool installedViaWinget = false;

                if (EcoPasteInstaller.IsWingetAvailable())
                {
                    SetSubtitle("Installing via winget...");
                    installedViaWinget = EcoPasteInstaller.InstallViaWinget(msg => SetSubtitle(msg));
                }

                if (!installedViaWinget)
                {
                    SetSubtitle("winget unavailable or install failed, downloading directly from GitHub...");
                    string installerPath = await EcoPasteInstaller.DownloadLatestInstallerAsync(msg => SetSubtitle(msg));
                    SetSubtitle("Installing EcoPaste...");
                    EcoPasteInstaller.RunInstallerSilently(installerPath);
                }

                settingsPath = EcoPasteInstaller.WaitForSettingsJsonPath(TimeSpan.FromSeconds(60));
                if (settingsPath == null)
                {
                    SetStep(4, "settings.json not found after installation", StepState.Error);
                    throw new InvalidOperationException("settings.json not found after installing EcoPaste.");
                }

                SetStep(4, installedViaWinget ? "Installed via winget" : "Downloaded and installed via GitHub", StepState.Done);
            }
            else
            {
                SetStep(4, "Skipped (already installed)", StepState.Done);
            }

            SetStep(5, "Kill EcoPaste.exe before overwriting config", StepState.Active);
            ProcessHelper.KillByName("EcoPaste");
            ProcessHelper.KillByName("eco-paste");
            SetStep(5, "Confirmed EcoPaste.exe is not running", StepState.Done);

            SetStep(6, "Overwrite settings.json and launch", StepState.Active);
            EcoPasteInstaller.OverwriteSettingsJson(settingsPath);

            string exePath = EcoPasteInstaller.FindEcoPasteExePath();
            if (exePath != null)
            {
                EcoPasteInstaller.Launch(exePath);
                EcoPasteInstaller.SetAutoStart(exePath);
                SetStep(6, "Launched EcoPaste and enabled auto-start", StepState.Done);
            }
            else
            {
                SetStep(6, "EcoPaste.exe not found, please open EcoPaste manually", StepState.Error);
            }
        }

        private void SetStep(int number, string text, StepState state)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, string, StepState>(SetStep), number, text, state);
                return;
            }

            Label label = _stepLabels[number - 1];
            string prefix = state == StepState.Done ? "✓ " : state == StepState.Error ? "✗ " : "";
            label.Text = prefix + $"Step {number}/6: {text}";
            label.Font = new Font(label.Font, state == StepState.Active ? FontStyle.Bold : FontStyle.Regular);

            switch (state)
            {
                case StepState.Active:
                    label.ForeColor = ColorActive;
                    break;
                case StepState.Done:
                    label.ForeColor = ColorDone;
                    break;
                case StepState.Error:
                    label.ForeColor = ColorError;
                    break;
                default:
                    label.ForeColor = ColorPending;
                    break;
            }

            progressBar.Value = state == StepState.Active ? number - 1 : number;
            lblStepCount.Text = $"Step {Math.Min(number, 6)}/6";

            if (state == StepState.Active)
            {
                SetSubtitle(text + "...");
            }
        }

        private void SetSubtitle(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetSubtitle), text);
                return;
            }

            lblSubtitle.Text = text;
        }
    }
}
