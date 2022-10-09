namespace SchoolSystem.DAL.Models
{
    public class Attendance
    {
        public Guid Id { get; set; }   
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        // Realtionship properties related with clasroom model 1:M
        public Guid TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student? Student { get; set; }
    }
}