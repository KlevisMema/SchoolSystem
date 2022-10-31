using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Subject;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsSubject : Profile
    {
        public MappingsSubject()
        {
            CreateMap<Subject, SubjectViewModel>();
            CreateMap<CreateUpdateSubjectViewModel, Subject>();
        }
    }
}