using CleanStudentManagementBLL.Services;
using CleanStudentManagementModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CleanStudentManagementUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountservice;

        public AccountController(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }
        
        public IActionResult Login(LoginViewModel model)
        {
            LoginViewModel lvm=_accountservice.Login(model);
            if(lvm != null)
            {
                string sessionobj=JsonSerializer.Serialize(lvm);
                HttpContext.Session.SetString("logindetails",sessionobj);
                return RedirectToUser(lvm);
            }
            return View();
        }

        private IActionResult RedirectToUser(LoginViewModel lvm)
        {
            if (lvm.Role==(int)Roles.Admin)
            {
                return RedirectToAction("index","Users");
            }
            else if (lvm.Role==(int)Roles.Teacher)
            {
                return RedirectToAction("Index","Exam");
            }
            else
            {
                return RedirectToAction("Index", "Student");
            }
        }
    }
}
