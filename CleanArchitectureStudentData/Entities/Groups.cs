using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.Entities
{
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty; 
        public virtual ICollection<Student> Students { get; set; }=new HashSet<Student>();
        public virtual ICollection<Exam> exams { get; set; }= new HashSet<Exam>();
    }
}
