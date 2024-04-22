using CleanStudentManagementBLL.Services;
using CleanStudentManagementModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanStudentManagementUI.Controllers
{
    public class ExamController : Controller
    {
        private readonly IGroupService _groupservices;
        private readonly IExamService _examservices;

        public ExamController(IGroupService groupservices, IExamService examservices)
        {
            _groupservices = groupservices;
            _examservices = examservices;
        }

        public IActionResult Index(int pageno=1,int pagesize=10)
        {
            var examdata = _examservices.GetAllExam(pageno,pagesize);
            return View(examdata);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var groups=_groupservices.GetAllGroups();
            ViewBag.GetAllgrps = new SelectList(groups,"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateExamModel examModel)
        {
            _examservices.AddExam(examModel);
            return RedirectToAction("Index");
        }
    }
}
