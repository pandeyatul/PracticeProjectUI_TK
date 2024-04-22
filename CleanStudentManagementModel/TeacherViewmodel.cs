using CleanArchitectureStudentData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementModel
{
    public class TeacherViewmodel
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; }= string.Empty;

        public TeacherViewmodel(Users viewModel)
        {
            Name = viewModel.Name;
            Username= viewModel.UserName;
            Roles role=(Roles)viewModel.Role;
            Role=role.ToString();
        }
    }
}
