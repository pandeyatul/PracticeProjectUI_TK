using CleanArchitectureStudentData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementModel
{
    public class CreateStudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;

        public Student ConverToModel(CreateStudentModel student)
        {
            return new Student
            {
                Id = student.Id,
                Name = student.Name,
                UserName = student.UserName,
                Password = student.Password,
                ContactNo = student.ContactNo,
                //CVFileName = student.CVFileName,
                //ProfilePicture = student.ProfilePicture,
            };
        }
    }
    
}
