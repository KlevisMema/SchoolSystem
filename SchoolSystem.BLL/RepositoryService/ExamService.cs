using SchoolSystem.DAL.Models;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Exam;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

namespace SchoolSystem.BLL.RepositoryService
{
    public class ExamService : ICrudService<ExamViewModel, CreateUpdateExamViewModel>
    {
        private readonly CRUD<ExamViewModel, Exam, CreateUpdateExamViewModel> _CRUD;

        public ExamService
        (
            CRUD<ExamViewModel, Exam, CreateUpdateExamViewModel> CRUD
        )
        {
            _CRUD = CRUD;
        }

        /// <summary>
        /// Get all exams from database
        /// </summary>
        /// <returns> a list of all exams</returns>
        public async Task<Response<List<ExamViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllExams = await _CRUD.GetAll(cancellationToken);
            return getAllExams;
        }

        /// <summary>
        /// Get a single teacher
        /// </summary>
        /// <param name="id"> Id of a exam</param>
        /// <returns> The object of a specific exam</returns>
        public async Task<Response<ExamViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getExam = await _CRUD.GetSpecificRecord(id, "Exam", cancellationToken);
            return getExam;
        }

        /// <summary>
        /// Updates a exam  
        /// </summary>
        /// <param name="id">Id of a exam</param>
        /// <param name="viewModel">Object that holds the new values of exam </param>
        /// <returns>The updated exam</returns>
        public async Task<Response<ExamViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateExamViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updateExam = await _CRUD.PutRecord(id, viewModel, "Exam", cancellationToken);
            return updateExam;
        }

        /// <summary>
        /// Creates a new exam 
        /// </summary>
        /// <param name="viewModel">Exam object </param>
        /// <returns>The created exam</returns>
        public async Task<Response<ExamViewModel>> PostRecord
        (
            CreateUpdateExamViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postExam = await _CRUD.PostRecord(viewModel, "Exam", cancellationToken);
            return postExam;
        }

        /// <summary>
        /// Deletes a exam 
        /// </summary>
        /// <param name="id">Id of the exam</param>
        /// <returns>A message telling if the exam was deleted or not</returns>
        public async Task<Response<ExamViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteExam = await _CRUD.DeleteRecord(id, "Exam", cancellationToken);
            return deleteExam;
        }
    }
}