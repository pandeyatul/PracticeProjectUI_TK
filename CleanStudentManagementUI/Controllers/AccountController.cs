using CleanStudentManagementBLL.Services;
using CleanStudentManagementModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Security.Claims;
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
        public IActionResult Login()
        {
           // var Isemail = IsValidEmail("atulp@chetu.com");
            return View();
        }
        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                LoginViewModel lvm = _accountservice.Login(model);
                if (lvm != null)
                {
                    string sessionobj = JsonSerializer.Serialize(lvm);
                    HttpContext.Session.SetString("logindetails", sessionobj);
                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,model.UserName)
                };
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

                    return RedirectToUser(lvm);
                }
            }
                return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        private IActionResult RedirectToUser(LoginViewModel lvm)
        {
            //int a = (int)Roles.Admin;
            if (lvm.Role==(int)Roles.Admin)
            {
                return RedirectToAction("Index","Users");
            }
            else if (lvm.Role==(int)Roles.Teacher)
            {
                return RedirectToAction("Index","Exam");
            }
            else
            {
                return RedirectToAction("Profile", "Student");
            }
        }
    }
}
