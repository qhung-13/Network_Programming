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
            pnlLeft = new Panel();
            panel3 = new Panel();
            panel8 = new Panel();
            lblstudy = new Label();
            panel7 = new Panel();
            label2 = new Label();
            panel6 = new Panel();
            lblrandom = new Label();
            lblChatRoom = new Label();
            panel5 = new Panel();
            lblgeneral = new Label();
            btnCreateNewRoom = new Button();
            panel4 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblOnline = new Label();
            panel2 = new Panel();
            lblChamXanh = new Label();
            lblNameOnline = new Label();
            lblQH = new Label();
            pnlMain = new Panel();
            panel12 = new Panel();
            btnSend = new Button();
            textBox1 = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            btnSettings1 = new Button();
            lblSLOnline = new Label();
            label1 = new Label();
            pnlLeft.SuspendLayout();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            pnlMain.SuspendLayout();
            panel12.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(13, 71, 161);
            pnlLeft.Controls.Add(panel3);
            pnlLeft.Controls.Add(btnCreateNewRoom);
            pnlLeft.Controls.Add(panel4);
            pnlLeft.Controls.Add(panel2);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(260, 560);
            pnlLeft.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(25, 118, 210);
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(lblChatRoom);
            panel3.Controls.Add(panel5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 72);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(16, 18, 16, 12);
            panel3.Size = new Size(260, 258);
            panel3.TabIndex = 6;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel8.BackColor = Color.FromArgb(25, 118, 210);
            panel8.Controls.Add(lblstudy);
            panel8.Location = new Point(16, 174);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(14, 8, 10, 8);
            panel8.Size = new Size(228, 38);
            panel8.TabIndex = 4;
            // 
            // lblstudy
            // 
            lblstudy.AutoSize = true;
            lblstudy.Dock = DockStyle.Left;
            lblstudy.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblstudy.ForeColor = Color.White;
            lblstudy.Location = new Point(14, 8);
            lblstudy.Name = "lblstudy";
            lblstudy.Size = new Size(61, 19);
            lblstudy.TabIndex = 0;
            lblstudy.Text = "# study";
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel7.BackColor = Color.FromArgb(25, 118, 210);
            panel7.Controls.Add(label2);
            panel7.Location = new Point(16, 130);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(14, 8, 10, 8);
            panel7.Size = new Size(228, 38);
            panel7.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 8);
            label2.Name = "label2";
            label2.Size = new Size(72, 19);
            label2.TabIndex = 0;
            label2.Text = "# gaming";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.BackColor = Color.FromArgb(25, 118, 210);
            panel6.Controls.Add(lblrandom);
            panel6.Location = new Point(16, 86);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(14, 8, 10, 8);
            panel6.Size = new Size(228, 38);
            panel6.TabIndex = 2;
            // 
            // lblrandom
            // 
            lblrandom.AutoSize = true;
            lblrandom.Dock = DockStyle.Left;
            lblrandom.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblrandom.ForeColor = Color.White;
            lblrandom.Location = new Point(14, 8);
            lblrandom.Name = "lblrandom";
            lblrandom.Size = new Size(77, 19);
            lblrandom.TabIndex = 0;
            lblrandom.Text = "# random";
            // 
            // lblChatRoom
            // 
            lblChatRoom.AutoSize = true;
            lblChatRoom.Dock = DockStyle.Top;
            lblChatRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChatRoom.ForeColor = Color.FromArgb(232, 240, 254);
            lblChatRoom.Location = new Point(16, 18);
            lblChatRoom.Name = "lblChatRoom";
            lblChatRoom.Padding = new Padding(0, 0, 0, 14);
            lblChatRoom.Size = new Size(90, 33);
            lblChatRoom.TabIndex = 1;
            lblChatRoom.Text = "Chat Room";
            lblChatRoom.Click += lblChatRoom_Click;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.White;
            panel5.Controls.Add(lblgeneral);
            panel5.Location = new Point(16, 42);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(14, 8, 10, 8);
            panel5.Size = new Size(228, 38);
            panel5.TabIndex = 0;
            panel5.Paint += panel5_Paint;
            // 
            // lblgeneral
            // 
            lblgeneral.AutoSize = true;
            lblgeneral.Dock = DockStyle.Left;
            lblgeneral.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblgeneral.ForeColor = Color.FromArgb(25, 118, 210);
            lblgeneral.Location = new Point(14, 8);
            lblgeneral.Name = "lblgeneral";
            lblgeneral.Size = new Size(76, 19);
            lblgeneral.TabIndex = 0;
            lblgeneral.Text = "# general";
            // 
            // btnCreateNewRoom
            // 
            btnCreateNewRoom.BackColor = Color.White;
            btnCreateNewRoom.Dock = DockStyle.Bottom;
            btnCreateNewRoom.FlatAppearance.BorderColor = Color.FromArgb(187, 222, 251);
            btnCreateNewRoom.FlatAppearance.BorderSize = 1;
            btnCreateNewRoom.FlatStyle = FlatStyle.Flat;
            btnCreateNewRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateNewRoom.ForeColor = Color.FromArgb(25, 118, 210);
            btnCreateNewRoom.Location = new Point(0, 330);
            btnCreateNewRoom.Name = "btnCreateNewRoom";
            btnCreateNewRoom.Size = new Size(260, 54);
            btnCreateNewRoom.TabIndex = 5;
            btnCreateNewRoom.Text = "+ Create New Room";
            btnCreateNewRoom.UseVisualStyleBackColor = false;
            btnCreateNewRoom.Click += btnCreateNewRoom_Click_1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(13, 71, 161);
            panel4.Controls.Add(flowLayoutPanel2);
            panel4.Controls.Add(lblOnline);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 384);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(16, 14, 16, 12);
            panel4.Size = new Size(260, 176);
            panel4.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flowLayoutPanel2.ForeColor = Color.White;
            flowLayoutPanel2.Location = new Point(16, 37);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(228, 127);
            flowLayoutPanel2.TabIndex = 1;
            flowLayoutPanel2.WrapContents = false;
            // 
            // lblOnline
            // 
            lblOnline.AutoSize = true;
            lblOnline.Dock = DockStyle.Top;
            lblOnline.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOnline.ForeColor = Color.FromArgb(232, 240, 254);
            lblOnline.Location = new Point(16, 14);
            lblOnline.Name = "lblOnline";
            lblOnline.Padding = new Padding(0, 0, 0, 4);
            lblOnline.Size = new Size(54, 23);
            lblOnline.TabIndex = 0;
            lblOnline.Text = "Online";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(13, 71, 161);
            panel2.Controls.Add(lblChamXanh);
            panel2.Controls.Add(lblNameOnline);
            panel2.Controls.Add(lblQH);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(16, 14, 16, 14);
            panel2.Size = new Size(260, 72);
            panel2.TabIndex = 0;
            // 
            // lblChamXanh
            // 
            lblChamXanh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblChamXanh.AutoSize = true;
            lblChamXanh.BackColor = Color.FromArgb(13, 71, 161);
            lblChamXanh.Font = new Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChamXanh.ForeColor = Color.LimeGreen;
            lblChamXanh.Location = new Point(226, 28);
            lblChamXanh.Name = "lblChamXanh";
            lblChamXanh.Size = new Size(15, 12);
            lblChamXanh.TabIndex = 2;
            lblChamXanh.Text = "●";
            // 
            // lblNameOnline
            // 
            lblNameOnline.AutoSize = true;
            lblNameOnline.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameOnline.ForeColor = Color.White;
            lblNameOnline.Location = new Point(68, 24);
            lblNameOnline.Name = "lblNameOnline";
            lblNameOnline.Size = new Size(82, 19);
            lblNameOnline.TabIndex = 1;
            lblNameOnline.Text = "Quoc Hung";
            lblNameOnline.Click += lblNameOnline_Click;
            // 
            // lblQH
            // 
            lblQH.BackColor = Color.White;
            lblQH.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQH.ForeColor = Color.FromArgb(25, 118, 210);
            lblQH.Location = new Point(16, 16);
            lblQH.Name = "lblQH";
            lblQH.Size = new Size(40, 40);
            lblQH.TabIndex = 0;
            lblQH.Text = "QH";
            lblQH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(flowLayoutPanel1);
            pnlMain.Controls.Add(panel12);
            pnlMain.Controls.Add(panel1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(260, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(640, 560);
            pnlMain.TabIndex = 4;
            // 
            // panel12
            // 
            panel12.BackColor = Color.White;
            panel12.Controls.Add(btnSend);
            panel12.Controls.Add(textBox1);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 492);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(18, 14, 18, 14);
            panel12.Size = new Size(640, 68);
            panel12.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSend.BackColor = Color.FromArgb(25, 118, 210);
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(512, 14);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(110, 38);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.FromArgb(33, 33, 33);
            textBox1.Location = new Point(18, 19);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Type a message...";
            textBox1.Size = new Size(480, 25);
            textBox1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(248, 250, 252);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 56);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20, 18, 20, 18);
            flowLayoutPanel1.Size = new Size(640, 436);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnSettings1);
            panel1.Controls.Add(lblSLOnline);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20, 12, 18, 12);
            panel1.Size = new Size(640, 56);
            panel1.TabIndex = 3;
            // 
            // btnSettings1
            // 
            btnSettings1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings1.BackColor = Color.White;
            btnSettings1.FlatAppearance.BorderColor = Color.FromArgb(187, 222, 251);
            btnSettings1.FlatStyle = FlatStyle.Flat;
            btnSettings1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSettings1.ForeColor = Color.FromArgb(25, 118, 210);
            btnSettings1.Location = new Point(520, 11);
            btnSettings1.Name = "btnSettings1";
            btnSettings1.Size = new Size(102, 34);
            btnSettings1.TabIndex = 2;
            btnSettings1.Text = "Settings";
            btnSettings1.UseVisualStyleBackColor = false;
            // 
            // lblSLOnline
            // 
            lblSLOnline.AutoSize = true;
            lblSLOnline.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSLOnline.ForeColor = Color.FromArgb(117, 117, 117);
            lblSLOnline.Location = new Point(110, 20);
            lblSLOnline.Name = "lblSLOnline";
            lblSLOnline.Size = new Size(87, 15);
            lblSLOnline.TabIndex = 1;
            lblSLOnline.Text = "- 4 users online";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(25, 118, 210);
            label1.Location = new Point(20, 17);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "# general";
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 560);
            Controls.Add(pnlMain);
            Controls.Add(pnlLeft);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(33, 33, 33);
            MinimumSize = new Size(900, 560);
            Name = "ChatForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChatApp";
            Load += ChatForm_Load;
            pnlLeft.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlMain.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlLeft;
        private Panel panel2;
        private Label lblQH;
        private Label lblChamXanh;
        private Label lblNameOnline;
        private Panel panel4;
        private Panel panel12;
        private TextBox textBox1;
        private Button btnSend;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label lblOnline;
        private Button btnCreateNewRoom;
        private Panel panel1;
        private Panel panel3;
        private Label lblChatRoom;
        private Panel panel5;
        private Panel panel7;
        private Label label2;
        private Panel panel6;
        private Label lblrandom;
        private Label lblgeneral;
        private Panel panel8;
        private Label lblstudy;
        private Label label1;
        private Label lblSLOnline;
        private Button btnSettings1;
        private Panel pnlMain;
    }
}
