namespace SchoolSystem.DAL.Models
{
    public class Clasroom
    {
        // Clasroom properties
        public Guid Id { get; set; }
        public string Grade { get; set; } = String.Empty;

        // Realtionship properties with teacher model 1:M
        public Guid TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }

        // Relationship Property with student model M:M
        public ICollection<StudentClasroom>? Students { get; set; }

        // Relationship Property with subject model M:M
        public virtual ICollection<Subject>? Subjects { get; set; }
    }
}