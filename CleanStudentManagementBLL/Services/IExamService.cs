using CleanStudentManagementModel;
 

namespace CleanStudentManagementBLL.Services
{
    public interface IExamService
    {
        PageResult<ExamViewModel> GetAllExam(int Pagenumber,int Pagesize);
       IEnumerable<ExamViewModel> GetAll();
        void AddExam(CreateExamModel examModel);
    }
}
