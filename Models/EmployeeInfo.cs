using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeInfo
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
