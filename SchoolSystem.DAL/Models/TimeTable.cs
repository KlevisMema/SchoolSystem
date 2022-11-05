namespace SchoolSystem.DAL.Models
{
    public class TimeTable
    {
        public Guid Id { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Subject { get; set; } = String.Empty;

        // Relationship Property related with clasroom model 1:M
        public virtual ICollection<Clasroom>? Clasrooms { get; set; }
    }
}