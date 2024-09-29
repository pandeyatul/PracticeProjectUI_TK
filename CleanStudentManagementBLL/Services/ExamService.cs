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
    public class ExamService : IExamService
    {
        private readonly IUnitofWork _unitofwork;
        public ExamService(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public void AddExam(CreateExamModel examModel)
        {
            try
            {
                var model = examModel.ConvertToModel(examModel);
                _unitofwork.genericRepo<Exam>().Add(model);
                _unitofwork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public IEnumerable<ExamViewModel> GetAll()
        {
            var allexam =_unitofwork.genericRepo<Exam>().GetAll(IncludeProerties: "groups").ToList();
            List<ExamViewModel> Examlist = listinfo(allexam);
            return Examlist; 
        }

        public PageResult<ExamViewModel> GetAllExam(int pagenumber, int pagesize)
        {
            int excluderecords = (pagenumber * pagesize) - pagesize;
            List<ExamViewModel> examlist = new List<ExamViewModel>();
            var exams = _unitofwork.genericRepo<Exam>().GetAll(IncludeProerties: "groups").Skip(excluderecords).Take(pagesize);
            examlist = listinfo(exams);

            var result = new PageResult<ExamViewModel>
            {
                data = examlist,
                TotalItem = _unitofwork.genericRepo<Groups>().GetAll().ToList().Count(),
                PageNumber = pagenumber,
                PageSize = pagesize
            };
            return result;
        }
        private List<ExamViewModel> listinfo(IEnumerable<Exam> users)
        {
            return users.Select(x => new ExamViewModel(x)).ToList();
        }
    }
}
