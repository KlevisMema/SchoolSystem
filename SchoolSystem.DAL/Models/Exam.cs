namespace SchoolSystem.DAL.Models
{
    public class Exam
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Type { get; set; }

        // Relationship Property related with result model M:M
        public ICollection<Result>? StudentSubjects { get; set; }
    }
}