using CleanStudentManagementBLL.Services;
using CleanStudentManagementModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanStudentManagementUI.Controllers
{
    public class QuesAnsController : Controller
    {
        private readonly IExamService _examservice;
        private readonly IQnAnsService _iqnAnsservice;
        public QuesAnsController(IExamService examservice, IQnAnsService iqnAnsservice)
        {
            _examservice = examservice;
            _iqnAnsservice = iqnAnsservice;
        }

        public IActionResult Index(int pageno=1, int pagesize=3)
        {
            var queslist = _iqnAnsservice.GetAllQans(pageno, pagesize);
            return View(queslist);
        }
        public IActionResult Create()
        {
            var exams = _examservice.GetAll();
            ViewBag.Examlist = new SelectList(exams, "Id", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult Create(QAnsViewModel ansViewModel)
        {
            _iqnAnsservice.Add(ansViewModel);
            return RedirectToAction("Index");
        }
    }
}
