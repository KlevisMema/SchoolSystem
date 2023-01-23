#region Usings

using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Teacher;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Teacher service that implements ICrud Service interface, I_Valid_Id interface, and has all buisness logic related to teacher 
    /// </summary>
    public class TeacherService : ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel>, I_Valid_Id<Teacher>
    {
        #region Services  

        /// <summary>
        ///      A readonly field for logger   
        /// </summary>
        private readonly ILogger<TeacherService> _logger;
        /// <summary>
        ///     A readonly field for database actions -> Create,Update,Delete,Get Actions
        /// </summary>
        private readonly DatabaseActionsService<TeacherViewModel, Teacher, CreateUpdateTeacherViewModel> _CRUD;

        /// <summary>
        ///     Inject services in constructor 
        /// </summary>
        /// <param name="logger"> Logger service </param>
        /// <param name="CRUD"> CRUD Service </param>
        public TeacherService
        (
            ILogger<TeacherService> logger,
            DatabaseActionsService<TeacherViewModel, Teacher, CreateUpdateTeacherViewModel> CRUD
        )
        {
            _CRUD = CRUD;
            _logger = logger;
        }

        #endregion

        #region Get all teachers from teacher table  

        /// <summary>
        ///     Get all teachers from database
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A list of all teachers </returns>

        public async Task<Response<List<TeacherViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllTeachers = await _CRUD.GetAll(cancellationToken);
            return getAllTeachers;
        }

        #endregion

        #region Get a teacher by id from teacher table

        /// <summary>
        ///     Get a single teacher
        /// </summary>
        /// <param name="id"> Id of a teacher </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The object of a specific teacher </returns>

        public async Task<Response<TeacherViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getTeacher = await _CRUD.GetSpecificRecord(id, "Teacher", cancellationToken);
            return getTeacher;
        }

        #endregion

        #region Create a new teacher in teacher table 

        /// <summary>
        ///     Creates a new teacher 
        /// </summary>
        /// <param name="viewModel">Teacher object </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The created teacher </returns>

        public async Task<Response<TeacherViewModel>> PostRecord
        (
            CreateUpdateTeacherViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postTeacher = await _CRUD.PostRecord(viewModel, "Teacher", cancellationToken);
            return postTeacher;
        }

        #endregion

        #region Update an existing teacher form teacher table 

        /// <summary>
        ///     Updates a teacher  
        /// </summary>
        /// <param name="id"> Id of a teacher</param>
        /// <param name="viewModel"> Object that holds the new values of teacher </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The updated teacher </returns>

        public async Task<Response<TeacherViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateTeacherViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updateTeacher = await _CRUD.PutRecord(id, viewModel, "Teacher", cancellationToken);
            return updateTeacher;
        }

        #endregion

        #region Delete an existing teacher from teacher table 

        /// <summary>
        ///     Deletes a teacher 
        /// </summary>
        /// <param name="id"> Id of the teacher </param>
        /// <returns> A message telling if the teacher was deleted or not </returns>

        public async Task<Response<TeacherViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteTeacher = await _CRUD.DeleteRecord(id, "Teacher", cancellationToken);
            return deleteTeacher;
        }

        #endregion

        #region Check if a teacher exist in teacher table 

        /// <summary>
        ///     Returns True or false if the teacher exists in database
        /// </summary>
        /// <param name="id"> Id of the teacher </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> True or false </returns>

        public async Task<bool> Bool
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var getAllTeachers = await _CRUD.GetAll(cancellationToken);
                var result = getAllTeachers.Value;
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