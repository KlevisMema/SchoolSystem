using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Exam;

namespace SchoolSystem.BLL.RepositoryService
{
    public class ExamService : IExamService
    {
        private readonly ICRUD<ExamViewModel, Exam, CreateUpdateExamViewModel> _CRUD;

        public ExamService(
            ICRUD<ExamViewModel, Exam, CreateUpdateExamViewModel> CRUD)
        {
            _CRUD = CRUD;
        }

        /// <summary>
        /// Get all exams from database
        /// </summary>
        /// <returns> a list of all exams</returns>
        public async Task<Response<List<ExamViewModel>>> GetExams()
        {
            var getAllExams = await _CRUD.GetAll();
            return getAllExams;
        }

        /// <summary>
        /// Get a single teacher
        /// </summary>
        /// <param name="id"> Id of a exam</param>
        /// <returns> The object of a specific teacher</returns>
        public async Task<Response<ExamViewModel>> GetExam(Guid id)
        {
            var getExam = await _CRUD.GetSpecificRecord(id, "Teacher");
            return getExam;
        }

        /// <summary>
        /// Updates a teacher  
        /// </summary>
        /// <param name="id">Id of a exam</param>
        /// <param name="examViewModel">Object that holds the new values of exam </param>
        /// <returns>The updated exam</returns>
        public async Task<Response<ExamViewModel>> PutExam(Guid id, CreateUpdateExamViewModel examViewModel)
        {
            var updateExam = await _CRUD.PutRecord(id, examViewModel, "Exam");
            return updateExam;
        }

        /// <summary>
        /// Creates a new exam 
        /// </summary>
        /// <param name="examViewModel">Exam object </param>
        /// <returns>The created exam</returns>
        public async Task<Response<ExamViewModel>> PostExam(CreateUpdateExamViewModel examViewModel)
        {
            var postExam = await _CRUD.PostRecord(examViewModel, "Exam");
            return postExam;
        }

        /// <summary>
        /// Deletes a exam 
        /// </summary>
        /// <param name="id">Id of the exam</param>
        /// <returns>A message telling if the exam was deleted or not</returns>
        public async Task<Response<ExamViewModel>> DeleteExam(Guid id)
        {
            var deleteExam = await _CRUD.DeleteRecord(id, "Exam");
            return deleteExam;
        }
    }
}