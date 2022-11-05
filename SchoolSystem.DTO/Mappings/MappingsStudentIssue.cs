using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.StudentIssues;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsStudentIssue : Profile
    {
        public MappingsStudentIssue()
        {
            CreateMap<StudentIssue, StudentIssueViewModel>();
            CreateMap<CreateUpdateStudentIssueViewModel, StudentIssue>();
        }
    }
}