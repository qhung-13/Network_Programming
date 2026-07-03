using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChatClient.Forms
{
    /// <summary>
    /// Form responsible for creating a new chat room.
    /// Handles user input validation for room names, descriptions, colors, and member limits.
    /// </summary>
    public partial class CreateNewRoom : Form
    {
        #region Properties & Fields

        // Note: Kept original property names (_camelCase) to ensure compatibility with existing references in ChatForm.cs.
        public string _roomName { get; private set; } = "";
        public string _roomDescription { get; private set; } = "";
        public Color _roomColor { get; private set; } = Color.DodgerBlue;

        // 0 indicates an unlimited number of members
        public int _memberLimit { get; private set; } = 0;

        private Panel? _selectedColorPanel;

        #endregion

        #region Constructor & Initialization

        public CreateNewRoom()
        {
            InitializeComponent();

            // Configure the dropdown to prevent free-text entry
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;

            // Bind basic form control events
            btnClose.Click += (s, e) => Close();
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
            btnCreate.Click += btnCreate_Click;

            // Bind color selection panels to a single shared event handler
            pnlColor1.Click += ColorPanel_Click;
            pnlColor2.Click += ColorPanel_Click;
            pnlColor3.Click += ColorPanel_Click;
            pnlColor4.Click += ColorPanel_Click;
            pnlColor5.Click += ColorPanel_Click;
            pnlColor6.Click += ColorPanel_Click;

            // Set default selected color
            SelectColorPanel(pnlColor1);

            // Map keyboard Enter and Escape keys to form buttons
            AcceptButton = btnCreate;
            CancelButton = btnCancel;
        }

        #endregion

        #region Core Event Handlers

        /// <summary>
        /// Validates user input and processes the room creation request.
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Sanitize the room name by removing leading hashtags and enforcing lowercase
            string rawName = textBox1.Text.Trim();
            rawName = rawName.TrimStart('#').ToLower();

            if (string.IsNullOrWhiteSpace(rawName))
            {
                MessageBox.Show("Vui lòng nhập tên phòng.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure the room name is safe for routing (only lowercase letters, numbers, and hyphens)
            if (!Regex.IsMatch(rawName, "^[a-z0-9-]+$"))
            {
                MessageBox.Show("Tên phòng chỉ được chứa chữ thường, số và dấu gạch ngang.",
                    "Tên phòng không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Assign validated values to public properties for the caller (ChatForm) to consume
            _roomName = rawName;
            _roomDescription = txtDesc.Text.Trim();
            _roomColor = _selectedColorPanel?.BackColor ?? Color.DodgerBlue;

            string memberLimitText = comboBox1.Text.Trim();

            // Parse member limit selection
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

            // Signal success to the calling form
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region UI Logic

        /// <summary>
        /// Handles click events for any color selection panel.
        /// </summary>
        private void ColorPanel_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                SelectColorPanel(panel);
            }
        }

        /// <summary>
        /// Visually highlights the selected color panel and stores its reference.
        /// </summary>
        private void SelectColorPanel(Panel panel)
        {
            // Reset borders for all color panels
            pnlColor1.BorderStyle = BorderStyle.None;
            pnlColor2.BorderStyle = BorderStyle.None;
            pnlColor3.BorderStyle = BorderStyle.None;
            pnlColor4.BorderStyle = BorderStyle.None;
            pnlColor5.BorderStyle = BorderStyle.None;
            pnlColor6.BorderStyle = BorderStyle.None;

            // Apply 3D border to indicate selection
            panel.BorderStyle = BorderStyle.Fixed3D;
            _selectedColorPanel = panel;
        }

        #endregion

        #region Unused / Designer Event Handlers
        // Note: Retained to prevent WinForms designer file (.Designer.cs) from throwing missing method errors.

        private void lblRoomName_Click(object sender, EventArgs e) { }
        private void CreateNewRoom_Load(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        #endregion
    }
}