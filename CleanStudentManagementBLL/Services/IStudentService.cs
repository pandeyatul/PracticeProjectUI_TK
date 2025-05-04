using CleanStudentManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementBLL.Services
{
    public interface IStudentService
    {
        PageResult<StudentViewModel> GetAllStudents(int pageno,int pageSize);
        Task<int> AddStudent(CreateStudentModel viewModel);
       IEnumerable<StudentVModel> GetAll();
        IEnumerable<ResultViewModel> GetExamResult(int studentid);
        bool SetGroupIdToStudent(GroupStudentViewModel gsmodel);
        StudentViewModel StudentById(int studentid);
        void UpdateProfile(StudentViewModel model);
    }
}
