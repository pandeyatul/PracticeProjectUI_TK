 

namespace Entities_TK
{
    public class Skills
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public ICollection<StudentSkill> StudentSkills { get; set;}=new List<StudentSkill>();
    }
}
