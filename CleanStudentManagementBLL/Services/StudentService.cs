

using CleanArchitectureStudentData.Entities;
using CleanArchitectureStudentData.UnitOfWork;
using CleanStudentManagementModel;

namespace CleanStudentManagementBLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly UnitOfWork _unitofWork;

        public StudentService(UnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<int> AddStudent(StudentViewModel viewModel)
        {
            try
            {
                Student student = viewModel.ConverToModel(viewModel);
               await _unitofWork.genericRepo<Student>().AddAsync(student);
                _unitofWork.Save();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public IEnumerable<StudentVModel> GetAll()
        {
            try
            {
                var student = _unitofWork.genericRepo<Student>().GetAll().ToList();
                List<StudentVModel> studentlists = new List<StudentVModel>();
                studentlists = listinfo(student);
                return studentlists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ResultViewModel> GetResult(int studentid)
        {
            var result=_unitofWork.genericRepo<ResultViewModel>().GetAll().ToList();
            return result;
        }

        public bool SetGroupIdToStudent(GroupStudentViewModel gsmodel)
        {
            try
            {
                foreach (var item in gsmodel.StudentList)
                {
                    var studentdata = _unitofWork.genericRepo<Student>().GetById(item.Id);
                    if (item.IsChecked)
                    {
                        studentdata.groupId = gsmodel.GroupId;
                        _unitofWork.genericRepo<Student>().Update(studentdata);
                        _unitofWork.Save();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw ;
            }
        }

        private List<StudentVModel> listinfo(IEnumerable<Student> users)
        {
            return users.Select(x => new StudentVModel(x)).ToList();
        }
    }
}
