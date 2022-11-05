namespace SchoolSystem.DTO.ViewModels.Issue
{
    public class CreateUpdateIssueViewModel
    {
        public string Type { get; set; }
        public string Details { get; set; }
        public bool? IsResolved { get; set; } = false;
    }
}