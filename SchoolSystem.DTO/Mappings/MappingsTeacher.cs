using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Teacher;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsTeacher : Profile
    {
        public MappingsTeacher()
        {
            //CreateMap<CreateTeacherViewModel, Teacher>()
            //    .ForMember(dest => dest.Date_Of_Join, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Teacher, TeacherViewModel>();

            
        }
    }
}
