using CleanArchitectureStudentData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.UnitOfWork
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<Users>? UserTbl { get; set; }
        public DbSet<Groups>? GroupTbl { get; set; }
        public DbSet<Student>? StudentTbl { get; set; }
        public DbSet<Exam>? ExamTbl { get; set; }
        public DbSet<ExamResult>? ExamResultTbl { get; set; }
        public DbSet<QuesAnswer>? QuesAnswerTbl { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.HasOne(x => x.Exam).
            WithMany(p => p.examResults).HasForeignKey(f => f.ExamId).HasConstraintName("FK_ExamResults_Exams");
                entity.HasOne(a => a.quesAnswer)
                .WithMany(w => w.ExamResults).HasForeignKey(q => q.QuesAnsId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ExamResult_QuesId");

                entity.HasOne(s => s.student).
                WithMany(r => r.ExamResults).HasForeignKey(f => f.StudentId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Student_ExamResult");



            });
            modelBuilder.Entity<Users>().HasData(
                new Users { Id = 1, Name = "Admin", UserName = "Admin", Passwprd = "Admin@2024", Role = 1 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
