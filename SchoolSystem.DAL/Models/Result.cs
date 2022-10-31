namespace SchoolSystem.DAL.Models
{
    public class Result
    {
        public int Mark { get; set; }
        public Guid Id { get; set; }

        // Relationship properties between Studet->Exam->Subject M:M relaionship
        public Guid ExamId { get; set; }
        public virtual Exam? Exam { get; set; }
        public Guid StudentId { get; set; } 
        public virtual Student? Student { get; set; }
        public Guid SubjectId { get; set; }
        public virtual Subject? Subject { get; set; } 
    }
}