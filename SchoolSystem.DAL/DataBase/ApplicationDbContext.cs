﻿using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Models;

namespace SchoolSystem.DAL.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Clasroom> Clasrooms { get; set; }
        public DbSet<StudentClasroom> StudentClasrooms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Result> Results { get; set; }

        // Fluent API 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // M:M Student -> Clasroom
            modelBuilder.Entity<StudentClasroom>()
                .HasKey(fk => new { fk.StudentId, fk.ClasroomId });

            modelBuilder.Entity<StudentClasroom>()
                .HasOne(s => s.Student)
                .WithMany(c => c.Clasrooms)
                .HasForeignKey(c => c.StudentId);

            modelBuilder.Entity<StudentClasroom>()
               .HasOne(s => s.Clasroom)
               .WithMany(c => c.Students)
               .HasForeignKey(c => c.ClasroomId);

            // 1:M Clasroom -> Teacher
            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.Clasrooms)
                .WithOne(t => t.Teacher);

            modelBuilder.Entity<Clasroom>()
                .HasOne(t => t.Teacher)
                .WithMany(c => c.Clasrooms);

            // 1:M Clasroom -> Subject
            modelBuilder.Entity<Clasroom>()
               .HasMany(c => c.Subjects)
               .WithOne(t => t.Clasroom);

            modelBuilder.Entity<Subject>()
                .HasOne(t => t.Clasroom)
                .WithMany(c => c.Subjects);

            // M:M Student -> Subject -> Exam
            modelBuilder.Entity<Result>()
                .HasKey(fk => new { fk.StudentId, fk.ExamId, fk.SubjectId });

            modelBuilder.Entity<Result>()
                .HasOne(s => s.Student)
                .WithMany(c => c.SubjectExams)
                .HasForeignKey(c => c.StudentId);

            modelBuilder.Entity<Result>()
               .HasOne(s => s.Exam)
               .WithMany(c => c.StudentSubjects)
               .HasForeignKey(c => c.ExamId);

            modelBuilder.Entity<Result>()
              .HasOne(s => s.Subject)
              .WithMany(c => c.StudentExams)
              .HasForeignKey(c => c.SubjectId);
        }
    }
}