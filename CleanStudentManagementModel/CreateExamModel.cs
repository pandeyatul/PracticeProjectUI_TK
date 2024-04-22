using CleanArchitectureStudentData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementModel
{
    public class CreateExamModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int Period { get; set; }
        public int Groupid { get; set; }

       

        public Exam ConvertToModel(CreateExamModel examModel)
        {
            return new Exam
            {
                Title= examModel.Title,
                Description= examModel.Description,
                StartDate= examModel.StartDate,
                Period= examModel.Period,
                Groupid= examModel.Groupid,

            };
        }
    }
}
