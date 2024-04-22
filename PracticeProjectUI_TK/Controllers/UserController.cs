using Entities_TK;
using Entities_TK.Interface;
using Microsoft.AspNetCore.Mvc;

namespace PracticeProjectUI_TK.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsers _usersdata;

        public UserController(IUsers users)
        {
            _usersdata = users;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public async Task<IActionResult> Login(Users users)
        {
            if (ModelState.IsValid)
            {
                var userinfo = await _usersdata.GetUser(users.UserName ?? string.Empty, users.Passowrd ?? string.Empty);
                if (userinfo.UserName!=null && userinfo.Passowrd!=null)
                {
                    HttpContext.Session.SetInt32("UserId", users.Id);
                    HttpContext.Session.SetString("Username", users.UserName ?? string.Empty);
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Message = "Invalid Credential!";
                return View();
            }
            return View();
        }
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(Users users)
        {
            if (users != null)
            {
               await _usersdata.RegisterUser(users);
                return RedirectToAction("Login", "User");
            }
            return View();
        }
    }
}
