using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Student;

namespace SchoolSystem.BLL.RepositoryServiceInterfaces
{
    public interface IStudentService
    {
        Task<Response<List<StudentViewModel>>> GetStudets();
        Task<Response<StudentViewModel>> GetSpecificStudent(Guid id);
        Task<Response<StudentViewModel>> CreateStudent(CreateUpdateStudentViewModel newStudent);
        Task<Response<StudentViewModel>> PutStudent(Guid id, CreateUpdateStudentViewModel student);
        Task<Response<StudentViewModel>> DeleteStudent(Guid id);
    }
}