using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Student;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsStudent : Profile
    {
        public MappingsStudent()
        {
            CreateMap<Student, StudentViewModel>();

            CreateMap<CreateUpdateStudentViewModel, Student>()
                .ForMember(dest => dest.Date_Of_Join, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
