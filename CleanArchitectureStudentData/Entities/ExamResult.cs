using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.Entities
{
    public class ExamResult
    {
        public int Id { get; set; }
        [NotMapped]
        public int StudentId { get; set; }
        [NotMapped]
        public virtual Student student { get; set; }
        public int QuesAnsId { get; set; }
        public virtual QuesAnswer quesAnswer { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public string Answer { get; set; } = string.Empty; 
    }
}
    