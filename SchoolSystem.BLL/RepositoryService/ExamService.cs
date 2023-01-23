#region Usings

using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Exam;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Exam service that implements ICrud interface, I_Valid_Id interface , and has all buisness logic related to exam
    /// </summary>
    public class ExamService : ICrudService<ExamViewModel, CreateUpdateExamViewModel>, I_Valid_Id<Exam>
    {
        #region Services

        /// <summary>
        ///    A readonly field for Logger
        /// </summary>
        private readonly ILogger<ExamService> _logger;
        /// <summary>
        ///    A readonly field for database actions -> Create,Update,Delete,Get Actions
        /// </summary>
        private readonly DatabaseActionsService<ExamViewModel, Exam, CreateUpdateExamViewModel> _CRUD;

        /// <summary>
        ///     Inject services in controller
        /// </summary>
        /// <param name="CRUD"> CRUD Service </param>
        /// <param name="logger"> Logger service </param>
        public ExamService
        (
            DatabaseActionsService<ExamViewModel, Exam, CreateUpdateExamViewModel> CRUD,
            ILogger<ExamService> logger
        )
        {
            _CRUD = CRUD;
            _logger = logger;
        }

        #endregion

        #region Get all exams from the exam table

        /// <summary>
        ///     Get all exams from database
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A list of all exams</returns>

        public async Task<Response<List<ExamViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllExams = await _CRUD.GetAll(cancellationToken);
            return getAllExams;
        }

        #endregion

        #region Get a single exam by id from exam table

        /// <summary>
        ///     Get a single teacher
        /// </summary>
        /// <param name="id"> Id of a exam</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
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

        #endregion

        #region Update a existing exam form exam table

        /// <summary>
        ///     Updates a exam  
        /// </summary>
        /// <param name="id"> Id of a exam</param>
        /// <param name="viewModel"> Object that holds the new values of exam </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The updated exam </returns>

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

        #endregion

        #region Creates a new exam in exam table 

        /// <summary>
        ///     Creates a new exam 
        /// </summary>
        /// <param name="viewModel"> Exam object </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The created exam </returns>

        public async Task<Response<ExamViewModel>> PostRecord
        (
            CreateUpdateExamViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postExam = await _CRUD.PostRecord(viewModel, "Exam", cancellationToken);
            return postExam;
        }

        #endregion

        #region Delete a exam by id in exam table

        /// <summary>
        ///     Deletes a exam 
        /// </summary>
        /// <param name="id"> Id of the exam </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message telling if the exam was deleted or not </returns>

        public async Task<Response<ExamViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteExam = await _CRUD.DeleteRecord(id, "Exam", cancellationToken);
            return deleteExam;
        }

        #endregion

        #region checks if the exams exists in the exam table or not  

        /// <summary>
        ///     Returns True or false if the exam exists in database
        /// </summary>
        /// <param name="id"> Id of the exam </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> True or false </returns>

        public async Task<bool> Bool
        (
            Guid id, 
            CancellationToken cancellationToken
        )
        {
            try
            {
                var getAllExams = await _CRUD.GetAll(cancellationToken);
                var result = getAllExams.Value;
                return result.Any(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {
                _logger.LogError
                (
                    ex,
                    $" Something went wrong \n" +
                    $"Error, something went wrong !! => \n " +
                    $" Method : {ex.TargetSite} \n" +
                    $" Source : {ex.Source} \n" +
                    $"InnerEx : {ex.InnerException} \n"
                );

                return false;
            }
        }

        #endregion

    }
}