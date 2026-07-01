namespace ChatServer.Forms
{
    partial class ServerSettingForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            pnlContent = new Panel();
            btnExportLog = new Button();
            btnBrowseLogPath = new Button();
            chkEnableLog = new CheckBox();
            lblEnableLogHint = new Label();
            lblEnableLog = new Label();
            txtPort = new TextBox();
            lblPortHint = new Label();
            lblPort = new Label();
            txtLogPath = new TextBox();
            lblLogPathHint = new Label();
            lblLogPath = new Label();
            txtMaxClients = new TextBox();
            lblMaxClientsHint = new Label();
            lblMaxClients = new Label();
            pnlFooter = new Panel();
            btnExit = new Button();
            btnSave = new Button();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Blue;
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(640, 58);
            pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.DodgerBlue;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(584, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 34);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnExit_Click;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(24, 0, 0, 0);
            lblTitle.Size = new Size(360, 58);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "⚙ Server Settings";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(btnExportLog);
            pnlContent.Controls.Add(btnBrowseLogPath);
            pnlContent.Controls.Add(chkEnableLog);
            pnlContent.Controls.Add(lblEnableLogHint);
            pnlContent.Controls.Add(lblEnableLog);
            pnlContent.Controls.Add(txtPort);
            pnlContent.Controls.Add(lblPortHint);
            pnlContent.Controls.Add(lblPort);
            pnlContent.Controls.Add(txtLogPath);
            pnlContent.Controls.Add(lblLogPathHint);
            pnlContent.Controls.Add(lblLogPath);
            pnlContent.Controls.Add(txtMaxClients);
            pnlContent.Controls.Add(lblMaxClientsHint);
            pnlContent.Controls.Add(lblMaxClients);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 58);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(28, 20, 28, 20);
            pnlContent.Size = new Size(640, 414);
            pnlContent.TabIndex = 1;
            // 
            // lblMaxClients
            // 
            lblMaxClients.AutoSize = true;
            lblMaxClients.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaxClients.ForeColor = Color.Navy;
            lblMaxClients.Location = new Point(28, 18);
            lblMaxClients.Name = "lblMaxClients";
            lblMaxClients.Size = new Size(94, 21);
            lblMaxClients.TabIndex = 0;
            lblMaxClients.Text = "Max Clients";
            // 
            // lblMaxClientsHint
            // 
            lblMaxClientsHint.AutoSize = true;
            lblMaxClientsHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaxClientsHint.ForeColor = Color.Gray;
            lblMaxClientsHint.Location = new Point(28, 42);
            lblMaxClientsHint.Name = "lblMaxClientsHint";
            lblMaxClientsHint.Size = new Size(306, 20);
            lblMaxClientsHint.TabIndex = 1;
            lblMaxClientsHint.Text = "Số lượng client tối đa server cho phép lưu.";
            // 
            // txtMaxClients
            // 
            txtMaxClients.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaxClients.BorderStyle = BorderStyle.FixedSingle;
            txtMaxClients.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaxClients.Location = new Point(28, 66);
            txtMaxClients.Name = "txtMaxClients";
            txtMaxClients.Size = new Size(560, 29);
            txtMaxClients.TabIndex = 2;
            // 
            // lblLogPath
            // 
            lblLogPath.AutoSize = true;
            lblLogPath.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogPath.ForeColor = Color.Navy;
            lblLogPath.Location = new Point(28, 112);
            lblLogPath.Name = "lblLogPath";
            lblLogPath.Size = new Size(76, 21);
            lblLogPath.TabIndex = 3;
            lblLogPath.Text = "Log Path";
            // 
            // lblLogPathHint
            // 
            lblLogPathHint.AutoSize = true;
            lblLogPathHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogPathHint.ForeColor = Color.Gray;
            lblLogPathHint.Location = new Point(28, 136);
            lblLogPathHint.Name = "lblLogPathHint";
            lblLogPathHint.Size = new Size(346, 20);
            lblLogPathHint.TabIndex = 4;
            lblLogPathHint.Text = "Đường dẫn file log, ví dụ ChatShared/Log/server.log.";
            // 
            // txtLogPath
            // 
            txtLogPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLogPath.BorderStyle = BorderStyle.FixedSingle;
            txtLogPath.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLogPath.Location = new Point(28, 160);
            txtLogPath.Name = "txtLogPath";
            txtLogPath.Size = new Size(440, 29);
            txtLogPath.TabIndex = 5;
            // 
            // btnBrowseLogPath
            // 
            btnBrowseLogPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseLogPath.BackColor = Color.White;
            btnBrowseLogPath.FlatAppearance.BorderColor = Color.Blue;
            btnBrowseLogPath.FlatStyle = FlatStyle.Flat;
            btnBrowseLogPath.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowseLogPath.ForeColor = Color.Blue;
            btnBrowseLogPath.Location = new Point(484, 160);
            btnBrowseLogPath.Name = "btnBrowseLogPath";
            btnBrowseLogPath.Size = new Size(104, 29);
            btnBrowseLogPath.TabIndex = 6;
            btnBrowseLogPath.Text = "Browse";
            btnBrowseLogPath.UseVisualStyleBackColor = false;
            btnBrowseLogPath.Click += btnBrowseLogPath_Click;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPort.ForeColor = Color.Navy;
            lblPort.Location = new Point(28, 206);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(39, 21);
            lblPort.TabIndex = 7;
            lblPort.Text = "Port";
            // 
            // lblPortHint
            // 
            lblPortHint.AutoSize = true;
            lblPortHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPortHint.ForeColor = Color.Gray;
            lblPortHint.Location = new Point(28, 230);
            lblPortHint.Name = "lblPortHint";
            lblPortHint.Size = new Size(221, 20);
            lblPortHint.TabIndex = 8;
            lblPortHint.Text = "Port mặc định đề xuất là 8080.";
            // 
            // txtPort
            // 
            txtPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPort.BorderStyle = BorderStyle.FixedSingle;
            txtPort.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPort.Location = new Point(28, 254);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(560, 29);
            txtPort.TabIndex = 9;
            // 
            // lblEnableLog
            // 
            lblEnableLog.AutoSize = true;
            lblEnableLog.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnableLog.ForeColor = Color.Navy;
            lblEnableLog.Location = new Point(28, 300);
            lblEnableLog.Name = "lblEnableLog";
            lblEnableLog.Size = new Size(91, 21);
            lblEnableLog.TabIndex = 10;
            lblEnableLog.Text = "Enable Log";
            // 
            // lblEnableLogHint
            // 
            lblEnableLogHint.AutoSize = true;
            lblEnableLogHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEnableLogHint.ForeColor = Color.Gray;
            lblEnableLogHint.Location = new Point(28, 324);
            lblEnableLogHint.Name = "lblEnableLogHint";
            lblEnableLogHint.Size = new Size(290, 20);
            lblEnableLogHint.TabIndex = 11;
            lblEnableLogHint.Text = "Nếu tắt, server chỉ hiện log trên giao diện.";
            // 
            // chkEnableLog
            // 
            chkEnableLog.Appearance = Appearance.Button;
            chkEnableLog.BackColor = Color.DodgerBlue;
            chkEnableLog.Checked = true;
            chkEnableLog.CheckState = CheckState.Checked;
            chkEnableLog.FlatAppearance.BorderSize = 0;
            chkEnableLog.FlatStyle = FlatStyle.Flat;
            chkEnableLog.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkEnableLog.ForeColor = Color.White;
            chkEnableLog.Location = new Point(28, 354);
            chkEnableLog.Name = "chkEnableLog";
            chkEnableLog.Size = new Size(74, 34);
            chkEnableLog.TabIndex = 12;
            chkEnableLog.Text = "ON";
            chkEnableLog.TextAlign = ContentAlignment.MiddleCenter;
            chkEnableLog.UseVisualStyleBackColor = false;
            chkEnableLog.CheckedChanged += chkEnableLog_CheckedChanged;
            // 
            // btnExportLog
            // 
            btnExportLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportLog.BackColor = Color.White;
            btnExportLog.FlatAppearance.BorderColor = Color.Blue;
            btnExportLog.FlatStyle = FlatStyle.Flat;
            btnExportLog.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportLog.ForeColor = Color.Blue;
            btnExportLog.Location = new Point(438, 354);
            btnExportLog.Name = "btnExportLog";
            btnExportLog.Size = new Size(150, 34);
            btnExportLog.TabIndex = 13;
            btnExportLog.Text = "Export Log";
            btnExportLog.UseVisualStyleBackColor = false;
            btnExportLog.Click += btnExportLog_Click;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.WhiteSmoke;
            pnlFooter.Controls.Add(btnExit);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 472);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(640, 68);
            pnlFooter.TabIndex = 2;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExit.BackColor = Color.White;
            btnExit.FlatAppearance.BorderColor = Color.Blue;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.Blue;
            btnExit.Location = new Point(28, 16);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(130, 38);
            btnExit.TabIndex = 0;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.Blue;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(482, 16);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 38);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // ServerSettingForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnExit;
            ClientSize = new Size(640, 540);
            ControlBox = false;
            Controls.Add(pnlContent);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ServerSettingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Server Settings";
            Load += ServerSettingForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Button btnClose;
        private Label lblTitle;
        private Panel pnlContent;
        private Label lblMaxClients;
        private Label lblMaxClientsHint;
        private TextBox txtMaxClients;
        private Label lblLogPath;
        private Label lblLogPathHint;
        private TextBox txtLogPath;
        private Button btnBrowseLogPath;
        private Label lblPort;
        private Label lblPortHint;
        private TextBox txtPort;
        private Label lblEnableLog;
        private Label lblEnableLogHint;
        private CheckBox chkEnableLog;
        private Button btnExportLog;
        private Panel pnlFooter;
        private Button btnExit;
        private Button btnSave;
    }
}