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
        private readonly IUtility _utility;

        public string ContainerName = "StudentImage";
        public string CvContainerName = "StudentCV";
        public StudentController(IStudentService studentService, IExamService examService, IQnAnsService nsService, IUtility utility)
        {
            _studentService = studentService;
            _examService = examService;
            _IqService = nsService;
            _utility = utility;
        }

        public IActionResult Index(int pageno = 1, int pagesize = 2)
        {
            var students = _studentService.GetAllStudents(pageno, pagesize);
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Profile()
        {
            var sessiondata = HttpContext.Session.GetString("logindetails");
            if (sessiondata != null)
            {
                var usermodel = JsonConvert.DeserializeObject<LoginViewModel>(sessiondata);
                var studentinfo = _studentService.StudentById(usermodel.Id);
                return View(studentinfo);
            }
            return RedirectToAction("Account", "Login");
        }
        [HttpPost]
        public async Task<IActionResult> Profile(StudentViewModel viewModel)
        {
            if (viewModel.ProfilePictureUrl != null)
            {
                viewModel.ProfilePicture = await _utility.SaveImage(ContainerName, viewModel.ProfilePictureUrl);
            }
            if (viewModel.CVFileUrl != null)
            {
                viewModel.CVFileName = await _utility.SaveImage(CvContainerName, viewModel.CVFileUrl);
            }
            _studentService.UpdateProfile(viewModel);

            return RedirectToAction("Profile");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentModel viewModel)
        {
            var isAdded = await _studentService.AddStudent(viewModel);
            if (isAdded > 0)
            {
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public IActionResult AttendExam()
        {
            var model = new StudentAttendanceViewModel();
            string strobj = HttpContext.Session.GetString("logindetails") ?? string.Empty;
            LoginViewModel sessiondata = JsonConvert.DeserializeObject<LoginViewModel>(strobj);
            if (sessiondata != null)
            {
                model.StudentId = sessiondata.Id;
                var todayExam = _examService.GetAll().Where(x => x.StartDate <= DateTime.Today.Date).FirstOrDefault();
                if (todayExam == null)
                {
                    model.Message = "No Exam Schedule for today";
                }
                else
                {
                    bool IsAttend = _IqService.IsAttendExam(todayExam.Id, model.StudentId);
                    if (!IsAttend)
                    {
                        model.QuesList = _IqService.GetAllByExamId(todayExam.Id).ToList();
                        model.ExamName = todayExam.Title;
                    }
                    else
                    {
                        model.Message = "You have already Attend this exam";
                    }
                }
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public IActionResult AttendExam(StudentAttendanceViewModel studentAttendance)
        {
            bool result = _IqService.SetExamResult(studentAttendance);
            return View();
        }
        public IActionResult ExamResultView()
        {
            string strobj = HttpContext.Session.GetString("logindetails") ?? string.Empty;
            LoginViewModel sessiondata = JsonConvert.DeserializeObject<LoginViewModel>(strobj);
            if (sessiondata != null)
            {
                var result = _studentService.GetExamResult(sessiondata.Id);
                return View(result);
            }
            return RedirectToAction("Login","Account");
        }
    }

}
