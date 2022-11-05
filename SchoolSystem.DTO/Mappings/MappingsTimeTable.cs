using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.TimeTable;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsTimeTable : Profile
    {
        public MappingsTimeTable()
        {
            CreateMap<TimeTable, TimeTableViewModel>();

            CreateMap<CreateUpdateTimeTableViewModel, TimeTable>()
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => DateTime.UtcNow.Day.ToString()))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => DateTime.Now.TimeOfDay.ToString()));
        }
    }
}