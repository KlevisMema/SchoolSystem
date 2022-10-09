using SchoolSystem.DAL.BaseModel;

namespace SchoolSystem.DAL.Models
{
    public class Student : Person
    {
        public string ParentName { get; set; } = String.Empty;

        // Relationship property related with Clasroom model M:M
        public ICollection<StudentClasroom>? Clasrooms { get; set; }

        // Relationship property related with Result model M:M
        public ICollection<Result>? SubjectExams { get; set; }

        // Relationship property related with Attendance model 1:M
        public virtual ICollection<Attendance>? Attendances { get; set; }

        // Relationship property related with Issue model M:M
        public ICollection<StudentIssue>? Issues { get; set; }
    }
}