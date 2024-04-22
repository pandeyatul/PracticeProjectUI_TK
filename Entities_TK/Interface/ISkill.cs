using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK.Interface
{
    public interface ISkill
    {
        public Task<IEnumerable<Skills>> GetAllSkills();
        public Task CreateSkill (Skills skills);
        public Task UpdateSkill(Skills skills);
        public Task DeleteSkill(int id);
    }
}
