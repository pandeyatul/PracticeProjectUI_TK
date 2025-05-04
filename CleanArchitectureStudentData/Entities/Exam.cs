using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public string Description { get; set; }= string.Empty;
        public DateTime StartDate { get; set; }
        public int Period { get; set; }
        public int groupsId { get; set; }
        public virtual Groups groups { get; set; }
        public virtual ICollection<ExamResult> examResults { get; set; }= new List<ExamResult>();
        public virtual ICollection<QuesAnswer> Ques { get; set; } = new List<QuesAnswer>();

    }
}
