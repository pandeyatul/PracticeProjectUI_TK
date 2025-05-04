using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementModel
{
    public class AttendExamViewModel
    {
        public string StudentId { get; set; } = string.Empty;
        public string ExamName { get; set; } = string.Empty;
        public List<QAnsViewModel> QuesList { get; set; } = new List<QAnsViewModel>();
        public string Message { get; set; } = string.Empty;
    }
}
