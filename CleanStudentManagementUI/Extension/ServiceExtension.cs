using CleanArchitectureStudentData.UnitOfWork;
using CleanStudentManagementBLL.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanStudentManagementUI.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection ApplicationExtensionService(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("conn"), b => b.MigrationsAssembly("CleanStudentManagementUI")));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
             {
                 options.LoginPath = "/Account/Login";
                 options.AccessDeniedPath = "/Account/AccessDenied";
             });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUnitofWork, UnitOfWork>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IQnAnsService, QnAnsService>();
            services.AddScoped<IUtility, UtilityServices>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
