using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Common;
using EmployeeManagement.Models;
using Oracle.ManagedDataAccess.Client;

namespace EmployeeManagement.Services
{
    public class EmployeeService
    {
        public DataTable GetEmployeeList(string username)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PKG_EMPLOYEE_MGMT.get_department_employees";
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm parameter
                    cmd.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
                    cmd.Parameters.Add("p_resultset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    // Thực thi và lấy kết quả
                    using (var adapter = new OracleDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public bool ValidateLogin(string username, string password, out UserInfo userInfo)
        {
            userInfo = null;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT ua.username, e.emp_id, r.role_name, 
                           e.dept_id, e.emp_name
                    FROM User_Account ua
                    JOIN Employee e ON ua.emp_id = e.emp_id
                    JOIN Role r ON ua.role_id = r.role_id
                    WHERE ua.username = :username 
                    AND ua.password = :password
                    AND ua.is_active = 1";

                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("username", username);
                    cmd.Parameters.Add("password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userInfo = new UserInfo
                            {
                                Username = reader["username"].ToString(),
                                EmpId = Convert.ToInt32(reader["emp_id"]),
                                RoleName = reader["role_name"].ToString(),
                                DeptId = Convert.ToInt32(reader["dept_id"]),
                                FullName = reader["emp_name"].ToString()
                            };
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}