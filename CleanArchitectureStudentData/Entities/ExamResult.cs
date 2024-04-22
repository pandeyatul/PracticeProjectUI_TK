using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.Entities
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student student { get; set; } = new Student();
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }=new Exam();
        public string Answer { get; set; } = string.Empty; 
    }
}
    