using CleanArchitectureStudentData.Entities;
using CleanArchitectureStudentData.UnitOfWork;
using CleanStudentManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementBLL.Services
{
    public class QnAnsService : IQnAnsService
    {
        private readonly UnitOfWork _unitofwork;

        public QnAnsService(UnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public void Add(CreateQAnsViewModel createQAnsView)
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

        public IEnumerable<CreateQAnsViewModel> GetAllByExamId(int examid)
        {
            var examlist = _unitofwork.genericRepo<QuesAnswer>().GetAll().Where(e=>e.Examid==examid).ToList();
            return listinfo(examlist);
        }

        public PageResult<CreateQAnsViewModel> GetAllQans(int pagenumber, int pagesize)
        {
            int excluderecords = (pagenumber * pagesize) - pagesize;
            List<CreateQAnsViewModel> Queslist = new List<CreateQAnsViewModel>();
            var quesans = _unitofwork.genericRepo<QuesAnswer>().GetAll().Skip(excluderecords).Take(pagesize);
            Queslist = listinfo(quesans);

            var result = new PageResult<CreateQAnsViewModel>
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
            var examresult = _unitofwork.genericRepo<ExamResult>().GetAll().Where(x => x.ExamId == ExamId && x.StudentId == Studentid);
           return examresult==null ? false : true;
        }

        public bool SetExamResult(StudentAttendanceViewModel studentAttendance)
        {
            try
            {
                foreach (var item in studentAttendance.QuesAnsList)
                {
                    ExamResult examResult = new ExamResult()
                    {
                        StudentId = studentAttendance.StudentId,
                        ExamId = item.Examid,
                        Answer = item.Answer
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

        private List<CreateQAnsViewModel> listinfo(IEnumerable<QuesAnswer> groups)
        {
            return groups.Select(x => new CreateQAnsViewModel(x)).ToList();
        }
    }
}
