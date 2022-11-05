using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Issue;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsIssue : Profile
    {
        public MappingsIssue()
        {
            CreateMap<Issue, IssueViewModel>();
            CreateMap<CreateUpdateIssueViewModel, Issue>();
        }
    }
}