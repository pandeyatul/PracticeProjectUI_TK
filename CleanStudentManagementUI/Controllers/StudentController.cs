using CleanStudentManagementBLL.Services;
using CleanStudentManagementModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CleanStudentManagementUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IExamService _examService;
        private readonly IQnAnsService _IqService;
        public StudentController(IStudentService studentService, IExamService examService, IQnAnsService nsService)
        {
            _studentService = studentService;
            _examService = examService;
            _IqService = nsService;
        }

        public IActionResult Index()
        {
           // var students = _studentService.GetAll();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel viewModel)
        {
            var isAdded =await _studentService.AddStudent(viewModel);
            if (isAdded>0)
            {                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public IActionResult AttendanceInExam()
        {
            var model = new StudentAttendanceViewModel();
            string strobj = HttpContext.Session.GetString("logindetails")??string.Empty;
            LoginViewModel sessiondata=JsonConvert.DeserializeObject<LoginViewModel>(strobj);
            if(sessiondata!=null)
            {
                model.StudentId=sessiondata.Id;
                var todayExam = _examService.GetAll().FirstOrDefault(x=>x.StartDate==DateTime.Today.Date);
                if (todayExam==null)
                {
                    model.Message = "No Exam Schedule for today";
                }
                else
                {
                    bool IsAttend = _IqService.IsAttendExam(todayExam.Id,model.StudentId);
                    if (!IsAttend)
                    {
                        model.QuesAnsList = _IqService.GetAllByExamId(todayExam.Id).ToList();
                        model.ExamName = todayExam.Title;
                    }
                    else
                    {
                        model.Message = "You have already Attend this exam";
                    }
                }
                return View(model);
            }
            return RedirectToAction("Login","Account");
        }
        [HttpPost]
        public IActionResult AttendExam(StudentAttendanceViewModel studentAttendance)
        {
            bool result = _IqService.SetExamResult(studentAttendance);
            return View();
        }
        public IActionResult Result(int Studentid)
        {
            var result = _studentService.GetResult(Studentid);
            return View();
        }
    }
    
}
