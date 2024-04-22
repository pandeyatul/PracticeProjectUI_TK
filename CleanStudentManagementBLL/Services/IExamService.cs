using CleanStudentManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementBLL.Services
{
    public interface IExamService
    {
        PageResult<ExamViewModel> GetAllExam(int Pagenumber,int Pagesize);
       IEnumerable<ExamViewModel> GetAll();
        void AddExam(CreateExamModel examModel);
    }
}
