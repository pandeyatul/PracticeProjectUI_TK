using Entities_TK;
using Microsoft.AspNetCore.Mvc;
using PracticeProjectUI_TK.Models.ViewModels;

namespace PracticeProjectUI_TK.Controllers
{
    public class Form1099MiscController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Form1099Misc()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form1099Misc(From1099MiscViewModel model)
        {
            return View();
        }
        public IActionResult GetRecipientdata()
        {
            //var recipeint = new Recipientinfo()
            //{
            //    Name = new List<string> { "Atul", "Sachin", "Dhoni" },
            //    Address = new List<string> { "Noida sec-66,201302", "Mumbai burli 206,45623", "Jharkhand Ranchi" },
            //    SSN = new List<string> { "111-22-3333", "444-55-6666", "777-88-9999" }
            //};
            var recipients = new List<Recipientinfo>() {
            new Recipientinfo()
            {
                Name="Atul",
                Address="Noida sec-66,201302",
                SSN="111-22-3333"
            },
             new Recipientinfo()
            {
                Name="Sachin",
                Address="Mumbai burli 206,45623",
                SSN="444-55-6666"
            },
              new Recipientinfo()
            {
                Name="Dhoni",
                Address="Jharkhand Ranchi",
                SSN="777-88-9999"
            },
            };
            return Json(recipients);
        }
        public IActionResult Form1040sc()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form1040sc(Form1040scViewModel model)
        {
            return View();
        }
    }
}
