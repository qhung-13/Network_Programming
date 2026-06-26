namespace ChatClient.Forms
{
    partial class CreateNewRoom
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
            pnlHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            lblRoomName = new Label();
            textBox1 = new TextBox();
            lblHint = new Label();
            lblDesc = new Label();
            txtDesc = new TextBox();
            lblColor = new Label();
            pnlColor1 = new Panel();
            pnlColor2 = new Panel();
            pnlColor3 = new Panel();
            pnlColor4 = new Panel();
            pnlColor5 = new Panel();
            pnlColor6 = new Panel();
            lblMemberLimit = new Label();
            comboBox1 = new ComboBox();
            btnCancel = new Button();
            btnCreate = new Button();
            pnlHeader.SuspendLayout();
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
            pnlHeader.Size = new Size(510, 50);
            pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.DodgerBlue;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(446, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(52, 34);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Blue;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(201, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "# Create New Room";
            // 
            // lblRoomName
            // 
            lblRoomName.AutoSize = true;
            lblRoomName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomName.ForeColor = Color.Gray;
            lblRoomName.Location = new Point(12, 64);
            lblRoomName.Name = "lblRoomName";
            lblRoomName.Size = new Size(117, 25);
            lblRoomName.TabIndex = 1;
            lblRoomName.Text = "Room Name";
            lblRoomName.Click += lblRoomName_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(12, 92);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(478, 31);
            textBox1.TabIndex = 2;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.ForeColor = Color.Gray;
            lblHint.Location = new Point(12, 126);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(370, 25);
            lblHint.TabIndex = 3;
            lblHint.Text = "Only lowercase letters, numbers and hyphens";
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDesc.ForeColor = Color.Gray;
            lblDesc.Location = new Point(12, 162);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(164, 25);
            lblDesc.TabIndex = 4;
            lblDesc.Text = "Room Description";
            // 
            // txtDesc
            // 
            txtDesc.BorderStyle = BorderStyle.FixedSingle;
            txtDesc.Location = new Point(12, 190);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(478, 31);
            txtDesc.TabIndex = 5;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblColor.ForeColor = Color.Gray;
            lblColor.Location = new Point(12, 234);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(124, 25);
            lblColor.TabIndex = 6;
            lblColor.Text = "Display Color";
            // 
            // pnlColor1
            // 
            pnlColor1.BackColor = Color.DodgerBlue;
            pnlColor1.Location = new Point(15, 262);
            pnlColor1.Name = "pnlColor1";
            pnlColor1.Size = new Size(44, 31);
            pnlColor1.TabIndex = 7;
            // 
            // pnlColor2
            // 
            pnlColor2.BackColor = Color.LimeGreen;
            pnlColor2.Location = new Point(75, 262);
            pnlColor2.Name = "pnlColor2";
            pnlColor2.Size = new Size(44, 31);
            pnlColor2.TabIndex = 8;
            // 
            // pnlColor3
            // 
            pnlColor3.BackColor = Color.OrangeRed;
            pnlColor3.Location = new Point(132, 262);
            pnlColor3.Name = "pnlColor3";
            pnlColor3.Size = new Size(44, 31);
            pnlColor3.TabIndex = 9;
            // 
            // pnlColor4
            // 
            pnlColor4.BackColor = Color.SkyBlue;
            pnlColor4.Location = new Point(188, 262);
            pnlColor4.Name = "pnlColor4";
            pnlColor4.Size = new Size(44, 31);
            pnlColor4.TabIndex = 10;
            // 
            // pnlColor5
            // 
            pnlColor5.BackColor = Color.HotPink;
            pnlColor5.Location = new Point(247, 262);
            pnlColor5.Name = "pnlColor5";
            pnlColor5.Size = new Size(44, 31);
            pnlColor5.TabIndex = 11;
            // 
            // pnlColor6
            // 
            pnlColor6.BackColor = Color.Gold;
            pnlColor6.Location = new Point(307, 262);
            pnlColor6.Name = "pnlColor6";
            pnlColor6.Size = new Size(44, 31);
            pnlColor6.TabIndex = 12;
            // 
            // lblMemberLimit
            // 
            lblMemberLimit.AutoSize = true;
            lblMemberLimit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMemberLimit.ForeColor = Color.Gray;
            lblMemberLimit.Location = new Point(15, 308);
            lblMemberLimit.Name = "lblMemberLimit";
            lblMemberLimit.Size = new Size(130, 25);
            lblMemberLimit.TabIndex = 13;
            lblMemberLimit.Text = "Member Limit";
            // 
            // comboBox1
            // 
            comboBox1.ForeColor = Color.Gray;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Unlimited Members", "3", "4", "5", "6", "7", "8", "9", "10" });
            comboBox1.Location = new Point(15, 336);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(475, 33);
            comboBox1.TabIndex = 14;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Gray;
            btnCancel.Location = new Point(49, 405);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(185, 34);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.SkyBlue;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreate.ForeColor = Color.Blue;
            btnCreate.Location = new Point(265, 405);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(185, 34);
            btnCreate.TabIndex = 16;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // CreateNewRoom
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 464);
            Controls.Add(btnCreate);
            Controls.Add(btnCancel);
            Controls.Add(comboBox1);
            Controls.Add(lblMemberLimit);
            Controls.Add(pnlColor6);
            Controls.Add(pnlColor5);
            Controls.Add(pnlColor4);
            Controls.Add(pnlColor3);
            Controls.Add(pnlColor2);
            Controls.Add(pnlColor1);
            Controls.Add(lblColor);
            Controls.Add(txtDesc);
            Controls.Add(lblDesc);
            Controls.Add(lblHint);
            Controls.Add(textBox1);
            Controls.Add(lblRoomName);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateNewRoom";
            Text = "CreateNewRoom";
            Load += CreateNewRoom_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Button btnClose;
        private Label lblTitle;
        private Label lblRoomName;
        private TextBox textBox1;
        private Label lblHint;
        private Label lblDesc;
        private TextBox txtDesc;
        private Label lblColor;
        private Panel pnlColor1;
        private Panel pnlColor2;
        private Panel pnlColor3;
        private Panel pnlColor4;
        private Panel pnlColor5;
        private Panel pnlColor6;
        private Label lblMemberLimit;
        private ComboBox comboBox1;
        private Button btnCancel;
        private Button btnCreate;
    }
}