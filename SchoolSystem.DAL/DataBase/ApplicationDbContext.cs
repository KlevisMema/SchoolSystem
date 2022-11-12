using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Configuration.Entities;
using SchoolSystem.DAL.Models;

namespace SchoolSystem.DAL.DataBase
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Clasroom> Clasrooms { get; set; }
        public DbSet<StudentClasroom> StudentClasrooms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<StudentIssue> StudentIssues { get; set; }

        // Fluent API 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seedig roles onmodel creating
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            /// Relationship between models configuration
            ///

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

            // 1:M Clasroom -> TimeTable
            modelBuilder.Entity<TimeTable>()
                .HasMany(c => c.Clasrooms)
                .WithOne(t => t.TimeTable);

            modelBuilder.Entity<Clasroom>()
                .HasOne(t => t.TimeTable)
                .WithMany(c => c.Clasrooms);

            // 1:M Student -> Attendance

            modelBuilder.Entity<Attendance>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Student>()
                .HasMany(c => c.Attendances)
                .WithOne(t => t.Student);

            modelBuilder.Entity<Attendance>()
                .HasOne(t => t.Student)
                .WithMany(c => c.Attendances)
                .HasForeignKey(x => x.StudentId);

            // 1:M Teacher -> Attendance
            modelBuilder.Entity<Attendance>();

            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.Attendances)
                .WithOne(t => t.Teacher);

            modelBuilder.Entity<Attendance>()
                .HasOne(t => t.Teacher)
                .WithMany(c => c.Attendances)
                .HasForeignKey(x=>x.TeacherId);

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

            // M:M Student -> Subject -> Exam
            modelBuilder.Entity<Result>()
                .HasKey(pk => pk.Id);

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

            // M:M Student -> Issue
            modelBuilder.Entity<StudentIssue>()
                .HasKey(fk => new { fk.StudentId, fk.IssueId });

            modelBuilder.Entity<StudentIssue>()
                .HasOne(s => s.Student)
                .WithMany(c => c.Issues)
                .HasForeignKey(c => c.StudentId);

            modelBuilder.Entity<StudentIssue>()
                .HasOne(s => s.Issue)
                .WithMany(c => c.Students)
                .HasForeignKey(c => c.IssueId);
        }
    }
}