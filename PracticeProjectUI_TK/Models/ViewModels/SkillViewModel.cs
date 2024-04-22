using PracticeProjectUI_TK.Utility;

namespace PracticeProjectUI_TK.Models.ViewModels
{
    public class SkillViewModel
    {
        public int Skill_Id { get; set; }
        public string SkillName { get; set; } = string.Empty;
    }
    public class PagingSkillViewModel
    {
        public List<SkillViewModel> SkillList { get; set; } = new List<SkillViewModel>();
        public PageInfo pageInfo { get; set; }= new PageInfo();
    }
}
