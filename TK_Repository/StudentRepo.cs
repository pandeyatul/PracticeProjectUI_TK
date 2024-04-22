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
    public class StudentRepo : IStudent
    {
        private ApplicationDbContext _context;

        public StudentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateStudent(Student student)
        {
           await _context.AddAsync(student);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var student = _context.StudentTbl.Include(s=>s.StudentSkills).FirstOrDefault(s => s.Id == id);
            _context.Remove(student);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            var studentlist =await _context.StudentTbl.ToListAsync();
            return studentlist;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student =await _context.StudentTbl.Include(s => s.StudentSkills).Include(a=>a.PermanentAddress).FirstOrDefaultAsync(x=>x.Id==id);
            return student??new Student();
        }

        public async Task UpdateStudent(Student student)
        {
            _context.StudentTbl.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
