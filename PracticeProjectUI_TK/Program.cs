using Microsoft.EntityFrameworkCore;
using PracticeProjectUI_TK.Data;
using Entities_TK.Interface;
using TK_Repository;
using Entities_TK;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn"), a => a.MigrationsAssembly("PracticeProjectUI_TK")));
builder.Services.AddScoped<InterfaceCollection>();
builder.Services.AddScoped<ICountry, CountryRepository>();
builder.Services.AddScoped<IState, StateRepository>();
builder.Services.AddScoped<ICity, CityRepository>();
builder.Services.AddScoped<IStudent, StudentRepo>();
builder.Services.AddScoped<ISkill, SkillRepo>();

builder.Services.AddTransient<IUsers, UserRepository>();
builder.Services.AddTransient<IUtility, UtilityRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(10);
    option.Cookie.HttpOnly = true;
});
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.Use(async(context, next)=>{
//    string cookies = string.Empty;
//    if (context.Request.Cookies.TryGetValue("Language",out cookies!))
//    {
//        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookies);
//        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookies);
//    }
//    else
//    {
//        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
//        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
//    }
//    await next.Invoke();
//});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaxPayer}/{action=Save}/{id?}");

app.Run();
 