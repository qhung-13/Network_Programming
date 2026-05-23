namespace ChatClient.Forms
{
    partial class ChatForm
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
            splitMain = new SplitContainer();
            lbRooms = new ListBox();
            btnCreateRoom = new Button();
            pnlUser = new Panel();
            lblUsername = new Label();
            lblAvatar = new Label();
            splitRight = new SplitContainer();
            rtbChat = new RichTextBox();
            pnlEmoji = new Panel();
            pnlInput = new Panel();
            txtMessage = new TextBox();
            btnSend = new Button();
            lbUsers = new ListBox();
            btnLeave = new Button();
            lblTHANHVIEN = new Label();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitRight).BeginInit();
            splitRight.Panel1.SuspendLayout();
            splitRight.Panel2.SuspendLayout();
            splitRight.SuspendLayout();
            pnlInput.SuspendLayout();
            SuspendLayout();
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 0);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(lbRooms);
            splitMain.Panel1.Controls.Add(btnCreateRoom);
            splitMain.Panel1.Controls.Add(pnlUser);
            splitMain.Panel1.Paint += splitContainer1_Panel1_Paint_1;
            splitMain.Panel1MinSize = 180;
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(splitRight);
            splitMain.Panel2MinSize = 400;
            splitMain.Size = new Size(773, 418);
            splitMain.SplitterDistance = 209;
            splitMain.TabIndex = 0;
            // 
            // lbRooms
            // 
            lbRooms.BorderStyle = BorderStyle.None;
            lbRooms.Dock = DockStyle.Fill;
            lbRooms.DrawMode = DrawMode.OwnerDrawFixed;
            lbRooms.FormattingEnabled = true;
            lbRooms.ItemHeight = 40;
            lbRooms.Location = new Point(0, 56);
            lbRooms.Name = "lbRooms";
            lbRooms.Size = new Size(209, 326);
            lbRooms.TabIndex = 2;
            // 
            // btnCreateRoom
            // 
            btnCreateRoom.Dock = DockStyle.Bottom;
            btnCreateRoom.FlatAppearance.BorderSize = 0;
            btnCreateRoom.FlatStyle = FlatStyle.Flat;
            btnCreateRoom.Location = new Point(0, 382);
            btnCreateRoom.Name = "btnCreateRoom";
            btnCreateRoom.Size = new Size(209, 36);
            btnCreateRoom.TabIndex = 1;
            btnCreateRoom.Text = "+ Tao phong moi\n";
            btnCreateRoom.UseVisualStyleBackColor = true;
            // 
            // pnlUser
            // 
            pnlUser.BackColor = Color.FromArgb(192, 192, 255);
            pnlUser.Controls.Add(lblUsername);
            pnlUser.Controls.Add(lblAvatar);
            pnlUser.Dock = DockStyle.Top;
            pnlUser.Location = new Point(0, 0);
            pnlUser.Name = "pnlUser";
            pnlUser.Size = new Size(209, 56);
            pnlUser.TabIndex = 0;
            pnlUser.Paint += pnlUser_Paint;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(58, 18);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(109, 25);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Quoc Hung";
            // 
            // lblAvatar
            // 
            lblAvatar.AutoSize = true;
            lblAvatar.Location = new Point(12, 18);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(40, 25);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "QH";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitRight
            // 
            splitRight.Dock = DockStyle.Fill;
            splitRight.Location = new Point(0, 0);
            splitRight.Name = "splitRight";
            // 
            // splitRight.Panel1
            // 
            splitRight.Panel1.Controls.Add(rtbChat);
            splitRight.Panel1.Controls.Add(pnlEmoji);
            splitRight.Panel1.Controls.Add(pnlInput);
            splitRight.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitRight.Panel2
            // 
            splitRight.Panel2.Controls.Add(lbUsers);
            splitRight.Panel2.Controls.Add(btnLeave);
            splitRight.Panel2.Controls.Add(lblTHANHVIEN);
            splitRight.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitRight.Panel2MinSize = 180;
            splitRight.Size = new Size(560, 418);
            splitRight.SplitterDistance = 356;
            splitRight.TabIndex = 0;
            // 
            // rtbChat
            // 
            rtbChat.BorderStyle = BorderStyle.None;
            rtbChat.Dock = DockStyle.Fill;
            rtbChat.ForeColor = Color.Black;
            rtbChat.Location = new Point(0, 0);
            rtbChat.Name = "rtbChat";
            rtbChat.ReadOnly = true;
            rtbChat.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbChat.Size = new Size(356, 347);
            rtbChat.TabIndex = 2;
            rtbChat.Text = "";
            rtbChat.TextChanged += rtbChat_TextChanged;
            // 
            // pnlEmoji
            // 
            pnlEmoji.Dock = DockStyle.Bottom;
            pnlEmoji.Location = new Point(0, 347);
            pnlEmoji.Name = "pnlEmoji";
            pnlEmoji.Size = new Size(356, 36);
            pnlEmoji.TabIndex = 1;
            // 
            // pnlInput
            // 
            pnlInput.Controls.Add(txtMessage);
            pnlInput.Controls.Add(btnSend);
            pnlInput.Dock = DockStyle.Bottom;
            pnlInput.Location = new Point(0, 383);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(356, 35);
            pnlInput.TabIndex = 0;
            pnlInput.Paint += pnlInput_Paint;
            // 
            // txtMessage
            // 
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
            txtMessage.Dock = DockStyle.Fill;
            txtMessage.ForeColor = Color.Gray;
            txtMessage.Location = new Point(0, 0);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(276, 31);
            txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Dock = DockStyle.Right;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.Blue;
            btnSend.Location = new Point(276, 0);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(80, 35);
            btnSend.TabIndex = 0;
            btnSend.Text = "Gui";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // lbUsers
            // 
            lbUsers.BorderStyle = BorderStyle.None;
            lbUsers.Dock = DockStyle.Fill;
            lbUsers.FormattingEnabled = true;
            lbUsers.Location = new Point(0, 25);
            lbUsers.Name = "lbUsers";
            lbUsers.Size = new Size(200, 359);
            lbUsers.TabIndex = 2;
            lbUsers.DrawItem += lbUsers_DrawItem;
            // 
            // btnLeave
            // 
            btnLeave.BackColor = Color.FromArgb(128, 128, 255);
            btnLeave.Dock = DockStyle.Bottom;
            btnLeave.FlatStyle = FlatStyle.Flat;
            btnLeave.ForeColor = Color.White;
            btnLeave.Location = new Point(0, 384);
            btnLeave.Name = "btnLeave";
            btnLeave.Size = new Size(200, 34);
            btnLeave.TabIndex = 1;
            btnLeave.Text = "Roi phong";
            btnLeave.UseVisualStyleBackColor = false;
            // 
            // lblTHANHVIEN
            // 
            lblTHANHVIEN.AutoSize = true;
            lblTHANHVIEN.Dock = DockStyle.Top;
            lblTHANHVIEN.ForeColor = Color.FromArgb(128, 128, 255);
            lblTHANHVIEN.Location = new Point(0, 0);
            lblTHANHVIEN.Name = "lblTHANHVIEN";
            lblTHANHVIEN.Size = new Size(125, 25);
            lblTHANHVIEN.TabIndex = 0;
            lblTHANHVIEN.Text = "THANH VIEN";
            lblTHANHVIEN.Click += label1_Click;
            // 
            // ChatForm
            // 
            ClientSize = new Size(773, 418);
            Controls.Add(splitMain);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "ChatForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChatApp — Quoc Hung";
            Load += ChatForm_Load;
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            pnlUser.ResumeLayout(false);
            pnlUser.PerformLayout();
            splitRight.Panel1.ResumeLayout(false);
            splitRight.Panel2.ResumeLayout(false);
            splitRight.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitRight).EndInit();
            splitRight.ResumeLayout(false);
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ResumeLayout(false);
        }
        private SplitContainer splitMain;
        private SplitContainer splitRight;
        private Panel pnlUser;
        private Label lblAvatar;
        private Label lblUsername;
        private Button btnCreateRoom;
        private ListBox lbRooms;
        private Panel pnlInput;
        private TextBox txtMessage;
        private Button btnSend;
        private RichTextBox rtbChat;
        private Panel pnlEmoji;
        private Label lblTHANHVIEN;
        private ListBox lbUsers;
        private Button btnLeave;
    }
}