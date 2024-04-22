using Entities_TK;
using Entities_TK.Interface;
using Microsoft.AspNetCore.Mvc;
using PracticeProjectUI_TK.Models.ViewModels;

namespace PracticeProjectUI_TK.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkill _skill;
        public SkillController(ISkill skill)
        {
            _skill= skill;
        }
        public async Task<IActionResult> Index(int pageno = 1, int pagesize = 3,string searchItem="",string Filtertext="",string sortOrder="")
        {
            ViewData["Sorting"] = sortOrder;
            ViewData["IdSort"] = sortOrder == "id_desc" ? "" : "Id_desc";
            ViewData["Name_sort"] = sortOrder == "Skill_desc" ? "Skill_asc" : "Skill_desc";
            var skill =await _skill.GetAllSkills();
            var skillist = new List<SkillViewModel>();
            if (!string.IsNullOrEmpty(searchItem))
            {
                pageno = 1;
            }
            else
            {
                searchItem = Filtertext;
            }
            ViewData["filterdata"] = searchItem;

            switch (sortOrder)
            {
                case "Id_desc":
                    skill = skill.OrderByDescending(x => x.Id).ToList();
                    break;
                case "Id_Asc":
                    skill = skill.OrderBy(x => x.Id).ToList();
                    break;
                case "Skill_desc":
                    skill = skill.OrderByDescending(x => x.Name).ToList();
                    break;
                case "Skill_asc":
                    skill = skill.OrderBy(x => x.Name).ToList();  
                    break;
                default:
                    skill = skill.OrderBy(x=>x.Id).ToList();
                    break;
            }

            if (!string.IsNullOrEmpty(searchItem))
            {
                skill = skill.Where(x=>x.Name.ToLower().Contains(searchItem.ToLower())).ToList();
            }
             

            int totalitem= skill.ToList().Count;
            skill=skill.Skip((pageno-1)*pagesize).Take(pagesize).ToList();
            foreach (var item in skill)
            {
                var skillinfo = new SkillViewModel
                {
                    Skill_Id=item.Id,
                    SkillName=item.Name??string.Empty
                };
                skillist.Add(skillinfo);
            }
            var pvm = new PagingSkillViewModel()
            {
                SkillList = skillist,
                pageInfo = new Utility.PageInfo
                {
                    PageNumber=pageno,
                    PageSize=pagesize,
                    TotalItems=totalitem
                }
            };
            return View(pvm);
        }
        [HttpGet]
        public  IActionResult Create_Skill()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create_Skill(Skills skills)
        {
           await _skill.CreateSkill(skills);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update_Skill(int id)
        {
            var skill =await _skill.GetAllSkills();
            var skillinfo=skill.FirstOrDefault(x => x.Id==id);
            return View(skillinfo);
        }
        [HttpPost]
        public async Task<IActionResult> Update_Skill(Skills skills)
        {
           await _skill.UpdateSkill(skills);
            return RedirectToAction("index");
        }
        [HttpGet]
        public async Task<IActionResult> Remove_Skill(int id)
        {
           await _skill.DeleteSkill(id);
            return RedirectToAction("Index");
        }
    }
}
