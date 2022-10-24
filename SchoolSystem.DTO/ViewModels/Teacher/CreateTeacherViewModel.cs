using static SchoolSystem.DAL.Enums.GenderEnum;

namespace SchoolSystem.DTO.ViewModels.Teacher
{
    public class CreateTeacherViewModel
    {
        public string FullName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public Gender Sex { get; set; }
        public string Adress { get; set; } = String.Empty;
    }
}