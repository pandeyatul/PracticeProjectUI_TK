using CleanArchitectureStudentData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementModel
{
    public class QAnsViewModel
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; } = string.Empty;
        public int Examid { get; set; }
        public string Answer { get; set; } = string.Empty;
        public string SelectedAnswer { get; set; } = string.Empty;
        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionC { get; set; } = string.Empty;
        public string OptionD { get; set; } = string.Empty;
        public QAnsViewModel()
        {

        }
        public QAnsViewModel(QuesAnswer createQAnsView)
        {
            Id = createQAnsView.Id;
            QuestionTitle = createQAnsView.QuestionTitle;
            Examid = createQAnsView.Examid;
            Answer = createQAnsView.Answer;
            OptionA = createQAnsView.OptionA;
            OptionB = createQAnsView.OptionB;
            OptionC = createQAnsView.OptionC;
            OptionD = createQAnsView.OptionD;
        }
    }
}
