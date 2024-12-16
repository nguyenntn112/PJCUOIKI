using System.Drawing;
using System.Windows.Forms;
using System;
using EmployeeManagement.Common;
using EmployeeManagement.Forms.Main;
using EmployeeManagement.Services;

namespace EmployeeManagement.Forms.Auth
{
    public partial class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private readonly EmployeeService _employeeService;

        public LoginForm()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
        }

        private void InitializeComponent()
        {
            this.Text = Constants.APP_NAME;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Username
            var lblUsername = new Label
            {
                Text = "Tên đăng nhập:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtUsername = new TextBox
            {
                Location = new Point(20, 40),
                Width = 240
            };

            // Password
            var lblPassword = new Label
            {
                Text = "Mật khẩu:",
                Location = new Point(20, 70),
                AutoSize = true
            };

            txtPassword = new TextBox
            {
                Location = new Point(20, 90),
                Width = 240,
                PasswordChar = '*'
            };

            // Login button
            btnLogin = new Button
            {
                Text = "Đăng nhập",
                Location = new Point(100, 120),
                Width = 100
            };
            btnLogin.Click += BtnLogin_Click;

            // Add controls
            this.Controls.AddRange(new Control[] {
                lblUsername, txtUsername,
                lblPassword, txtPassword,
                btnLogin
            });

            this.AcceptButton = btnLogin;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                if (_employeeService.ValidateLogin(txtUsername.Text, txtPassword.Text, out var userInfo))
                {
                    Program.CurrentUser = userInfo;
                    this.Hide();
                    new MainForm().Show();
                }
                else
                {
                    MessageBox.Show(Constants.Messages.LOGIN_FAILED,
                        Constants.Messages.ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}",
                    Constants.Messages.ERROR,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
