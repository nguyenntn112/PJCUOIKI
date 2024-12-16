using System.Drawing;
using System.Windows.Forms;
using System;
using EmployeeManagement.Common;
using EmployeeManagement.Services;

namespace EmployeeManagement.Forms.Employee
{
    public partial class EmployeeListForm : Form
    {
        private readonly EmployeeService _employeeService;
        private DataGridView dgvEmployee;

        public EmployeeListForm()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            LoadEmployees();
        }

        private void InitializeComponent()
        {
            this.Text = "Danh sách nhân viên";
            this.Size = new Size(800, 600);

            dgvEmployee = new DataGridView();
            dgvEmployee.Dock = DockStyle.Fill;
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.AllowUserToDeleteRows = false;
            dgvEmployee.ReadOnly = true;
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.MultiSelect = false;
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(dgvEmployee);
        }

        private void LoadEmployees()
        {
            try
            {
                var dt = _employeeService.GetEmployeeList(Program.CurrentUser.Username);
                dgvEmployee.DataSource = dt;

                // Đặt tên cột tiếng Việt
                dgvEmployee.Columns["emp_id"].HeaderText = "Mã NV";
                dgvEmployee.Columns["emp_name"].HeaderText = "Họ tên";
                dgvEmployee.Columns["birth_date"].HeaderText = "Ngày sinh";
                dgvEmployee.Columns["email"].HeaderText = "Email";
                dgvEmployee.Columns["dept_name"].HeaderText = "Phòng ban";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", Constants.Messages.ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
