using CleanArchitectureStudentData.Entities;
using CleanArchitectureStudentData.UnitOfWork;
using CleanStudentManagementModel;

namespace CleanStudentManagementBLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitofWork _unitofWork;

        public StudentService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<int> AddStudent(CreateStudentModel viewModel)
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

        public PageResult<StudentViewModel> GetAllStudents(int pageno, int pageSize)
        {
            var excludeRecord=(pageno*pageSize)-pageSize;
            List<StudentViewModel> studentlists = new List<StudentViewModel>();
            var x = _unitofWork.genericRepo<Student>().GetAll();
            var student = _unitofWork.genericRepo<Student>().GetAll().Skip(excludeRecord).Take(pageSize);
            studentlists= Studentlistinfo(student);
            var result = new PageResult<StudentViewModel> {
                data = studentlists,
                TotalItem = _unitofWork.genericRepo<Student>().GetAll().Count(),
                PageNumber=pageno,
                PageSize=pageSize
            };
            return result;
        }

        public IEnumerable<ResultViewModel> GetExamResult(int studentid)
        {
            try
            {
                var examresult = _unitofWork.genericRepo<ExamResult>().GetAll().Where(x=>x.StudentId==studentid);
                var student=_unitofWork.genericRepo<Student>().GetAll();
                var exams=_unitofWork.genericRepo<Exam>().GetAll();
                var quesAns=_unitofWork.genericRepo<QuesAnswer>().GetAll();
                var requiredData = examresult.Join(student, er => er.StudentId, s => s.Id, (er, st) => new { er, st })
                                             .Join(exams, erj => erj.er.ExamId, ex => ex.Id, (erj, ex) => new { erj, ex })
                                             .Join(quesAns, qu => qu.ex.Id, e => e.Examid, (exj, qu) =>
                                             new ResultViewModel()
                                             {
                                                 StudentId=studentid,
                                                 ExamName=exj.ex.Title,
                                                 TotalQuestion=examresult.Count(std=>std.StudentId==studentid && qu.Examid==exj.ex.Id),
                                                 CorrectAnswer=examresult.Count(std=>std.StudentId==studentid && qu.Examid==exj.ex.Id && std.Answer==qu.Answer),
                                                 WrongAnswer=examresult.Count(stds=>stds.StudentId==studentid && qu.Examid==exj.ex.Id && stds.Answer!=qu.Answer)
                                             });


                return requiredData;
            }
            catch(Exception ex) 
            {
                throw ex;
            }

           
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
        private List<StudentViewModel> Studentlistinfo(IEnumerable<Student> users)

        {
            return users.Select(x => new StudentViewModel(x)).ToList();
        }
        private List<StudentVModel> listinfo(IEnumerable<Student> users)
        {
            return users.Select(x => new StudentVModel(x)).ToList();
        }

        public StudentViewModel StudentById(int studentid)
        {
            var student = _unitofWork.genericRepo<Student>().GetById(studentid);
            var studentProfile = new StudentViewModel(student);
            return studentProfile;
        }

        public void UpdateProfile(StudentViewModel model)
        {
                var student = _unitofWork.genericRepo<Student>().GetById(model.Id);
            if (student!=null)
            {
                student.Name=model.Name;
                student.ContactNo=model.ContactNo;
                student.ProfilePicture=model.ProfilePicture!=null?model.ProfilePicture:student.ProfilePicture;
                student.CVFileName=model.CVFileName!=null?model.CVFileName:student.CVFileName;

                _unitofWork.genericRepo<Student>().Update(student);
                _unitofWork.Save();

            }
        }
    }
}
