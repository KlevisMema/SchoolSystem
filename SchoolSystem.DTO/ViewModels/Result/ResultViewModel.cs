namespace SchoolSystem.DTO.ViewModels.Result
{
    public class ResultViewModel
    {
        public Guid Id { get; set; }
        public int Mark { get; set; }
        public Guid ExamId { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
