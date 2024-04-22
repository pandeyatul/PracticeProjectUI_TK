using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementModel
{
    public class GroupStudentViewModel
    {
        public int GroupId { get; set; }
        public List<Checkboxtable> StudentList { get; set; }=new();
    }
}
