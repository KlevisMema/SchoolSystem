namespace SchoolSystem.DAL.Models
{
    public class StudentClasroom
    {
        public DateTime Created { get; set; }

        // Realtionship properties that will connect Student -> Clasroom M:M relationship
        public Guid StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public Guid ClasroomId { get; set; }
        public virtual Clasroom? Clasroom { get; set; }
    }
}