namespace SchoolSystem.DTO.ViewModels.Result
{
    public class CreateUpdateResultViewModel
    {
        public int Mark { get; set; }
        public Guid ExamId { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
    }
}