namespace SchoolSystem.DAL.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        // Realtionship properties related with clasroom model 1:M
        public int Grade { get; set; }
        public virtual Clasroom? Clasroom { get; set; }

        // Relationship Property related with result model M:M
        public ICollection<Result>? StudentExams { get; set; }
    }
}