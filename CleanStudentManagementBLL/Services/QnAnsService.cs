using CleanArchitectureStudentData.Entities;
using CleanArchitectureStudentData.UnitOfWork;
using CleanStudentManagementModel;

namespace CleanStudentManagementBLL.Services
{
    public class QnAnsService : IQnAnsService
    {
        private readonly IUnitofWork _unitofwork;

        public QnAnsService(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public void Add(QAnsViewModel createQAnsView)
        {
            try
            {
                var QnAns = new QuesAnswer()
                {
                    Id = createQAnsView.Id,
                    QuestionTitle = createQAnsView.QuestionTitle,
                    Examid = createQAnsView.Examid,
                    Answer = createQAnsView.Answer,
                    OptionA = createQAnsView.OptionA,
                    OptionB = createQAnsView.OptionB,
                    OptionC = createQAnsView.OptionC,
                    OptionD = createQAnsView.OptionD,
                };
                _unitofwork.genericRepo<QuesAnswer>().Add(QnAns);
                _unitofwork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<QAnsViewModel> GetAllByExamId(int examid)
        {
            var examlist = _unitofwork.genericRepo<QuesAnswer>().GetAll().Where(e=>e.Examid==examid).ToList();
            return listinfo(examlist);
        }

        public PageResult<QAnsViewModel> GetAllQans(int pagenumber, int pagesize)
        {
            int excluderecords = (pagenumber * pagesize) - pagesize;
            List<QAnsViewModel> Queslist = new List<QAnsViewModel>();
            var quesans = _unitofwork.genericRepo<QuesAnswer>().GetAll().Skip(excluderecords).Take(pagesize);
            Queslist = listinfo(quesans);

            var result = new PageResult<QAnsViewModel>
            {
                data = Queslist,
                TotalItem = _unitofwork.genericRepo<QuesAnswer>().GetAll().ToList().Count(),
                PageNumber = pagenumber,
                PageSize = pagesize
            };
            return result;
        }

        public bool IsAttendExam(int ExamId, int Studentid)
        {
            var examresult = _unitofwork.genericRepo<ExamResult>().GetAll().Any(x => x.ExamId == ExamId && x.StudentId == Studentid);
            return examresult == false ? false : true;
        }

        public bool SetExamResult(StudentAttendanceViewModel studentAttendance)
        {
            try
            {
                foreach (var item in studentAttendance.QuesList)
                {
                    ExamResult examResult = new ExamResult()
                    {
                        StudentId = studentAttendance.StudentId,
                        ExamId = item.Examid,
                        QuesAnsId=item.Id,
                        Answer = item.SelectedAnswer
                    };
                    _unitofwork.genericRepo<ExamResult>().Add(examResult);
                    _unitofwork.Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<QAnsViewModel> listinfo(IEnumerable<QuesAnswer> groups)
        {
            return groups.Select(x => new QAnsViewModel(x)).ToList();
        }
    }
}
