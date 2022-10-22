using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Teacher;

namespace SchoolSystem.DTO.ObjectTransform
{
    public static class TeacherObjTransform
    {
        public static TeacherViewModel AsTeacherViewModel(this Teacher teacher)
        {
            return new TeacherViewModel
            {
                Id = teacher.Id,
                FullName = teacher.FullName,
                Email = teacher.Email,
                Password = teacher.Password,
                Adress = teacher.Adress,
                Date_Of_Join = teacher.Date_Of_Join,
                Phone = teacher.Phone,
                Sex = teacher.Sex,
            };
        }

        public static Teacher AsTeacherUpdate(this TeacherViewModel teacher)
        {
            return new Teacher
            {
                Id = teacher.Id,
                FullName = teacher.FullName,
                Email = teacher.Email,
                Password = teacher.Password,
                Adress = teacher.Adress,
                Date_Of_Join = teacher.Date_Of_Join,
                Phone = teacher.Phone,
                Sex = teacher.Sex,
            };
        }

        public static Teacher AsTeacherModel(this CreateTeacherViewModel teacher)
        {
            return new Teacher
            {
                FullName = teacher.FullName,
                Email = teacher.Email,
                Password = teacher.Password,
                Phone = teacher.Phone,
                Date_Of_Join = DateTime.UtcNow,
                Sex = teacher.Sex,
                Adress = teacher.Adress,
            };
        }
    }
}
