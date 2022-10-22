namespace SchoolSystem.DTO.ViewModels.Teacher
{
    public class TeacherViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime Date_Of_Join { get; set; }
        public string Sex { get; set; }
        public string Adress { get; set; }
    }
}
