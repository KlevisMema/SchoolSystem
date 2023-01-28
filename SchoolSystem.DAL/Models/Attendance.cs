using SchoolSystem.DAL.Enums;

namespace SchoolSystem.DAL.Models
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }

        // Realtionship properties related with clasroom model 1:M
        public Guid? TeacherId { get; set; }  = Guid.Empty;
        public virtual Teacher? Teacher { get; set; }
        public Guid? StudentId { get; set; } = Guid.Empty;
        public virtual Student? Student { get; set; }
    }
}