namespace ChatClient.Forms
{
    partial class LoginForm
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
            lblKetnoi = new Label();
            lblChatApp = new Label();
            panel1 = new Panel();
            btnKetNoi1 = new Button();
            textBox3 = new TextBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label1 = new Label();
            pnlLeft.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.Blue;
            pnlLeft.Controls.Add(lblKetnoi);
            pnlLeft.Controls.Add(lblChatApp);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(230, 444);
            pnlLeft.TabIndex = 0;
            // 
            // lblKetnoi
            // 
            lblKetnoi.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKetnoi.ForeColor = Color.White;
            lblKetnoi.Location = new Point(12, 207);
            lblKetnoi.Name = "lblKetnoi";
            lblKetnoi.Size = new Size(200, 57);
            lblKetnoi.TabIndex = 2;
            lblKetnoi.Text = "K?t n?i và trò chuy?n cùng m?i ng??i\r\n\r\n";
            lblKetnoi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblChatApp
            // 
            lblChatApp.AutoSize = true;
            lblChatApp.Font = new Font("Segoe UI Symbol", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChatApp.ForeColor = Color.White;
            lblChatApp.Location = new Point(35, 157);
            lblChatApp.Name = "lblChatApp";
            lblChatApp.Size = new Size(151, 45);
            lblChatApp.TabIndex = 1;
            lblChatApp.Text = "ChatApp";
            lblChatApp.Click += lblChatApp_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btnKetNoi1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(276, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 410);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // btnKetNoi1
            // 
            btnKetNoi1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKetNoi1.ForeColor = Color.Navy;
            btnKetNoi1.Location = new Point(117, 337);
            btnKetNoi1.Name = "btnKetNoi1";
            btnKetNoi1.Size = new Size(191, 34);
            btnKetNoi1.TabIndex = 11;
            btnKetNoi1.Text = "K?t n?i";
            btnKetNoi1.UseVisualStyleBackColor = true;
            btnKetNoi1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(3, 270);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(454, 31);
            textBox3.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlDark;
            label5.Location = new Point(13, 242);
            label5.Name = "label5";
            label5.Size = new Size(44, 25);
            label5.TabIndex = 9;
            label5.Text = "Port";
            label5.Click += label5_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 189);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(454, 31);
            textBox2.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ButtonShadow;
            label6.Location = new Point(35, 374);
            label6.Name = "label6";
            label6.Size = new Size(370, 25);
            label6.TabIndex = 7;
            label6.Text = "B?n ch?a có server? Hãy liên h? ng??i qu?n tr?\r\n";
            label6.Click += label6_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonShadow;
            label4.Location = new Point(3, 161);
            label4.Name = "label4";
            label4.Size = new Size(150, 25);
            label4.TabIndex = 4;
            label4.Text = "??a ch? server (IP)";
            label4.Click += label4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(454, 31);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDark;
            label3.Location = new Point(3, 74);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 2;
            label3.Text = "Tên hi?n th?";
            label3.Click += label3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 29);
            label1.Name = "label1";
            label1.Size = new Size(200, 30);
            label1.TabIndex = 0;
            label1.Text = "B?t ??u trò chuy?n";
            label1.Click += label1_Click;
            // 
            // LoginForm
            // 
            ClientSize = new Size(778, 444);
            Controls.Add(panel1);
            Controls.Add(pnlLeft);
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
        private Panel pnlLeft;
        private Label lblChatApp;
        private Label lblKetnoi;
        private Panel panel1;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label6;
        private Button btnKetNoi1;
        private TextBox textBox3;
        private Label label5;
    }
}