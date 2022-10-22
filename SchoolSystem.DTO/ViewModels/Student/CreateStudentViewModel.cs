using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SchoolSystem.DTO.ViewModels.Student
{
    public class CreateStudentViewModel
    {
        [Required(ErrorMessage = "Full name field is required")]
        [Display(Name = "Full name")]
        [StringLength(maximumLength: 60, MinimumLength = 7, ErrorMessage = "Invalid length of characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Parent name field is required")]
        [Display(Name = "Parent name")]
        [StringLength(maximumLength: 60, MinimumLength = 7, ErrorMessage = "Invalid length of characters")]
        public string ParentName { get; set; }

        [Required(ErrorMessage = "Email field is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field name is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone field is required")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Sex field is required")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Adress field is required")]
        public string Adress { get; set; }
    }
}
