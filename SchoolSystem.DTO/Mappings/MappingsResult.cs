using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Result;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsResult : Profile
    {
        public MappingsResult()
        {
            CreateMap<Result, ResultViewModel>();

            CreateMap<CreateUpdateResultViewModel, Result>();
        }
    }
}