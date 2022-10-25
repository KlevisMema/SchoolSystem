using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Exam;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsExam : Profile
    {
        public MappingsExam()
        {
            CreateMap<Exam, ExamViewModel>();

            CreateMap<CreateUpdateExamViewModel, Exam>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
