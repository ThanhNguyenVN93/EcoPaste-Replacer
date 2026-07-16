using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using frm_ecopaste.Helpers;

namespace frm_ecopaste
{
    /// <summary>
    /// Shown when .NET Framework 4.7.2 is missing: downloads and silently installs it while
    /// displaying progress, instead of just pointing the user to a manual download page.
    /// </summary>
    public partial class FrameworkSetupForm : Form
    {
        public bool Success { get; private set; }

        public FrameworkSetupForm()
        {
            InitializeComponent();
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            animationTimer.Start();

            try
            {
                Success = await DotNetFrameworkInstaller.InstallAsync(SetStatus);
            }
            catch (Exception ex)
            {
                Success = false;
                SetStatus("Error: " + ex.Message);
                await Task.Delay(2000);
            }

            animationTimer.Stop();
            DialogResult = Success ? DialogResult.OK : DialogResult.Abort;
            Close();
        }

        private void SetStatus(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetStatus), text);
                return;
            }

            lblStatus.Text = text;
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Value = (progressBar.Value + 3) % (progressBar.Maximum + 1);
        }
    }
}
