namespace SchoolSystem.DTO.ViewModels.Issue
{
    public class IssueViewModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public bool IsResolved { get; set; }
    }
}