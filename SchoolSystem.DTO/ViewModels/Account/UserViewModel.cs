﻿namespace SchoolSystem.DTO.ViewModels.Account
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
    }
}