﻿using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.DTO.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email field is required ")]
        [EmailAddress(ErrorMessage = "Email is not a vaild email format")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password field is required")]
        [StringLength(maximumLength: 30, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string? Password { get; set; }
    }
}