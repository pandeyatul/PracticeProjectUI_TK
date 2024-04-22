using Entities_TK;
using Entities_TK.Interface;
using Microsoft.EntityFrameworkCore;
using PracticeProjectUI_TK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Repository
{
    public class SkillRepo : ISkill
    {
        private ApplicationDbContext _context;

        public SkillRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateSkill(Skills skills)
        {
            await _context.AddAsync(skills);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSkill(int id)
        {
            var skill = await _context.SkillsTbl.FirstOrDefaultAsync(s => s.Id == id);
            _context.Remove(skill);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Skills>> GetAllSkills()
        {
            var skilllist = await _context.SkillsTbl.ToListAsync();
            return skilllist;
        }

        public async Task UpdateSkill(Skills skills)
        {
            _context.SkillsTbl.Update(skills);
            await _context.SaveChangesAsync();
        }
    }
}
