using CleanStudentManagementBLL.Services;
using CleanStudentManagementModel;
using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagementUI.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;

        public GroupController(IGroupService groupService, IStudentService studentService)
        {
            _groupService = groupService;
            _studentService = studentService;
        }

        public IActionResult Index(int pageno = 1, int pagesize = 3)
        {
            var groupdata = _groupService.GetAll(pageno, pagesize);
            return View(groupdata);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GroupViewModel groupView)
        {
            _groupService.AddGroup(groupView);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            GroupStudentViewModel groupStudent = new GroupStudentViewModel();
            var group = _groupService.GetById(id);
            var students = _studentService.GetAll();
            groupStudent.GroupId = group.Id;
            foreach (var student in students)
            {
                var studentinfo = new Checkboxtable()
                {
                    Id = student.Id,
                    Name = student.Name,
                    IsChecked = student.GroupId == null ? false : true
                };
                groupStudent.StudentList.Add(studentinfo);
            }
            return View(groupStudent);
        }
        [HttpPost]
        public IActionResult Details(GroupStudentViewModel gsmodel)
        {
            bool result = _studentService.SetGroupIdToStudent(gsmodel);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(gsmodel);
        }
    }
}
