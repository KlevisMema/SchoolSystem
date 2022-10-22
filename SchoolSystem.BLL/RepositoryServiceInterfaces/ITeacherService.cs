using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Teacher;

namespace SchoolSystem.BLL.RepositoryServiceInterfaces
{
    public interface ITeacherService
    {
        Task<Response<TeacherViewModel>> DeleteTeacher(Guid id);
        Task<Response<TeacherViewModel>> GetTeacher(Guid id);
        Task<Response<IEnumerable<TeacherViewModel>>> GetTeachers();
        Task<Response<TeacherViewModel>> PostTeacher(CreateTeacherViewModel teacher);
        Task<Response<TeacherViewModel>> PutTeacher(Guid id, UpdateTeacherViewModel teacher);
    }
}