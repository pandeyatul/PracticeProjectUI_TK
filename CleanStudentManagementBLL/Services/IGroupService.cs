using CleanStudentManagementModel;
 

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
