using SchoolSystem.DAL.BaseModel;

namespace SchoolSystem.DAL.Models
{
    public class Student : Person
    {
        public string ParentName { get; set; } = String.Empty;

        // Relationship Property with clasroom model M:M
        public ICollection<StudentClasroom>? Clasrooms { get; set; }

        // Relationship Property with result model M:M
        public ICollection<Result>? SubjectExams { get; set; }
    }
}