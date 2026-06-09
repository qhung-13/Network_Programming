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
            panel12.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(panel3);
            pnlLeft.Controls.Add(btnCreateNewRoom);
            pnlLeft.Controls.Add(panel4);
            pnlLeft.Controls.Add(panel2);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(244, 422);
            pnlLeft.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.HotTrack;
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(lblChatRoom);
            panel3.Controls.Add(panel5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 48);
            panel3.Name = "panel3";
            panel3.Size = new Size(244, 166);
            panel3.TabIndex = 6;
            // 
            // panel8
            // 
            panel8.Controls.Add(lblstudy);
            panel8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel8.Location = new Point(6, 131);
            panel8.Name = "panel8";
            panel8.Size = new Size(232, 29);
            panel8.TabIndex = 4;
            // 
            // lblstudy
            // 
            lblstudy.AutoSize = true;
            lblstudy.Dock = DockStyle.Left;
            lblstudy.Location = new Point(0, 0);
            lblstudy.Name = "lblstudy";
            lblstudy.Size = new Size(57, 20);
            lblstudy.TabIndex = 0;
            lblstudy.Text = "# study";
            // 
            // panel7
            // 
            panel7.Controls.Add(label2);
            panel7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel7.Location = new Point(6, 96);
            panel7.Name = "panel7";
            panel7.Size = new Size(232, 29);
            panel7.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 0;
            label2.Text = "# gaming";
            // 
            // panel6
            // 
            panel6.Controls.Add(lblrandom);
            panel6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel6.Location = new Point(6, 61);
            panel6.Name = "panel6";
            panel6.Size = new Size(232, 29);
            panel6.TabIndex = 2;
            // 
            // lblrandom
            // 
            lblrandom.AutoSize = true;
            lblrandom.Dock = DockStyle.Left;
            lblrandom.Location = new Point(0, 0);
            lblrandom.Name = "lblrandom";
            lblrandom.Size = new Size(74, 20);
            lblrandom.TabIndex = 0;
            lblrandom.Text = "# random";
            // 
            // lblChatRoom
            // 
            lblChatRoom.AutoSize = true;
            lblChatRoom.Dock = DockStyle.Top;
            lblChatRoom.Location = new Point(0, 0);
            lblChatRoom.Name = "lblChatRoom";
            lblChatRoom.Size = new Size(87, 20);
            lblChatRoom.TabIndex = 1;
            lblChatRoom.Text = "Chat Room";
            lblChatRoom.Click += lblChatRoom_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(lblgeneral);
            panel5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel5.Location = new Point(9, 26);
            panel5.Name = "panel5";
            panel5.Size = new Size(232, 29);
            panel5.TabIndex = 0;
            panel5.Paint += panel5_Paint;
            // 
            // lblgeneral
            // 
            lblgeneral.AutoSize = true;
            lblgeneral.Dock = DockStyle.Left;
            lblgeneral.Location = new Point(0, 0);
            lblgeneral.Name = "lblgeneral";
            lblgeneral.Size = new Size(72, 20);
            lblgeneral.TabIndex = 0;
            lblgeneral.Text = "# general";
            // 
            // btnCreateNewRoom
            // 
            btnCreateNewRoom.BackColor = Color.DodgerBlue;
            btnCreateNewRoom.Dock = DockStyle.Bottom;
            btnCreateNewRoom.FlatStyle = FlatStyle.Flat;
            btnCreateNewRoom.Location = new Point(0, 214);
            btnCreateNewRoom.Name = "btnCreateNewRoom";
            btnCreateNewRoom.Size = new Size(244, 45);
            btnCreateNewRoom.TabIndex = 5;
            btnCreateNewRoom.Text = "Create New Room";
            btnCreateNewRoom.UseVisualStyleBackColor = false;
            btnCreateNewRoom.Click += btnCreateNewRoom_Click_1;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.HotTrack;
            panel4.Controls.Add(flowLayoutPanel2);
            panel4.Controls.Add(lblOnline);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 259);
            panel4.Name = "panel4";
            panel4.Size = new Size(244, 163);
            panel4.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flowLayoutPanel2.Location = new Point(0, 20);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(244, 143);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // lblOnline
            // 
            lblOnline.AutoSize = true;
            lblOnline.Dock = DockStyle.Top;
            lblOnline.Location = new Point(0, 0);
            lblOnline.Name = "lblOnline";
            lblOnline.Size = new Size(54, 20);
            lblOnline.TabIndex = 0;
            lblOnline.Text = "Online";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Blue;
            panel2.Controls.Add(lblChamXanh);
            panel2.Controls.Add(lblNameOnline);
            panel2.Controls.Add(lblQH);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(244, 48);
            panel2.TabIndex = 0;
            // 
            // lblChamXanh
            // 
            lblChamXanh.AutoSize = true;
            lblChamXanh.BackColor = Color.Blue;
            lblChamXanh.Font = new Font("Segoe UI", 4F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChamXanh.ForeColor = Color.Lime;
            lblChamXanh.Location = new Point(214, 20);
            lblChamXanh.Name = "lblChamXanh";
            lblChamXanh.Size = new Size(16, 10);
            lblChamXanh.TabIndex = 2;
            lblChamXanh.Text = "\U0001f7e2";
            // 
            // lblNameOnline
            // 
            lblNameOnline.AutoSize = true;
            lblNameOnline.Location = new Point(58, 9);
            lblNameOnline.Name = "lblNameOnline";
            lblNameOnline.Size = new Size(87, 20);
            lblNameOnline.TabIndex = 1;
            lblNameOnline.Text = "Quoc Hung";
            lblNameOnline.Click += lblNameOnline_Click;
            // 
            // lblQH
            // 
            lblQH.AutoSize = true;
            lblQH.BackColor = Color.DodgerBlue;
            lblQH.Location = new Point(12, 9);
            lblQH.Name = "lblQH";
            lblQH.Size = new Size(31, 20);
            lblQH.TabIndex = 0;
            lblQH.Text = "QH";
            // 
            // panel12
            // 
            panel12.BackColor = Color.DodgerBlue;
            panel12.Controls.Add(btnSend);
            panel12.Controls.Add(textBox1);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(244, 372);
            panel12.Name = "panel12";
            panel12.Size = new Size(596, 50);
            panel12.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(463, 7);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(112, 34);
            btnSend.TabIndex = 2;
            btnSend.Text = " Send";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 7);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(431, 27);
            textBox1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(244, 38);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(596, 334);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnSettings1);
            panel1.Controls.Add(lblSLOnline);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(244, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(596, 42);
            panel1.TabIndex = 3;
            // 
            // btnSettings1
            // 
            btnSettings1.BackColor = Color.Transparent;
            btnSettings1.FlatStyle = FlatStyle.Flat;
            btnSettings1.ForeColor = Color.DimGray;
            btnSettings1.Location = new Point(495, 3);
            btnSettings1.Name = "btnSettings1";
            btnSettings1.Size = new Size(98, 34);
            btnSettings1.TabIndex = 2;
            btnSettings1.Text = "Settings";
            btnSettings1.UseVisualStyleBackColor = false;
            // 
            // lblSLOnline
            // 
            lblSLOnline.AutoSize = true;
            lblSLOnline.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSLOnline.ForeColor = Color.DimGray;
            lblSLOnline.Location = new Point(108, 10);
            lblSLOnline.Name = "lblSLOnline";
            lblSLOnline.Size = new Size(109, 20);
            lblSLOnline.TabIndex = 1;
            lblSLOnline.Text = "- 4 users online";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(28, 9);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "# general";
            // 
            // ChatForm
            // 
            ClientSize = new Size(840, 422);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel12);
            Controls.Add(pnlLeft);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ButtonHighlight;
            Name = "ChatForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChatApp ";
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
    }
}