using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Clasroom;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsClasroom : Profile
    {
        public MappingsClasroom()
        {
            CreateMap<Clasroom, ClasroomViewModel>();
            CreateMap<CreateUpdateClasroomViewModel, Clasroom>();
        }
    }
}