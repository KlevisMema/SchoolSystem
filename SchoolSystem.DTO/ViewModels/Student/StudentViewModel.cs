namespace SchoolSystem.DTO.ViewModels.Student
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime Date_Of_Join { get; set; }
        public string Sex { get; set; }
        public string Adress { get; set; }
        public string ParentName { get; set; }
    }
}