using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Attendance;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsAttendance : Profile
    {
        public MappingsAttendance()
        {
            CreateMap<Attendance, AttendanceViewModel>();

            CreateMap<CreateUpdateAttendanceViewModel, Attendance>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}