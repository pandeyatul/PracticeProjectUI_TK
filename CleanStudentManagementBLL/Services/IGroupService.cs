using CleanStudentManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementBLL.Services
{
    public interface IGroupService
    {
        PageResult<GroupViewModel> GetAll(int pagenumber,int pagesize);
        IEnumerable<GroupViewModel> GetAllGroups();
        GroupViewModel GetById(int id);
        GroupViewModel AddGroup(GroupViewModel group);
    }
}
