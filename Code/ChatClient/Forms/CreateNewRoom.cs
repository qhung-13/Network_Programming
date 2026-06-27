using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ChatClient.Forms
{
    public partial class CreateNewRoom : Form
    {
        public string _roomName { get; private set; } = "";
        public string _roomDescription { get; private set; } = "";
        public Color _roomColor { get; private set; } = Color.DodgerBlue;
        public int _memberLimit { get; private set; } = 0; // 0 is no limited
        private Panel? _selectedColorPanel;
        public CreateNewRoom()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;

            btnClose.Click += (s, e) => Close();
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
            btnCreate.Click += btnCreate_Click;

            pnlColor1.Click += ColorPanel_Click;
            pnlColor2.Click += ColorPanel_Click;
            pnlColor3.Click += ColorPanel_Click;
            pnlColor4.Click += ColorPanel_Click;
            pnlColor5.Click += ColorPanel_Click;
            pnlColor6.Click += ColorPanel_Click;

            SelectColorPanel(pnlColor1);

            AcceptButton = btnCreate;
            CancelButton = btnCancel;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string rawName = textBox1.Text.Trim();
            rawName = rawName.TrimStart('#').ToLower();

            if (string.IsNullOrWhiteSpace(rawName))
            {
                MessageBox.Show("Vui lòng nhập tên phòng.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(rawName, "^[a-z0-9-]+$"))
            {
                MessageBox.Show("Tên phòng chỉ được chứa chữ thường, số và dấu gạch ngang.",
                    "Tên phòng không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _roomName = rawName;
            _roomDescription = txtDesc.Text.Trim();
            _roomColor = _selectedColorPanel?.BackColor ?? Color.DodgerBlue;

            string memberLimitText = comboBox1.Text.Trim();

            if (memberLimitText == "Unlimited Members")
            {
                _memberLimit = 0;
            }
            else if (!int.TryParse(memberLimitText, out int memberLimit))
            {
                MessageBox.Show("Giới hạn thành viên phải là số.", "Giới hạn không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (memberLimit <= 0)
            {
                MessageBox.Show("Giới hạn thành viên phải lớn hơn 0.", "Giới hạn không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                _memberLimit = memberLimit;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ColorPanel_Click(object sender, EventArgs e)
        {
            if(sender is Panel panel)
            {
                SelectColorPanel(panel);
            }
        }

        private void SelectColorPanel(Panel panel)
        {
            pnlColor1.BorderStyle = BorderStyle.None;
            pnlColor2.BorderStyle = BorderStyle.None;
            pnlColor3.BorderStyle = BorderStyle.None;
            pnlColor4.BorderStyle = BorderStyle.None;
            pnlColor5.BorderStyle = BorderStyle.None;
            pnlColor6.BorderStyle = BorderStyle.None;

            panel.BorderStyle = BorderStyle.Fixed3D;
            _selectedColorPanel = panel;
        }

        private void lblRoomName_Click(object sender, EventArgs e)
        {

        }

        private void CreateNewRoom_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
