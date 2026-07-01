namespace ChatServer.Forms
{
    partial class ServerForm
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
            tblToolbar = new TableLayoutPanel();
            btnStart = new Button();
            btnStop = new Button();
            btnClearLog = new Button();
            lblStatus = new Label();
            btnSettings2 = new Button();
            tblMain = new TableLayoutPanel();
            pnlLogContainer = new Panel();
            rtbLog = new RichTextBox();
            pnlLogHeader = new Panel();
            lblLogTitle = new Label();
            pnlClients = new Panel();
            flpClients = new FlowLayoutPanel();
            lblClientCount = new Label();
            tblStats = new TableLayoutPanel();
            lblClients = new Label();
            lblRooms = new Label();
            lblMessages = new Label();
            lblUptime = new Label();
            tblToolbar.SuspendLayout();
            tblMain.SuspendLayout();
            pnlLogContainer.SuspendLayout();
            pnlLogHeader.SuspendLayout();
            pnlClients.SuspendLayout();
            tblStats.SuspendLayout();
            SuspendLayout();
            // 
            // tblToolbar
            // 
            tblToolbar.BackColor = Color.Blue;
            tblToolbar.ColumnCount = 6;
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 16F));
            tblToolbar.Controls.Add(btnStart, 0, 0);
            tblToolbar.Controls.Add(btnStop, 1, 0);
            tblToolbar.Controls.Add(btnClearLog, 2, 0);
            tblToolbar.Controls.Add(lblStatus, 3, 0);
            tblToolbar.Controls.Add(btnSettings2, 4, 0);
            tblToolbar.Dock = DockStyle.Top;
            tblToolbar.Location = new Point(0, 0);
            tblToolbar.Name = "tblToolbar";
            tblToolbar.Padding = new Padding(10, 8, 10, 8);
            tblToolbar.RowCount = 1;
            tblToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblToolbar.Size = new Size(900, 58);
            tblToolbar.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.White;
            btnStart.Dock = DockStyle.Fill;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.Blue;
            btnStart.Location = new Point(13, 11);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(104, 36);
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
            btnStop.ForeColor = Color.Blue;
            btnStop.Location = new Point(123, 11);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(104, 36);
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
            btnClearLog.ForeColor = Color.DimGray;
            btnClearLog.Location = new Point(233, 11);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(144, 36);
            btnClearLog.TabIndex = 2;
            btnClearLog.Text = "🗑 Clear Log";
            btnClearLog.UseVisualStyleBackColor = false;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(383, 8);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(378, 42);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "● Offline";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSettings2
            // 
            btnSettings2.BackColor = Color.White;
            btnSettings2.Dock = DockStyle.Fill;
            btnSettings2.FlatAppearance.BorderSize = 0;
            btnSettings2.FlatStyle = FlatStyle.Flat;
            btnSettings2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSettings2.ForeColor = Color.Blue;
            btnSettings2.Location = new Point(767, 11);
            btnSettings2.Name = "btnSettings2";
            btnSettings2.Size = new Size(114, 36);
            btnSettings2.TabIndex = 4;
            btnSettings2.Text = "⚙ Settings";
            btnSettings2.UseVisualStyleBackColor = false;
            btnSettings2.Click += btnSettings2_Click;
            // 
            // tblMain
            // 
            tblMain.BackColor = Color.White;
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 230F));
            tblMain.Controls.Add(pnlLogContainer, 0, 0);
            tblMain.Controls.Add(pnlClients, 1, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 58);
            tblMain.Name = "tblMain";
            tblMain.Padding = new Padding(12);
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(900, 436);
            tblMain.TabIndex = 1;
            // 
            // pnlLogContainer
            // 
            pnlLogContainer.BackColor = Color.White;
            pnlLogContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlLogContainer.Controls.Add(rtbLog);
            pnlLogContainer.Controls.Add(pnlLogHeader);
            pnlLogContainer.Dock = DockStyle.Fill;
            pnlLogContainer.Location = new Point(15, 15);
            pnlLogContainer.Name = "pnlLogContainer";
            pnlLogContainer.Size = new Size(640, 406);
            pnlLogContainer.TabIndex = 0;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.White;
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbLog.ForeColor = Color.Black;
            rtbLog.Location = new Point(0, 42);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbLog.Size = new Size(638, 362);
            rtbLog.TabIndex = 1;
            rtbLog.Text = "";
            rtbLog.TextChanged += rtbLog_TextChanged;
            // 
            // pnlLogHeader
            // 
            pnlLogHeader.BackColor = Color.WhiteSmoke;
            pnlLogHeader.Controls.Add(lblLogTitle);
            pnlLogHeader.Dock = DockStyle.Top;
            pnlLogHeader.Location = new Point(0, 0);
            pnlLogHeader.Name = "pnlLogHeader";
            pnlLogHeader.Size = new Size(638, 42);
            pnlLogHeader.TabIndex = 0;
            // 
            // lblLogTitle
            // 
            lblLogTitle.Dock = DockStyle.Fill;
            lblLogTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogTitle.ForeColor = Color.Blue;
            lblLogTitle.Location = new Point(0, 0);
            lblLogTitle.Name = "lblLogTitle";
            lblLogTitle.Padding = new Padding(14, 0, 0, 0);
            lblLogTitle.Size = new Size(638, 42);
            lblLogTitle.TabIndex = 0;
            lblLogTitle.Text = "Server Log";
            lblLogTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlClients
            // 
            pnlClients.BackColor = Color.Blue;
            pnlClients.Controls.Add(flpClients);
            pnlClients.Controls.Add(lblClientCount);
            pnlClients.Dock = DockStyle.Fill;
            pnlClients.Location = new Point(661, 15);
            pnlClients.Name = "pnlClients";
            pnlClients.Size = new Size(224, 406);
            pnlClients.TabIndex = 1;
            // 
            // flpClients
            // 
            flpClients.AutoScroll = true;
            flpClients.BackColor = Color.Blue;
            flpClients.Dock = DockStyle.Fill;
            flpClients.FlowDirection = FlowDirection.TopDown;
            flpClients.ForeColor = Color.White;
            flpClients.Location = new Point(0, 46);
            flpClients.Name = "flpClients";
            flpClients.Padding = new Padding(6);
            flpClients.Size = new Size(224, 360);
            flpClients.TabIndex = 1;
            flpClients.WrapContents = false;
            // 
            // lblClientCount
            // 
            lblClientCount.Dock = DockStyle.Top;
            lblClientCount.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClientCount.ForeColor = Color.White;
            lblClientCount.Location = new Point(0, 0);
            lblClientCount.Name = "lblClientCount";
            lblClientCount.Size = new Size(224, 46);
            lblClientCount.TabIndex = 0;
            lblClientCount.Text = "CLIENTS — 0";
            lblClientCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblStats
            // 
            tblStats.BackColor = Color.WhiteSmoke;
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
            tblStats.Location = new Point(0, 494);
            tblStats.Name = "tblStats";
            tblStats.RowCount = 1;
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStats.Size = new Size(900, 56);
            tblStats.TabIndex = 2;
            // 
            // lblClients
            // 
            lblClients.Dock = DockStyle.Fill;
            lblClients.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClients.ForeColor = Color.Navy;
            lblClients.Location = new Point(3, 0);
            lblClients.Name = "lblClients";
            lblClients.Size = new Size(219, 56);
            lblClients.TabIndex = 0;
            lblClients.Text = "Clients: 0";
            lblClients.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRooms
            // 
            lblRooms.Dock = DockStyle.Fill;
            lblRooms.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRooms.ForeColor = Color.Navy;
            lblRooms.Location = new Point(228, 0);
            lblRooms.Name = "lblRooms";
            lblRooms.Size = new Size(219, 56);
            lblRooms.TabIndex = 1;
            lblRooms.Text = "Rooms: 0";
            lblRooms.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMessages
            // 
            lblMessages.Dock = DockStyle.Fill;
            lblMessages.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMessages.ForeColor = Color.Navy;
            lblMessages.Location = new Point(453, 0);
            lblMessages.Name = "lblMessages";
            lblMessages.Size = new Size(219, 56);
            lblMessages.TabIndex = 2;
            lblMessages.Text = "Messages: 0";
            lblMessages.TextAlign = ContentAlignment.MiddleCenter;
            lblMessages.Click += lblMessages_Click;
            // 
            // lblUptime
            // 
            lblUptime.Dock = DockStyle.Fill;
            lblUptime.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUptime.ForeColor = Color.Navy;
            lblUptime.Location = new Point(678, 0);
            lblUptime.Name = "lblUptime";
            lblUptime.Size = new Size(219, 56);
            lblUptime.TabIndex = 3;
            lblUptime.Text = "Uptime: 00:00:00";
            lblUptime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 550);
            Controls.Add(tblMain);
            Controls.Add(tblToolbar);
            Controls.Add(tblStats);
            MinimumSize = new Size(820, 500);
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat Server";
            Load += ServerForm_Load;
            tblToolbar.ResumeLayout(false);
            tblMain.ResumeLayout(false);
            pnlLogContainer.ResumeLayout(false);
            pnlLogHeader.ResumeLayout(false);
            pnlClients.ResumeLayout(false);
            tblStats.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TableLayoutPanel tblToolbar;
        private Button btnStart;
        private Button btnStop;
        private Button btnClearLog;
        private Label lblStatus;
        private Button btnSettings2;
        private TableLayoutPanel tblMain;
        private Panel pnlLogContainer;
        private Panel pnlLogHeader;
        private Label lblLogTitle;
        private RichTextBox rtbLog;
        private Panel pnlClients;
        private Label lblClientCount;
        private FlowLayoutPanel flpClients;
        private TableLayoutPanel tblStats;
        private Label lblClients;
        private Label lblRooms;
        private Label lblMessages;
        private Label lblUptime;
    }
}