using CleanStudentManagementBLL.Services;
using CleanStudentManagementModel;
using CleanStudentManagementUI.Filter;
using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagementUI.Controllers
{
    [RoleAuthorize(1)]
    public class UsersController : Controller
    {
        private readonly IAccountService _accountservice;

        public UsersController(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }

        public IActionResult Index(int Pagenumber = 1,int pagesize=2)
        {
            var teacherdata = _accountservice.GetAll(Pagenumber, pagesize);
            return View(teacherdata);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserViewModel userView)
        {
            var success = _accountservice.AddTeacher(userView);
            if (success)
            {
                return RedirectToAction("Index");
            }
            return View(userView);
        }
    }
}
