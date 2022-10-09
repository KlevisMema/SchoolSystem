using SchoolSystem.DAL.BaseModel;

namespace SchoolSystem.DAL.Models
{
    public class Teacher : Person
    {
        // Relationship Property related with clasroom model 1:M
        public virtual ICollection<Clasroom>? Clasrooms { get; set; }

        // Relationship Property related with attendance model 1:M
        public virtual ICollection<Attendance>? Attendances { get; set; }
    }
}