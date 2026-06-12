namespace ChatClient.Forms
{
    partial class SettingsForm
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
            pnlSidebar = new Panel();
            btnLogStorage = new Button();
            btnAppearance = new Button();
            btnNotifications = new Button();
            btnConnection = new Button();
            btnAccount = new Button();
            pnlContent = new Panel();
            pnlAccount = new Panel();
            chkSaveLogin = new CheckBox();
            chkAutoReconnect = new CheckBox();
            chkSound = new CheckBox();
            chkNotifyMsg = new CheckBox();
            lblNotify7 = new Label();
            lblNotify6 = new Label();
            lblNotify5 = new Label();
            lblNotify4 = new Label();
            lblNotify3 = new Label();
            lblNotify2 = new Label();
            lblNotify1 = new Label();
            lblNotify = new Label();
            pnlDivider3 = new Panel();
            lblNotificationsOptions = new Label();
            lblStatus1 = new Label();
            lblStatus = new Label();
            txtPort = new TextBox();
            lblPort = new Label();
            lblIPHint = new Label();
            txtServerIP = new TextBox();
            lblServerIP = new Label();
            pnlDivider2 = new Panel();
            lblServerConnection = new Label();
            txtDisplayName = new TextBox();
            lblDisplayName = new Label();
            pnlDivider1 = new Panel();
            lblTitleAccount = new Label();
            pnlDivider4 = new Panel();
            pnlDivider5 = new Panel();
            pnlDivider6 = new Panel();
            pnlSidebar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlAccount.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.Blue;
            pnlSidebar.Controls.Add(btnLogStorage);
            pnlSidebar.Controls.Add(btnAppearance);
            pnlSidebar.Controls.Add(btnNotifications);
            pnlSidebar.Controls.Add(btnConnection);
            pnlSidebar.Controls.Add(btnAccount);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(180, 408);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogStorage
            // 
            btnLogStorage.BackColor = Color.Transparent;
            btnLogStorage.Dock = DockStyle.Top;
            btnLogStorage.FlatAppearance.BorderSize = 0;
            btnLogStorage.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            btnLogStorage.FlatStyle = FlatStyle.Flat;
            btnLogStorage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogStorage.ForeColor = Color.White;
            btnLogStorage.Location = new Point(0, 180);
            btnLogStorage.Name = "btnLogStorage";
            btnLogStorage.Size = new Size(180, 34);
            btnLogStorage.TabIndex = 4;
            btnLogStorage.Text = "📄 Log & Storage";
            btnLogStorage.TextAlign = ContentAlignment.MiddleLeft;
            btnLogStorage.UseVisualStyleBackColor = false;
            // 
            // btnAppearance
            // 
            btnAppearance.BackColor = Color.Transparent;
            btnAppearance.Dock = DockStyle.Top;
            btnAppearance.FlatAppearance.BorderSize = 0;
            btnAppearance.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            btnAppearance.FlatStyle = FlatStyle.Flat;
            btnAppearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAppearance.ForeColor = Color.White;
            btnAppearance.Location = new Point(0, 135);
            btnAppearance.Name = "btnAppearance";
            btnAppearance.Size = new Size(180, 45);
            btnAppearance.TabIndex = 3;
            btnAppearance.Text = "🎨  Appearance";
            btnAppearance.TextAlign = ContentAlignment.MiddleLeft;
            btnAppearance.UseVisualStyleBackColor = false;
            // 
            // btnNotifications
            // 
            btnNotifications.BackColor = Color.Transparent;
            btnNotifications.Dock = DockStyle.Top;
            btnNotifications.FlatAppearance.BorderSize = 0;
            btnNotifications.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            btnNotifications.FlatStyle = FlatStyle.Flat;
            btnNotifications.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNotifications.ForeColor = Color.White;
            btnNotifications.Location = new Point(0, 90);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(180, 45);
            btnNotifications.TabIndex = 2;
            btnNotifications.Text = "🔔  Notifications";
            btnNotifications.TextAlign = ContentAlignment.MiddleLeft;
            btnNotifications.UseVisualStyleBackColor = false;
            // 
            // btnConnection
            // 
            btnConnection.BackColor = Color.Transparent;
            btnConnection.Dock = DockStyle.Top;
            btnConnection.FlatAppearance.BorderSize = 0;
            btnConnection.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            btnConnection.FlatStyle = FlatStyle.Flat;
            btnConnection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConnection.ForeColor = Color.White;
            btnConnection.Location = new Point(0, 45);
            btnConnection.Name = "btnConnection";
            btnConnection.Size = new Size(180, 45);
            btnConnection.TabIndex = 1;
            btnConnection.Text = "🔗 Connection";
            btnConnection.TextAlign = ContentAlignment.MiddleLeft;
            btnConnection.UseVisualStyleBackColor = false;
            // 
            // btnAccount
            // 
            btnAccount.BackColor = Color.DodgerBlue;
            btnAccount.Dock = DockStyle.Top;
            btnAccount.FlatAppearance.BorderSize = 0;
            btnAccount.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            btnAccount.FlatStyle = FlatStyle.Flat;
            btnAccount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAccount.ForeColor = Color.White;
            btnAccount.Location = new Point(0, 0);
            btnAccount.Name = "btnAccount";
            btnAccount.Size = new Size(180, 45);
            btnAccount.TabIndex = 0;
            btnAccount.Text = " 👤  Account";
            btnAccount.TextAlign = ContentAlignment.MiddleLeft;
            btnAccount.UseVisualStyleBackColor = false;
            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;
            pnlContent.Controls.Add(pnlAccount);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(180, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(677, 408);
            pnlContent.TabIndex = 1;
            // 
            // pnlAccount
            // 
            pnlAccount.AutoScroll = true;
            pnlAccount.Controls.Add(pnlDivider6);
            pnlAccount.Controls.Add(pnlDivider5);
            pnlAccount.Controls.Add(pnlDivider4);
            pnlAccount.Controls.Add(chkSaveLogin);
            pnlAccount.Controls.Add(chkAutoReconnect);
            pnlAccount.Controls.Add(chkSound);
            pnlAccount.Controls.Add(chkNotifyMsg);
            pnlAccount.Controls.Add(lblNotify7);
            pnlAccount.Controls.Add(lblNotify6);
            pnlAccount.Controls.Add(lblNotify5);
            pnlAccount.Controls.Add(lblNotify4);
            pnlAccount.Controls.Add(lblNotify3);
            pnlAccount.Controls.Add(lblNotify2);
            pnlAccount.Controls.Add(lblNotify1);
            pnlAccount.Controls.Add(lblNotify);
            pnlAccount.Controls.Add(pnlDivider3);
            pnlAccount.Controls.Add(lblNotificationsOptions);
            pnlAccount.Controls.Add(lblStatus1);
            pnlAccount.Controls.Add(lblStatus);
            pnlAccount.Controls.Add(txtPort);
            pnlAccount.Controls.Add(lblPort);
            pnlAccount.Controls.Add(lblIPHint);
            pnlAccount.Controls.Add(txtServerIP);
            pnlAccount.Controls.Add(lblServerIP);
            pnlAccount.Controls.Add(pnlDivider2);
            pnlAccount.Controls.Add(lblServerConnection);
            pnlAccount.Controls.Add(txtDisplayName);
            pnlAccount.Controls.Add(lblDisplayName);
            pnlAccount.Controls.Add(pnlDivider1);
            pnlAccount.Controls.Add(lblTitleAccount);
            pnlAccount.Location = new Point(0, 0);
            pnlAccount.Name = "pnlAccount";
            pnlAccount.Size = new Size(648, 739);
            pnlAccount.TabIndex = 0;
            pnlAccount.Paint += pnlTaiKhoan_Paint;
            // 
            // chkSaveLogin
            // 
            chkSaveLogin.Appearance = Appearance.Button;
            chkSaveLogin.BackColor = Color.DodgerBlue;
            chkSaveLogin.Checked = true;
            chkSaveLogin.CheckState = CheckState.Checked;
            chkSaveLogin.FlatAppearance.BorderSize = 0;
            chkSaveLogin.FlatStyle = FlatStyle.Flat;
            chkSaveLogin.ForeColor = Color.Transparent;
            chkSaveLogin.Location = new Point(529, 663);
            chkSaveLogin.Name = "chkSaveLogin";
            chkSaveLogin.Size = new Size(45, 24);
            chkSaveLogin.TabIndex = 26;
            chkSaveLogin.UseVisualStyleBackColor = false;
            // 
            // chkAutoReconnect
            // 
            chkAutoReconnect.Appearance = Appearance.Button;
            chkAutoReconnect.BackColor = Color.DodgerBlue;
            chkAutoReconnect.Checked = true;
            chkAutoReconnect.CheckState = CheckState.Checked;
            chkAutoReconnect.FlatAppearance.BorderSize = 0;
            chkAutoReconnect.FlatStyle = FlatStyle.Flat;
            chkAutoReconnect.ForeColor = Color.Transparent;
            chkAutoReconnect.Location = new Point(529, 601);
            chkAutoReconnect.Name = "chkAutoReconnect";
            chkAutoReconnect.Size = new Size(45, 24);
            chkAutoReconnect.TabIndex = 25;
            chkAutoReconnect.UseVisualStyleBackColor = false;
            // 
            // chkSound
            // 
            chkSound.Appearance = Appearance.Button;
            chkSound.BackColor = Color.DodgerBlue;
            chkSound.Checked = true;
            chkSound.CheckState = CheckState.Checked;
            chkSound.FlatAppearance.BorderSize = 0;
            chkSound.FlatStyle = FlatStyle.Flat;
            chkSound.ForeColor = Color.Transparent;
            chkSound.Location = new Point(529, 537);
            chkSound.Name = "chkSound";
            chkSound.Size = new Size(45, 24);
            chkSound.TabIndex = 24;
            chkSound.UseVisualStyleBackColor = false;
            // 
            // chkNotifyMsg
            // 
            chkNotifyMsg.Appearance = Appearance.Button;
            chkNotifyMsg.BackColor = Color.DodgerBlue;
            chkNotifyMsg.Checked = true;
            chkNotifyMsg.CheckState = CheckState.Checked;
            chkNotifyMsg.FlatAppearance.BorderSize = 0;
            chkNotifyMsg.FlatStyle = FlatStyle.Flat;
            chkNotifyMsg.ForeColor = Color.Transparent;
            chkNotifyMsg.Location = new Point(529, 477);
            chkNotifyMsg.Name = "chkNotifyMsg";
            chkNotifyMsg.Size = new Size(45, 24);
            chkNotifyMsg.TabIndex = 23;
            chkNotifyMsg.UseVisualStyleBackColor = false;
            // 
            // lblNotify7
            // 
            lblNotify7.AutoSize = true;
            lblNotify7.ForeColor = SystemColors.ControlDarkDark;
            lblNotify7.Location = new Point(35, 687);
            lblNotify7.Name = "lblNotify7";
            lblNotify7.Size = new Size(248, 25);
            lblNotify7.TabIndex = 22;
            lblNotify7.Text = "Auto-fill IP and port next time";
            // 
            // lblNotify6
            // 
            lblNotify6.AutoSize = true;
            lblNotify6.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotify6.ForeColor = Color.Navy;
            lblNotify6.Location = new Point(35, 659);
            lblNotify6.Name = "lblNotify6";
            lblNotify6.Size = new Size(154, 28);
            lblNotify6.TabIndex = 21;
            lblNotify6.Text = "Save Login Info";
            // 
            // lblNotify5
            // 
            lblNotify5.AutoSize = true;
            lblNotify5.ForeColor = SystemColors.ControlDarkDark;
            lblNotify5.Location = new Point(35, 625);
            lblNotify5.Name = "lblNotify5";
            lblNotify5.Size = new Size(393, 25);
            lblNotify5.TabIndex = 20;
            lblNotify5.Text = "Reconnect automatically when connection is lost";
            // 
            // lblNotify4
            // 
            lblNotify4.AutoSize = true;
            lblNotify4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotify4.ForeColor = Color.Navy;
            lblNotify4.Location = new Point(35, 597);
            lblNotify4.Name = "lblNotify4";
            lblNotify4.Size = new Size(156, 28);
            lblNotify4.TabIndex = 19;
            lblNotify4.Text = "Auto Reconnect";
            lblNotify4.Click += lblNotify4_Click;
            // 
            // lblNotify3
            // 
            lblNotify3.AutoSize = true;
            lblNotify3.ForeColor = SystemColors.ControlDarkDark;
            lblNotify3.Location = new Point(35, 561);
            lblNotify3.Name = "lblNotify3";
            lblNotify3.Size = new Size(328, 25);
            lblNotify3.TabIndex = 18;
            lblNotify3.Text = "Play sound when a new message arrives";
            // 
            // lblNotify2
            // 
            lblNotify2.AutoSize = true;
            lblNotify2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotify2.ForeColor = Color.Navy;
            lblNotify2.Location = new Point(35, 533);
            lblNotify2.Name = "lblNotify2";
            lblNotify2.Size = new Size(183, 28);
            lblNotify2.TabIndex = 17;
            lblNotify2.Text = "Notification Sound";
            // 
            // lblNotify1
            // 
            lblNotify1.AutoSize = true;
            lblNotify1.ForeColor = SystemColors.ControlDarkDark;
            lblNotify1.Location = new Point(35, 501);
            lblNotify1.Name = "lblNotify1";
            lblNotify1.Size = new Size(338, 25);
            lblNotify1.TabIndex = 16;
            lblNotify1.Text = "Show popup when a message is received";
            lblNotify1.TextAlign = ContentAlignment.MiddleCenter;
            lblNotify1.Click += lblNotify1_Click;
            // 
            // lblNotify
            // 
            lblNotify.AutoSize = true;
            lblNotify.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotify.ForeColor = Color.Navy;
            lblNotify.Location = new Point(31, 473);
            lblNotify.Name = "lblNotify";
            lblNotify.Size = new Size(213, 28);
            lblNotify.TabIndex = 15;
            lblNotify.Text = "Message Notifications";
            lblNotify.Click += lblNotify_Click;
            // 
            // pnlDivider3
            // 
            pnlDivider3.BackColor = Color.Silver;
            pnlDivider3.Location = new Point(25, 457);
            pnlDivider3.Name = "pnlDivider3";
            pnlDivider3.Size = new Size(600, 2);
            pnlDivider3.TabIndex = 14;
            // 
            // lblNotificationsOptions
            // 
            lblNotificationsOptions.AutoSize = true;
            lblNotificationsOptions.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotificationsOptions.ForeColor = Color.Blue;
            lblNotificationsOptions.Location = new Point(25, 422);
            lblNotificationsOptions.Name = "lblNotificationsOptions";
            lblNotificationsOptions.Size = new Size(266, 32);
            lblNotificationsOptions.TabIndex = 13;
            lblNotificationsOptions.Text = "Notifications & Options";
            lblNotificationsOptions.Click += lblThongBaoTitle_Click;
            // 
            // lblStatus1
            // 
            lblStatus1.AutoSize = true;
            lblStatus1.ForeColor = SystemColors.ControlDarkDark;
            lblStatus1.Location = new Point(139, 365);
            lblStatus1.Name = "lblStatus1";
            lblStatus1.Size = new Size(168, 25);
            lblStatus1.TabIndex = 12;
            lblStatus1.Text = "192.168.1.100:8080";
            lblStatus1.Click += lblStatus1_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.PaleGreen;
            lblStatus.ForeColor = Color.Navy;
            lblStatus.Location = new Point(24, 365);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(113, 25);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "● Connected";
            lblStatus.Click += lblStatus_Click;
            // 
            // txtPort
            // 
            txtPort.BorderStyle = BorderStyle.FixedSingle;
            txtPort.Location = new Point(25, 322);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(600, 31);
            txtPort.TabIndex = 10;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPort.ForeColor = Color.Navy;
            lblPort.Location = new Point(25, 294);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(48, 25);
            lblPort.TabIndex = 9;
            lblPort.Text = "Port";
            // 
            // lblIPHint
            // 
            lblIPHint.AutoSize = true;
            lblIPHint.ForeColor = SystemColors.ControlDarkDark;
            lblIPHint.Location = new Point(25, 257);
            lblIPHint.Name = "lblIPHint";
            lblIPHint.Size = new Size(448, 25);
            lblIPHint.TabIndex = 8;
            lblIPHint.Text = "IP of the machine running ChatServer on the same LAN";
            // 
            // txtServerIP
            // 
            txtServerIP.BorderStyle = BorderStyle.FixedSingle;
            txtServerIP.Location = new Point(25, 223);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(600, 31);
            txtServerIP.TabIndex = 7;
            // 
            // lblServerIP
            // 
            lblServerIP.AutoSize = true;
            lblServerIP.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServerIP.ForeColor = Color.Navy;
            lblServerIP.Location = new Point(25, 189);
            lblServerIP.Name = "lblServerIP";
            lblServerIP.Size = new Size(162, 25);
            lblServerIP.TabIndex = 6;
            lblServerIP.Text = "Server IP Address";
            // 
            // pnlDivider2
            // 
            pnlDivider2.BackColor = Color.Silver;
            pnlDivider2.Location = new Point(24, 180);
            pnlDivider2.Name = "pnlDivider2";
            pnlDivider2.Size = new Size(600, 2);
            pnlDivider2.TabIndex = 5;
            // 
            // lblServerConnection
            // 
            lblServerConnection.AutoSize = true;
            lblServerConnection.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServerConnection.ForeColor = Color.Blue;
            lblServerConnection.Location = new Point(25, 145);
            lblServerConnection.Name = "lblServerConnection";
            lblServerConnection.Size = new Size(225, 32);
            lblServerConnection.TabIndex = 4;
            lblServerConnection.Text = "Server Connection";
            lblServerConnection.Click += lblServerConnection_Click;
            // 
            // txtDisplayName
            // 
            txtDisplayName.BorderStyle = BorderStyle.FixedSingle;
            txtDisplayName.Location = new Point(24, 90);
            txtDisplayName.Name = "txtDisplayName";
            txtDisplayName.Size = new Size(601, 31);
            txtDisplayName.TabIndex = 3;
            txtDisplayName.TextChanged += txtTenHienThi_TextChanged;
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDisplayName.ForeColor = Color.Navy;
            lblDisplayName.Location = new Point(24, 55);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(129, 25);
            lblDisplayName.TabIndex = 2;
            lblDisplayName.Text = "Display Name";
            // 
            // pnlDivider1
            // 
            pnlDivider1.BackColor = Color.Silver;
            pnlDivider1.Location = new Point(24, 48);
            pnlDivider1.Name = "pnlDivider1";
            pnlDivider1.Size = new Size(600, 2);
            pnlDivider1.TabIndex = 1;
            // 
            // lblTitleAccount
            // 
            lblTitleAccount.AutoSize = true;
            lblTitleAccount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleAccount.ForeColor = Color.Blue;
            lblTitleAccount.Location = new Point(24, 13);
            lblTitleAccount.Name = "lblTitleAccount";
            lblTitleAccount.Size = new Size(254, 32);
            lblTitleAccount.TabIndex = 0;
            lblTitleAccount.Text = "Account Information";
            // 
            // pnlDivider4
            // 
            pnlDivider4.BackColor = Color.Silver;
            pnlDivider4.Location = new Point(25, 528);
            pnlDivider4.Name = "pnlDivider4";
            pnlDivider4.Size = new Size(600, 1);
            pnlDivider4.TabIndex = 27;
            // 
            // pnlDivider5
            // 
            pnlDivider5.BackColor = Color.Silver;
            pnlDivider5.Location = new Point(25, 592);
            pnlDivider5.Name = "pnlDivider5";
            pnlDivider5.Size = new Size(600, 1);
            pnlDivider5.TabIndex = 28;
            // 
            // pnlDivider6
            // 
            pnlDivider6.BackColor = Color.Silver;
            pnlDivider6.Location = new Point(25, 653);
            pnlDivider6.Name = "pnlDivider6";
            pnlDivider6.Size = new Size(600, 1);
            pnlDivider6.TabIndex = 29;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 408);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SettingsForm";
            pnlSidebar.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlAccount.ResumeLayout(false);
            pnlAccount.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Button btnLogStorage;
        private Button btnAppearance;
        private Button btnNotifications;
        private Button btnConnection;
        private Button btnAccount;
        private Panel pnlContent;
        private Panel pnlAccount;
        private TextBox txtPort;
        private Label lblPort;
        private Label lblIPHint;
        private TextBox txtServerIP;
        private Label lblServerIP;
        private Panel pnlDivider2;
        private Label lblServerConnection;
        private TextBox txtDisplayName;
        private Label lblDisplayName;
        private Panel pnlDivider1;
        private Label lblTitleAccount;
        private Label lblStatus;
        private Label lblStatus1;
        private Panel pnlDivider3;
        private Label lblNotificationsOptions;
        private Label lblNotify1;
        private Label lblNotify;
        private Label lblNotify2;
        private Label lblNotify7;
        private Label lblNotify6;
        private Label lblNotify5;
        private Label lblNotify4;
        private Label lblNotify3;
        private CheckBox chkNotifyMsg;
        private CheckBox chkSaveLogin;
        private CheckBox chkAutoReconnect;
        private CheckBox chkSound;
        private Panel pnlDivider6;
        private Panel pnlDivider5;
        private Panel pnlDivider4;
    }
}