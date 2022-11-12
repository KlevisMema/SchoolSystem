using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Account;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsAccount : Profile
    {
        public MappingsAccount()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}