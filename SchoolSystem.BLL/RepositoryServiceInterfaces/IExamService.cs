using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Exam;

namespace SchoolSystem.BLL.RepositoryServiceInterfaces
{
    public interface IExamService
    {
        Task<Response<ExamViewModel>> DeleteExam(Guid id);
        Task<Response<ExamViewModel>> GetExam(Guid id);
        Task<Response<List<ExamViewModel>>> GetExams();
        Task<Response<ExamViewModel>> PostExam(CreateUpdateExamViewModel examViewModel);
        Task<Response<ExamViewModel>> PutExam(Guid id, CreateUpdateExamViewModel examViewModel);
    }
}