using Newtonsoft.Json;
using SchoolSystem.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.DTO.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [Compare("Password")]
        public string? PasswordConfirmation { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}