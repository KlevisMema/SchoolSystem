namespace SchoolSystem.DAL.Models
{
    public class Issue
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = String.Empty;
        public string Details { get; set; } = String.Empty;
        public bool IsResolved { get; set; }

        // Relationship property related with Issue model M:M
        public ICollection<StudentIssue>? Students { get; set; }
    }
}