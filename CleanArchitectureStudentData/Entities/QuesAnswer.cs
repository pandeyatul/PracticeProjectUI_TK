using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.Entities
{
    public class QuesAnswer
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; } = string.Empty;
        public int Examid { get; set; }
        public virtual Exam Exam { get; set; }
        public string Answer { get; set; } = string.Empty;
        public string OptionA { get; set; } = string.Empty;
        public string OptionB{ get; set; } = string.Empty;
        public string OptionC { get; set; } = string.Empty;
        public string OptionD { get; set; } = string.Empty;
    }
}
