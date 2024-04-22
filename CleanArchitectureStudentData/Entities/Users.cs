using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string UserName { get; set; }=string.Empty;
        public string Passwprd { get; set; } = string.Empty;
        public int Role { get; set; }    
    }
}
