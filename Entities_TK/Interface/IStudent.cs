using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK.Interface
{
    public interface IStudent
    {
        public Task<IEnumerable<Student>> GetAllStudent();
        public Task<Student> GetStudentById(int id);
        public Task CreateStudent(Student student);
        public Task UpdateStudent(Student student);
        public Task DeleteStudent(int id);
    }
}
