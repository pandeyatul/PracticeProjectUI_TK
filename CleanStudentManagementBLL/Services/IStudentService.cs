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
        Task<int> AddStudent(StudentViewModel viewModel);
       IEnumerable<StudentVModel> GetAll();
        IEnumerable<ResultViewModel> GetResult(int studentid);
        bool SetGroupIdToStudent(GroupStudentViewModel gsmodel);
    }
}
