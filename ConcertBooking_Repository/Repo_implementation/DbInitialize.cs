using ConcertBooking_Entities;
using ConcertBooking_Infrastructure;
using ConcertBooking_Repository.Concert_Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking_Repository.Repo_implementation
{
    public class DbInitialize : IDbInitial
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public DbInitialize(UserManager<ApplicationUser> usermanager, RoleManager<IdentityRole> rolemanager)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
        }
        
        public Task Seeding()
        {
            if (!_rolemanager.RoleExistsAsync(Roles.AdminRole).GetAwaiter().GetResult())
            {
               var role = new IdentityRole(Roles.AdminRole);
                _rolemanager.CreateAsync(role).GetAwaiter().GetResult();
                var user = new ApplicationUser()
                {
                    Email="Admin2024@yopmail.com",
                    UserName="Admin2024@yopmail.com"
                };
                _usermanager.CreateAsync(user,"Admin@123").GetAwaiter().GetResult();
                _usermanager.AddToRoleAsync(user,Roles.AdminRole).GetAwaiter().GetResult();
            }
            return Task.CompletedTask;
        }
    }
}
