#region Usings

using SchoolSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.DataBase.Configuration.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#endregion

namespace SchoolSystem.DAL.DataBase
{
    /// <summary>
    ///     Application database context class
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        #region Constructor 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #endregion

        #region DbSets

        /// <summary>
        ///     A Student instance used to perform LINQ or SQL queries
        /// </summary>
        public DbSet<Student> Students { get; set; }
        /// <summary>
        ///     A Teacher instance used to perform LINQ or SQL queries
        /// </summary>
        public DbSet<Teacher> Teachers { get; set; }
        /// <summary>
        ///     A Clasroom instance used to perform LINQ or SQL queries
        /// </summary>
        public DbSet<Clasroom> Clasrooms { get; set; }
        /// <summary>
        ///     A StudentClasroom instance used to perform LINQ or SQL queries
        /// </summary>
        public DbSet<StudentClasroom> StudentClasrooms { get; set; }
        /// <summary>
        ///     A Subject instance used to perform LINQ or SQL queries
        /// </summary>
        public DbSet<Subject> Subjects { get; set; }
        /// <summary>
        ///     A Exam instance used to perform LINQ or SQL queries
        /// </summary>
        public DbSet<Exam> Exams { get; set; }
        /// <summary>
        ///     A Result instance used to perform LINQ or SQL queries
        /// </summary>
        public DbSet<Result> Results { get; set; }
        /// <summary>
        ///     A TimeTable instance used to perform LINQ or SQL queries
        /// </summary>
        public DbSet<TimeTable> TimeTables { get; set; }
        /// <summary>
        ///     A Attendance instance used to perform LINQ or SQL queries
        /// </summary>
        public DbSet<Attendance> Attendances { get; set; }
        /// <summary>
        ///     A Issue instance used to perform LINQ or SQL queries
        /// </summary>
        public DbSet<Issue> Issues { get; set; }
        /// <summary>
        ///     A StudentIssue instance used to perform LINQ or SQL queries
        /// </summary>
        public DbSet<StudentIssue> StudentIssues { get; set; }

        #endregion

        #region Fluent API

        /// <summary>
        ///     Configure enitites on model creating with fluent API
        /// </summary>
        /// <param name="modelBuilder">Model builder object</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seedings

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ClasroomConfiguration());
            modelBuilder.ApplyConfiguration(new EamConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceConfiguration());

            #endregion

            #region Relationships Configuration

            #region Relationship Clasroom and Teacher

            // 1:M Clasroom -> Teacher
            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.Clasrooms)
                .WithOne(t => t.Teacher);

            modelBuilder.Entity<Clasroom>()
                .HasOne(t => t.Teacher)
                .WithMany(c => c.Clasrooms);

            #endregion

            #region Relationship Clasroom and Subject

            // 1:M Clasroom -> Subject
            modelBuilder.Entity<Clasroom>()
                .HasMany(c => c.Subjects)
                .WithOne(t => t.Clasroom);

            modelBuilder.Entity<Subject>()
                .HasOne(t => t.Clasroom)
                .WithMany(c => c.Subjects);

            #endregion

            #region Relationship Clasroom and TimeTable

            // 1:M Clasroom -> TimeTable
            modelBuilder.Entity<TimeTable>()
                .HasMany(c => c.Clasrooms)
                .WithOne(t => t.TimeTable);

            modelBuilder.Entity<Clasroom>()
                .HasOne(t => t.TimeTable)
                .WithMany(c => c.Clasrooms);

            #endregion

            #region Relationship Student and Attendance

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

            #endregion

            #region Relationship Teacher and Attendance

            // 1:M Teacher -> Attendance
            modelBuilder.Entity<Attendance>();

            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.Attendances)
                .WithOne(t => t.Teacher);

            modelBuilder.Entity<Attendance>()
                .HasOne(t => t.Teacher)
                .WithMany(c => c.Attendances)
                .HasForeignKey(x => x.TeacherId);

            #endregion

            #region Relationship Student and Clasroom

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

            #endregion

            #region Relationship Subject and Exam

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

            #endregion

            #region Relationship Student and Issue

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

            #endregion

            #endregion

        }

        #endregion
    }
}