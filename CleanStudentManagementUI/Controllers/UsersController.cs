using CleanStudentManagementBLL.Services;
using CleanStudentManagementModel;
using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagementUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAccountService _accountservice;

        public UsersController(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }

        public IActionResult Index(int pagenumber,int pagesize)
        {
            var teacherdata = _accountservice.GetAll(pagenumber,pagesize);
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
