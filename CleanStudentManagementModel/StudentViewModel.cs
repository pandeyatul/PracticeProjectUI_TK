using CleanArchitectureStudentData.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string? CVFileName { get; set; }
        public IFormFile? CVFileUrl { get; set; }
        public string? ProfilePicture { get; set; }
        public IFormFile? ProfilePictureUrl { get; set; }
        public int groupId { get; set; }
        public StudentViewModel()
        {
            
        }
        public StudentViewModel(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            UserName = student.UserName;
            Password = student.Password;
            ContactNo = student.ContactNo;
            CVFileName = student.CVFileName;
            ProfilePicture = student.ProfilePicture;
           // groupId = (int)student.groupId;
        }
        
    }
}
