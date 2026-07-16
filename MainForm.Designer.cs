namespace frm_ecopaste
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnRun = new Guna.UI2.WinForms.Guna2Button();
            this.progressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblStepCount = new System.Windows.Forms.Label();
            this.pnlLog = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblStep4 = new System.Windows.Forms.Label();
            this.lblStep5 = new System.Windows.Forms.Label();
            this.lblStep6 = new System.Windows.Forms.Label();
            this.linkFeedback = new System.Windows.Forms.LinkLabel();
            this.trayContextMenu.SuspendLayout();
            this.pnlLog.SuspendLayout();
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
            // trayIcon
            //
            this.trayIcon.ContextMenuStrip = this.trayContextMenu;
            this.trayIcon.Text = "EcoPaste Replacer";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            //
            // trayContextMenu
            //
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpen,
            this.menuItemExit});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.Size = new System.Drawing.Size(114, 48);
            //
            // menuItemOpen
            //
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.Size = new System.Drawing.Size(113, 22);
            this.menuItemOpen.Text = "Open";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            //
            // menuItemExit
            //
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(113, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "EcoPaste Replacer";
            //
            // lblSubtitle
            //
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(172)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 54);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(412, 24);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Ready to replace Windows V with EcoPaste";
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
            this.btnClose.Location = new System.Drawing.Point(422, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 26);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "×";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // btnRun
            //
            this.btnRun.BorderRadius = 8;
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRun.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRun.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(66)))));
            this.btnRun.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(138)))));
            this.btnRun.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(122)))), ((int)(((byte)(85)))));
            this.btnRun.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(24, 94);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(160, 44);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Start";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            //
            // progressBar
            //
            this.progressBar.BorderRadius = 4;
            this.progressBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(46)))));
            this.progressBar.Location = new System.Drawing.Point(24, 154);
            this.progressBar.Maximum = 6;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(122)))), ((int)(((byte)(85)))));
            this.progressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(122)))), ((int)(((byte)(85)))));
            this.progressBar.Size = new System.Drawing.Size(412, 8);
            this.progressBar.TabIndex = 3;
            //
            // lblStepCount
            //
            this.lblStepCount.BackColor = System.Drawing.Color.Transparent;
            this.lblStepCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStepCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(130)))));
            this.lblStepCount.Location = new System.Drawing.Point(24, 168);
            this.lblStepCount.Name = "lblStepCount";
            this.lblStepCount.Size = new System.Drawing.Size(412, 20);
            this.lblStepCount.TabIndex = 4;
            this.lblStepCount.Text = "Step 0/6";
            //
            // pnlLog
            //
            this.pnlLog.BackColor = System.Drawing.Color.Transparent;
            this.pnlLog.BorderRadius = 10;
            this.pnlLog.Controls.Add(this.lblStep1);
            this.pnlLog.Controls.Add(this.lblStep2);
            this.pnlLog.Controls.Add(this.lblStep3);
            this.pnlLog.Controls.Add(this.lblStep4);
            this.pnlLog.Controls.Add(this.lblStep5);
            this.pnlLog.Controls.Add(this.lblStep6);
            this.pnlLog.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.pnlLog.Location = new System.Drawing.Point(24, 200);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(412, 268);
            this.pnlLog.TabIndex = 5;
            //
            // lblStep1
            //
            this.lblStep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.lblStep1.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.lblStep1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.lblStep1.Location = new System.Drawing.Point(16, 16);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(380, 36);
            this.lblStep1.TabIndex = 0;
            //
            // lblStep2
            //
            this.lblStep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.lblStep2.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.lblStep2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.lblStep2.Location = new System.Drawing.Point(16, 52);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(380, 36);
            this.lblStep2.TabIndex = 1;
            //
            // lblStep3
            //
            this.lblStep3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.lblStep3.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.lblStep3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.lblStep3.Location = new System.Drawing.Point(16, 88);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(380, 36);
            this.lblStep3.TabIndex = 2;
            //
            // lblStep4
            //
            this.lblStep4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.lblStep4.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.lblStep4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.lblStep4.Location = new System.Drawing.Point(16, 124);
            this.lblStep4.Name = "lblStep4";
            this.lblStep4.Size = new System.Drawing.Size(380, 36);
            this.lblStep4.TabIndex = 3;
            //
            // lblStep5
            //
            this.lblStep5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.lblStep5.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.lblStep5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.lblStep5.Location = new System.Drawing.Point(16, 160);
            this.lblStep5.Name = "lblStep5";
            this.lblStep5.Size = new System.Drawing.Size(380, 36);
            this.lblStep5.TabIndex = 4;
            //
            // lblStep6
            //
            this.lblStep6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.lblStep6.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.lblStep6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.lblStep6.Location = new System.Drawing.Point(16, 196);
            this.lblStep6.Name = "lblStep6";
            this.lblStep6.Size = new System.Drawing.Size(380, 36);
            this.lblStep6.TabIndex = 5;
            //
            // linkFeedback
            //
            this.linkFeedback.BackColor = System.Drawing.Color.Transparent;
            this.linkFeedback.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.linkFeedback.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(130)))));
            this.linkFeedback.Location = new System.Drawing.Point(24, 480);
            this.linkFeedback.Name = "linkFeedback";
            this.linkFeedback.Size = new System.Drawing.Size(100, 18);
            this.linkFeedback.TabIndex = 7;
            this.linkFeedback.TabStop = true;
            this.linkFeedback.Text = "Feedback";
            this.linkFeedback.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFeedback_LinkClicked);
            //
            // MainForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(460, 512);
            this.Controls.Add(this.linkFeedback);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.lblStepCount);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcoPaste Replacer";
            this.trayContextMenu.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnRun;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar;
        private System.Windows.Forms.Label lblStepCount;
        private Guna.UI2.WinForms.Guna2Panel pnlLog;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblStep4;
        private System.Windows.Forms.Label lblStep5;
        private System.Windows.Forms.Label lblStep6;
        private System.Windows.Forms.LinkLabel linkFeedback;
    }
}
