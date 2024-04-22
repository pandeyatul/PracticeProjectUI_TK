using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementModel
{
    public class UserViewModel
    {
        public string Name { get; set; } = string.Empty;
        public int Role { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;
    }
}
