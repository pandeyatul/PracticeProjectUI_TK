using CleanArchitectureStudentData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementModel
{
    public class ExamViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int Period { get; set; }
        public string GroupName { get; set; }

        public ExamViewModel(Exam exam)
        {
            Id=exam.Id;
            Title = exam.Title;
            Description = exam.Description;
            StartDate = exam.StartDate;
            Period = exam.Period;
            GroupName = exam.groups.Name??string.Empty;
        }
    }
}
