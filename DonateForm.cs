using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace frm_ecopaste
{
    public partial class DonateForm : Form
    {
        private const string BankResourceName = "frm_ecopaste.Resources.tcb.jpg";
        private const string MomoResourceName = "frm_ecopaste.Resources.momo.jpg";
        private const string KofiUrl = "https://ko-fi.com/thanhnguyen150993";

        public DonateForm()
        {
            InitializeComponent();
            pictureBoxBank.Image = LoadEmbeddedImage(BankResourceName);
            pictureBoxMomo.Image = LoadEmbeddedImage(MomoResourceName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkKofi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(KofiUrl) { UseShellExecute = true });
        }

        private static Image LoadEmbeddedImage(string resourceName)
        {
            var memoryStream = new MemoryStream();

            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                resourceStream.CopyTo(memoryStream);
            }

            return Image.FromStream(memoryStream);
        }
    }
}
