﻿using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels;

namespace SchoolSystem.DTO.ObjectTransform
{
    public static class StudentObjTransform
    {
        public static StudentViewModel AsStudentViewModel(this Student student)
        {
            return new StudentViewModel
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                Password = student.Password,
                Phone = student.Phone,
                Date_Of_Join = student.Date_Of_Join,
                Sex = student.Sex,
                Adress = student.Adress
            };
        }
    }
}