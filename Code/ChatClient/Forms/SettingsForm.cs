using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();



          

            foreach (Control c in pnlContent.Controls)
            {
                if (c is Panel p)
                {
                    p.Dock = DockStyle.Fill;
                    //p.Dock = DockStyle.None;
                    //p.Location = new Point(0, 0);
                    //p.Size = pnlContent.Size;
                    p.Visible = false;
                }
            }

            ShowPanel(pnlAccount, btnAccount);
        }



        // Hàm xử lý chuyển panel
        private void ShowPanel(Panel targetPanel, Button activeButton)
        {
            // Ẩn tất cả panel
            pnlAccount.Visible = false;
            pnlConnection.Visible = false;
            pnlNotifications.Visible = false;
            pnlAppearance.Visible = false;
            pnlLogStorage.Visible = false;

            // Reset màu tất cả button
            btnAccount.BackColor = Color.Transparent;
            btnConnection.BackColor = Color.Transparent;
            btnNotifications.BackColor = Color.Transparent;
            btnAppearance.BackColor = Color.Transparent;
            btnLogStorage.BackColor = Color.Transparent;

            btnAccount.ForeColor = Color.FromArgb(168, 200, 232);
            btnConnection.ForeColor = Color.FromArgb(168, 200, 232);
            btnNotifications.ForeColor = Color.FromArgb(168, 200, 232);
            btnAppearance.ForeColor = Color.FromArgb(168, 200, 232);
            btnLogStorage.ForeColor = Color.FromArgb(168, 200, 232);

            // Hiện panel được chọn
            targetPanel.Visible = true;
            targetPanel.BringToFront();

            // Highlight button được chọn
            activeButton.BackColor = Color.FromArgb(14, 42, 69);
            activeButton.ForeColor = Color.FromArgb(77, 184, 255);
        }

        

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlAccount, btnAccount);
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlConnection, btnConnection);
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlNotifications, btnNotifications);
        }

        private void btnAppearance_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlAppearance, btnAppearance);
        }

        private void btnLogStorage_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlLogStorage, btnLogStorage);
        }

       
    }
}
