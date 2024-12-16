using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common
{
    public static class Constants
    {
        public const string APP_NAME = "Quản lý nhân viên";
        public const string DATE_FORMAT = "dd/MM/yyyy";

        public static class Messages
        {
            public const string LOGIN_FAILED = "Sai tên đăng nhập hoặc mật khẩu!";
            public const string ERROR = "Lỗi";
            public const string CONFIRM_LOGOUT = "Bạn có muốn đăng xuất?";
        }
    }
}