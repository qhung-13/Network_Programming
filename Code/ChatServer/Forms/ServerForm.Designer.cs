namespace ChatServer.Forms
{
    partial class ServerForm
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

        private void InitializeComponent()
        {
            tblToolbar = new TableLayoutPanel();
            btnStart = new Button();
            btnStop = new Button();
            btnClearLog = new Button();
            lblStatus = new Label();
            btnSettings2 = new Button();
            pnlMain = new Panel();
            pnlLogContainer = new Panel();
            pnlLogHeader = new Panel();
            lblLogTitle = new Label();
            rtbLog = new RichTextBox();
            pnlClients = new Panel();
            flpClients = new FlowLayoutPanel();
            lblClientCount = new Label();
            tblStats = new TableLayoutPanel();
            lblClients = new Label();
            lblRooms = new Label();
            lblMessages = new Label();
            lblUptime = new Label();
            tblToolbar.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlLogContainer.SuspendLayout();
            pnlLogHeader.SuspendLayout();
            pnlClients.SuspendLayout();
            tblStats.SuspendLayout();
            SuspendLayout();
            // 
            // tblToolbar
            // 
            tblToolbar.BackColor = Color.FromArgb(0, 92, 191);
            tblToolbar.ColumnCount = 5;
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tblToolbar.Controls.Add(btnStart, 0, 0);
            tblToolbar.Controls.Add(btnStop, 1, 0);
            tblToolbar.Controls.Add(btnClearLog, 2, 0);
            tblToolbar.Controls.Add(lblStatus, 3, 0);
            tblToolbar.Controls.Add(btnSettings2, 4, 0);
            tblToolbar.Dock = DockStyle.Top;
            tblToolbar.Location = new Point(0, 0);
            tblToolbar.Name = "tblToolbar";
            tblToolbar.Padding = new Padding(14, 10, 14, 10);
            tblToolbar.RowCount = 1;
            tblToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblToolbar.Size = new Size(900, 60);
            tblToolbar.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.White;
            btnStart.Dock = DockStyle.Fill;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.FromArgb(0, 92, 191);
            btnStart.Location = new Point(17, 13);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(114, 34);
            btnStart.TabIndex = 0;
            btnStart.Text = "▶ Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.White;
            btnStop.Dock = DockStyle.Fill;
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStop.ForeColor = Color.FromArgb(0, 92, 191);
            btnStop.Location = new Point(137, 13);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(114, 34);
            btnStop.TabIndex = 1;
            btnStop.Text = "■ Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnClearLog
            // 
            btnClearLog.BackColor = Color.White;
            btnClearLog.Dock = DockStyle.Fill;
            btnClearLog.FlatAppearance.BorderSize = 0;
            btnClearLog.FlatStyle = FlatStyle.Flat;
            btnClearLog.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearLog.ForeColor = Color.FromArgb(0, 92, 191);
            btnClearLog.Location = new Point(257, 13);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(144, 34);
            btnClearLog.TabIndex = 2;
            btnClearLog.Text = "🗑 Clear Log";
            btnClearLog.UseVisualStyleBackColor = false;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(407, 10);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(356, 40);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "● Offline";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSettings2
            // 
            btnSettings2.BackColor = Color.FromArgb(230, 243, 255);
            btnSettings2.Dock = DockStyle.Fill;
            btnSettings2.FlatAppearance.BorderSize = 0;
            btnSettings2.FlatStyle = FlatStyle.Flat;
            btnSettings2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSettings2.ForeColor = Color.FromArgb(0, 92, 191);
            btnSettings2.Location = new Point(769, 13);
            btnSettings2.Name = "btnSettings2";
            btnSettings2.Size = new Size(114, 34);
            btnSettings2.TabIndex = 4;
            btnSettings2.Text = "⚙ Settings";
            btnSettings2.UseVisualStyleBackColor = false;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(pnlLogContainer);
            pnlMain.Controls.Add(pnlClients);
            pnlMain.Controls.Add(tblStats);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(16);
            pnlMain.Size = new Size(900, 500);
            pnlMain.TabIndex = 1;
            // 
            // pnlLogContainer
            // 
            pnlLogContainer.BackColor = Color.White;
            pnlLogContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlLogContainer.Controls.Add(rtbLog);
            pnlLogContainer.Controls.Add(pnlLogHeader);
            pnlLogContainer.Dock = DockStyle.Fill;
            pnlLogContainer.Location = new Point(16, 16);
            pnlLogContainer.Name = "pnlLogContainer";
            pnlLogContainer.Size = new Size(638, 416);
            pnlLogContainer.TabIndex = 2;
            // 
            // pnlLogHeader
            // 
            pnlLogHeader.BackColor = Color.FromArgb(245, 250, 255);
            pnlLogHeader.Controls.Add(lblLogTitle);
            pnlLogHeader.Dock = DockStyle.Top;
            pnlLogHeader.Location = new Point(0, 0);
            pnlLogHeader.Name = "pnlLogHeader";
            pnlLogHeader.Padding = new Padding(14, 0, 14, 0);
            pnlLogHeader.Size = new Size(636, 42);
            pnlLogHeader.TabIndex = 1;
            // 
            // lblLogTitle
            // 
            lblLogTitle.AutoSize = true;
            lblLogTitle.Dock = DockStyle.Left;
            lblLogTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogTitle.ForeColor = Color.FromArgb(0, 65, 130);
            lblLogTitle.Location = new Point(14, 0);
            lblLogTitle.Name = "lblLogTitle";
            lblLogTitle.Size = new Size(84, 28);
            lblLogTitle.TabIndex = 0;
            lblLogTitle.Text = "Server Log";
            lblLogTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.White;
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbLog.ForeColor = Color.FromArgb(30, 30, 30);
            rtbLog.Location = new Point(0, 42);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbLog.Size = new Size(636, 372);
            rtbLog.TabIndex = 0;
            rtbLog.Text = "";
            rtbLog.TextChanged += rtbLog_TextChanged;
            // 
            // pnlClients
            // 
            pnlClients.BackColor = Color.FromArgb(0, 92, 191);
            pnlClients.Controls.Add(flpClients);
            pnlClients.Controls.Add(lblClientCount);
            pnlClients.Dock = DockStyle.Right;
            pnlClients.Location = new Point(654, 16);
            pnlClients.Name = "pnlClients";
            pnlClients.Padding = new Padding(12);
            pnlClients.Size = new Size(230, 416);
            pnlClients.TabIndex = 3;
            // 
            // flpClients
            // 
            flpClients.AutoScroll = true;
            flpClients.BackColor = Color.FromArgb(0, 92, 191);
            flpClients.Dock = DockStyle.Fill;
            flpClients.FlowDirection = FlowDirection.TopDown;
            flpClients.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flpClients.ForeColor = Color.White;
            flpClients.Location = new Point(12, 52);
            flpClients.Name = "flpClients";
            flpClients.Size = new Size(206, 352);
            flpClients.TabIndex = 1;
            flpClients.WrapContents = false;
            // 
            // lblClientCount
            // 
            lblClientCount.Dock = DockStyle.Top;
            lblClientCount.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClientCount.ForeColor = Color.White;
            lblClientCount.Location = new Point(12, 12);
            lblClientCount.Name = "lblClientCount";
            lblClientCount.Size = new Size(206, 40);
            lblClientCount.TabIndex = 0;
            lblClientCount.Text = "CLIENTS — 0";
            lblClientCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tblStats
            // 
            tblStats.BackColor = Color.White;
            tblStats.ColumnCount = 4;
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.Controls.Add(lblClients, 0, 0);
            tblStats.Controls.Add(lblRooms, 1, 0);
            tblStats.Controls.Add(lblMessages, 2, 0);
            tblStats.Controls.Add(lblUptime, 3, 0);
            tblStats.Dock = DockStyle.Bottom;
            tblStats.Location = new Point(16, 432);
            tblStats.Name = "tblStats";
            tblStats.Padding = new Padding(0, 12, 0, 0);
            tblStats.RowCount = 1;
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStats.Size = new Size(868, 52);
            tblStats.TabIndex = 4;
            // 
            // lblClients
            // 
            lblClients.BackColor = Color.FromArgb(245, 250, 255);
            lblClients.Dock = DockStyle.Fill;
            lblClients.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClients.ForeColor = Color.FromArgb(0, 65, 130);
            lblClients.Location = new Point(3, 12);
            lblClients.Name = "lblClients";
            lblClients.Size = new Size(211, 40);
            lblClients.TabIndex = 0;
            lblClients.Text = "Clients: 0";
            lblClients.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRooms
            // 
            lblRooms.BackColor = Color.FromArgb(245, 250, 255);
            lblRooms.Dock = DockStyle.Fill;
            lblRooms.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRooms.ForeColor = Color.FromArgb(0, 65, 130);
            lblRooms.Location = new Point(220, 12);
            lblRooms.Name = "lblRooms";
            lblRooms.Size = new Size(211, 40);
            lblRooms.TabIndex = 1;
            lblRooms.Text = "Rooms: 0";
            lblRooms.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMessages
            // 
            lblMessages.BackColor = Color.FromArgb(245, 250, 255);
            lblMessages.Dock = DockStyle.Fill;
            lblMessages.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMessages.ForeColor = Color.FromArgb(0, 65, 130);
            lblMessages.Location = new Point(437, 12);
            lblMessages.Name = "lblMessages";
            lblMessages.Size = new Size(211, 40);
            lblMessages.TabIndex = 2;
            lblMessages.Text = "Messages: 0";
            lblMessages.TextAlign = ContentAlignment.MiddleCenter;
            lblMessages.Click += lblMessages_Click;
            // 
            // lblUptime
            // 
            lblUptime.BackColor = Color.FromArgb(245, 250, 255);
            lblUptime.Dock = DockStyle.Fill;
            lblUptime.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUptime.ForeColor = Color.FromArgb(0, 65, 130);
            lblUptime.Location = new Point(654, 12);
            lblUptime.Name = "lblUptime";
            lblUptime.Size = new Size(211, 40);
            lblUptime.TabIndex = 3;
            lblUptime.Text = "Uptime: 00:00";
            lblUptime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 560);
            Controls.Add(pnlMain);
            Controls.Add(tblToolbar);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(820, 500);
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat Server";
            Load += ServerForm_Load;
            tblToolbar.ResumeLayout(false);
            tblToolbar.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlLogContainer.ResumeLayout(false);
            pnlLogHeader.ResumeLayout(false);
            pnlLogHeader.PerformLayout();
            pnlClients.ResumeLayout(false);
            tblStats.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TableLayoutPanel tblToolbar;
        private Button btnStart;
        private Button btnStop;
        private Label lblStatus;
        private Button btnClearLog;
        private RichTextBox rtbLog;
        private TableLayoutPanel tblStats;
        private Panel pnlClients;
        private Label lblClientCount;
        private FlowLayoutPanel flpClients;
        private Label lblClients;
        private Label lblRooms;
        private Label lblMessages;
        private Label lblUptime;
        private Button btnSettings2;
        private Panel pnlMain;
        private Panel pnlLogContainer;
        private Panel pnlLogHeader;
        private Label lblLogTitle;
    }
}
