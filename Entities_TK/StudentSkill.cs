using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK
{
    public class StudentSkill
    {
        public int Id { get; set; }
        public int StudentsId { get; set; }
        public Student? Students { get; set; }
        public int SkillId { get; set; }
        public Skills? Skill { get; set; }
    }
}
