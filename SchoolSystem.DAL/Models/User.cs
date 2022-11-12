using Microsoft.AspNetCore.Identity;
using SchoolSystem.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.DAL.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}")]
        public DateTime DateOfBirth { get; set; }
    }
}