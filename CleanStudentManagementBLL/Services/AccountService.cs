using CleanArchitectureStudentData.Entities;
using CleanArchitectureStudentData.UnitOfWork;
using CleanStudentManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementBLL.Services
{
    public class AccountService : IAccountService
    {
        private IUnitofWork _unitofwork;

        public AccountService(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public bool AddTeacher(UserViewModel model)
        {
            try
            {
                var teacher = new Users()
                {
                    Name = model.Name,
                    UserName = model.Username,
                    Passwprd = model.Password,
                    Role = (int)Roles.Teacher
                };
                _unitofwork.genericRepo<Users>().Add(teacher);
                _unitofwork.Save();
                return true;
            }
            catch (Exception)
            {

            }
            return true;

        }

        public PageResult<TeacherViewmodel> GetAll(int pageno, int pagesize)
        {
            try
            {
                int excluderecords = (pageno * pagesize) - pagesize;
                List<TeacherViewmodel> teacherlist = new List<TeacherViewmodel>();
                var users = _unitofwork.genericRepo<Users>().GetAll().Where(t => t.Role == (int)Roles.Teacher).ToList().Skip(excluderecords).Take(pagesize);
                teacherlist = listinfo(users);

                var result = new PageResult<TeacherViewmodel>
                {
                    data = teacherlist,
                    TotalItem = _unitofwork.genericRepo<Users>().GetAll().Where(t => t.Role == (int)Roles.Teacher).ToList().Count(),
                    PageNumber = pageno,
                    PageSize = pagesize
                };
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private List<TeacherViewmodel> listinfo(IEnumerable<Users> users)
        {
            return users.Select(x => new TeacherViewmodel(x)).ToList();
        }

        public LoginViewModel Login(LoginViewModel model)
        {
            if (model.Role == (int)Roles.Teacher || model.Role == (int)Roles.Admin)
            {

                var user = _unitofwork.genericRepo<Users>().GetAll().FirstOrDefault(x => x.UserName == model.UserName && x.Passwprd == model.Password && x.Role == model.Role);
                if (user != null)
                {
                    model.Id = user.Id;
                    return model;
                }
            }
            else
            {
                var student = _unitofwork.genericRepo<Student>().GetAll().FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
                if (student != null)
                {
                    model.Id = student.Id;
                    return model;
                }
            }
            return null;
        }
    }
}
