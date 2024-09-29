using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string UserName { get; set; }=string.Empty;  
        public string Password { get; set; } = string.Empty; 
        public string ContactNo { get; set; } = string.Empty;
        public string? CVFileName { get; set; }
        public string? ProfilePicture { get; set; }
        public int? groupId { get; set; }
        public virtual Groups group { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }
    }
}
