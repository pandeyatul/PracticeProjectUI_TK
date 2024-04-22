using CleanArchitectureStudentData.Entities;
using CleanArchitectureStudentData.UnitOfWork;
using CleanStudentManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanStudentManagementBLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly UnitOfWork _unitofwork;

        public GroupService(UnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public GroupViewModel AddGroup(GroupViewModel groupvm)
        {
            try
            {
                var groupinfo = groupvm.ConvertToGroup(groupvm);
                _unitofwork.genericRepo<Groups>().Add(groupinfo);
                _unitofwork.Save();
            }
            catch (Exception)
            {
                throw;
            }
            return groupvm;
        }

        public PageResult<GroupViewModel> GetAll(int pagenumber, int pagesize)
        {
            int excluderecords = (pagenumber * pagesize) - pagesize;
            List<GroupViewModel> grouplist = new List<GroupViewModel>();
            var groups = _unitofwork.genericRepo<Groups>().GetAll().Skip(excluderecords).Take(pagesize);
            grouplist = listinfo(groups);

            var result = new PageResult<GroupViewModel>
            {
                data = grouplist,
                TotalItem = _unitofwork.genericRepo<Groups>().GetAll().ToList().Count(),
                PageNumber = pagenumber,
                PageSize = pagesize
            };
            return result;
        }
        private List<GroupViewModel> listinfo(IEnumerable<Groups> groups)
        {
            return groups.Select(x => new GroupViewModel(x)).ToList();
        }

        public IEnumerable<GroupViewModel> GetAllGroups()
        {
            try
            {
                List<GroupViewModel> grouplist = new List<GroupViewModel>();
                var groups = _unitofwork.genericRepo<Groups>().GetAll().ToList();
                grouplist = listinfo(groups);
                return grouplist;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public GroupViewModel GetById(int id)
        {
            try
            {
                var groupdata = _unitofwork.genericRepo<Groups>().GetById(id);
                var groupinfo = new GroupViewModel(groupdata);
                return groupinfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
