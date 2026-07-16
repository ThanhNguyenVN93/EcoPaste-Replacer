namespace frm_ecopaste
{
    partial class DonateForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBoxBank = new System.Windows.Forms.PictureBox();
            this.pictureBoxMomo = new System.Windows.Forms.PictureBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblMomo = new System.Windows.Forms.Label();
            this.linkKofi = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMomo)).BeginInit();
            this.SuspendLayout();
            //
            // guna2BorderlessForm
            //
            this.guna2BorderlessForm.BorderRadius = 16;
            this.guna2BorderlessForm.ContainerControl = this;
            this.guna2BorderlessForm.DragForm = true;
            this.guna2BorderlessForm.HasFormShadow = true;
            this.guna2BorderlessForm.ResizeForm = false;
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(380, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Support the Developer";
            //
            // lblSubtitle
            //
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(172)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 54);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(402, 24);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Scan to donate via bank transfer or MoMo";
            //
            // btnClose
            //
            this.btnClose.BorderRadius = 13;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(172)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnClose.Location = new System.Drawing.Point(410, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "×";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // pictureBoxBank
            //
            this.pictureBoxBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.pictureBoxBank.Location = new System.Drawing.Point(24, 90);
            this.pictureBoxBank.Name = "pictureBoxBank";
            this.pictureBoxBank.Size = new System.Drawing.Size(190, 250);
            this.pictureBoxBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBank.TabIndex = 2;
            this.pictureBoxBank.TabStop = false;
            //
            // pictureBoxMomo
            //
            this.pictureBoxMomo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.pictureBoxMomo.Location = new System.Drawing.Point(236, 90);
            this.pictureBoxMomo.Name = "pictureBoxMomo";
            this.pictureBoxMomo.Size = new System.Drawing.Size(190, 250);
            this.pictureBoxMomo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMomo.TabIndex = 3;
            this.pictureBoxMomo.TabStop = false;
            //
            // lblBank
            //
            this.lblBank.BackColor = System.Drawing.Color.Transparent;
            this.lblBank.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(172)))));
            this.lblBank.Location = new System.Drawing.Point(24, 344);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(190, 20);
            this.lblBank.TabIndex = 4;
            this.lblBank.Text = "Bank Transfer";
            this.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblMomo
            //
            this.lblMomo.BackColor = System.Drawing.Color.Transparent;
            this.lblMomo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMomo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(172)))));
            this.lblMomo.Location = new System.Drawing.Point(236, 344);
            this.lblMomo.Name = "lblMomo";
            this.lblMomo.Size = new System.Drawing.Size(190, 20);
            this.lblMomo.TabIndex = 5;
            this.lblMomo.Text = "MoMo";
            this.lblMomo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // linkKofi
            //
            this.linkKofi.BackColor = System.Drawing.Color.Transparent;
            this.linkKofi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.linkKofi.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(130)))));
            this.linkKofi.Location = new System.Drawing.Point(24, 378);
            this.linkKofi.Name = "linkKofi";
            this.linkKofi.Size = new System.Drawing.Size(402, 24);
            this.linkKofi.TabIndex = 6;
            this.linkKofi.TabStop = true;
            this.linkKofi.Text = "https://ko-fi.com/thanhnguyen150993";
            this.linkKofi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkKofi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkKofi_LinkClicked);
            //
            // DonateForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(450, 420);
            this.Controls.Add(this.linkKofi);
            this.Controls.Add(this.lblMomo);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.pictureBoxMomo);
            this.Controls.Add(this.pictureBoxBank);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DonateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Support the Developer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMomo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.PictureBox pictureBoxBank;
        private System.Windows.Forms.PictureBox pictureBoxMomo;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblMomo;
        private System.Windows.Forms.LinkLabel linkKofi;
    }
}
