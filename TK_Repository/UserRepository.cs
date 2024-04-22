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
    public class UserRepository : IUsers
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Users> GetUser(string username, string password)
        {
            var userinfo = await _dbcontext.UsersTbl?.FirstOrDefaultAsync(u=>u.UserName.ToLower()==username.ToLower() && u.Passowrd==password);
            if (userinfo!=null)
            {
                return userinfo ;
            }
            return new Users();
        }
        public async Task RegisterUser(Users users)
        {
            var IsUserExist = _dbcontext?.UsersTbl?.Any(x=>x.UserName==users.UserName);
            if (IsUserExist==false)
            {
                await _dbcontext.AddAsync(users);
               await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
