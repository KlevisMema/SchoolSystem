using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels;

namespace SchoolSystem.BLL.RepositoryServiceInterfaces
{
    public interface IStudentService
    {
        Task<Response<List<StudentViewModel>>> GetStudets();
    }
}