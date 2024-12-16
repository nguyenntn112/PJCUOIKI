using System.Windows.Forms;
using System;
using EmployeeManagement.Common;
using EmployeeManagement.Forms.Employee;

namespace EmployeeManagement.Forms.Main
{
    public partial class MainForm : Form
    {
        private MenuStrip menuStrip;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = Constants.APP_NAME;
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            // Tạo menu
            menuStrip = new MenuStrip();
            this.MainMenuStrip = menuStrip;

            // Menu Hệ thống
            var systemMenu = new ToolStripMenuItem("Hệ thống");
            var logoutItem = new ToolStripMenuItem("Đăng xuất");
            logoutItem.Click += LogoutItem_Click;
            systemMenu.DropDownItems.Add(logoutItem);

            // Menu Quản lý
            var managementMenu = new ToolStripMenuItem("Quản lý");
            var employeeListItem = new ToolStripMenuItem("Danh sách nhân viên");
            employeeListItem.Click += EmployeeListItem_Click;
            managementMenu.DropDownItems.Add(employeeListItem);

            // Thêm các menu vào MenuStrip
            menuStrip.Items.AddRange(new ToolStripItem[] {
                systemMenu,
                managementMenu
            });

            // Thêm MenuStrip vào form
            this.Controls.Add(menuStrip);
        }

        private void EmployeeListItem_Click(object sender, EventArgs e)
        {
            var employeeList = new EmployeeListForm();
            employeeList.MdiParent = this;
            employeeList.Show();
        }

        private void LogoutItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Constants.Messages.CONFIRM_LOGOUT,
                "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.CurrentUser = null;
                this.Close();
                Application.Restart();
            }
        }
    }
}
