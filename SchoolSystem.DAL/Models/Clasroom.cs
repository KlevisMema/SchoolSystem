namespace SchoolSystem.DAL.Models
{
    public class Clasroom
    {
        public Guid Id { get; set; }
        public int Grade { get; set; }

        // Realtionship properties related with teacher model 1:M
        public Guid TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }

        // Relationship Property related with student model M:M
        public virtual ICollection<StudentClasroom>? Students { get; set; }

        // Relationship Property with subject model M:M
        public virtual ICollection<Subject>? Subjects { get; set; }

        // Realtionship properties related with TimeTable model 1:M
        public Guid TimeTableId { get; set; }
        public virtual TimeTable? TimeTable { get; set; }
    }
}