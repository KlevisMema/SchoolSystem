using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.StudentClasroom;

namespace SchoolSystem.DTO.Mappings
{
    public class MappingsStudentClasroom : Profile
    {
        public MappingsStudentClasroom()
        {
            CreateMap<StudentClasroom, StudentClasroomViewModel>();
            CreateMap<CreateUpdateStudentClasroomViewModel, StudentClasroom>();
        }
    }
}