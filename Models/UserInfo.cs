using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class UserInfo
    {
        public string Username { get; set; }
        public int EmpId { get; set; }
        public string RoleName { get; set; }
        public int DeptId { get; set; }
        public string FullName { get; set; }
    }
}
