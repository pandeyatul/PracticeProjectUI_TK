using CleanArchitectureStudentData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementModel
{
    public class StudentVModel
    {   
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public StudentVModel(Student student)
        {
            Id = student.Id;
            Name = student.Name;
        }
    }
    public class Checkboxtable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsChecked { get; set; }
    }
}
