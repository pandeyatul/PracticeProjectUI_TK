using CleanArchitectureStudentData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.UnitOfWork
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option):base(option)
        {
            
        }
        public DbSet<Users>? UserTbl { get; set; }
        public DbSet<Groups>? GroupTbl { get; set; }
        public DbSet<Student> StudentTbl { get; set; }
        public DbSet<Exam>? ExamTbl { get; set;}
        public DbSet<ExamResult>? ExamResultTbl { get;} 
        public DbSet<QuesAnswer>? QuesAnswerTbl { get;set; }
    }
}
