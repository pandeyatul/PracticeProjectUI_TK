using Entities_TK;
using PracticeProjectUI_TK.Validations;

namespace PracticeProjectUI_TK.Models.ViewModels
{
    public class CreateStudentViewModel
    {
        public int Id { get; set; }
        [Uppercase]
        public string Student_name { get; set; } = string.Empty;
        public Address Permanent_Address { get; set; }=new Address();
        public List<CheckBoxTable> Skilllist { get; set; }=new List<CheckBoxTable>();
    }
    public class CheckBoxTable
    {
        public int Skillid { get; set; }
        public string SkillName { get; set; }=string.Empty;
        public bool IsChecked { get; set; }
    }
}
