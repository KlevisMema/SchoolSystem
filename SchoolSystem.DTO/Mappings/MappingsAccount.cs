using AutoMapper;
using SchoolSystem.DAL.Models;
using Microsoft.AspNetCore.Identity;
using SchoolSystem.DTO.ViewModels.Account;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsAccount : Profile
    {
        public MappingsAccount()
        {

            CreateMap<RegisterViewModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<LoginViewModel, User>();

            CreateMap<IdentityRole, RolesViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}