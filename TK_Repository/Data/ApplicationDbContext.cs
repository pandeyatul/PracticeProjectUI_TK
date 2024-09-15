using Microsoft.EntityFrameworkCore;
using Entities_TK;

namespace PracticeProjectUI_TK.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option):base(option)
        {

        }
        public DbSet<Country>? countryTbl { get; set; }
        public DbSet<City>? cityTbl { get; set; }
        public DbSet<State>? stateTbl { get; set; }
        public DbSet<Users>? UsersTbl { get; set; }
        public DbSet<Student> StudentTbl { get; set; }
        public DbSet<Skills> SkillsTbl { get; set; }
        public DbSet<Taxpayer> TaxpayerTbl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSkill>().HasKey(x =>new { x.StudentsId,x.SkillId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
