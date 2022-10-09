namespace SchoolSystem.DAL.Models
{
    public class StudentIssue
    {
        // Realtionship properties that will connect Student -> Issue M:M relationship
        public Guid StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public Guid IssueId { get; set; }
        public virtual Issue? Issue { get; set; }
    }
}