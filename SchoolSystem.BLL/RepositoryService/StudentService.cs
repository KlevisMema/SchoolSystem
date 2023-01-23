#region Usings

using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Student;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Student service that implements ICrudService interface, I_Valid_Id interface, and has all the buisness logic related to attendance 
    /// </summary>
    public class StudentService : ICrudService<StudentViewModel, CreateUpdateStudentViewModel>, I_Valid_Id<Student>
    {
        #region Services 

        /// <summary>
        ///     A readonly field for logger      
        /// </summary>
        private readonly ILogger<StudentService> _logger;
        /// <summary>
        ///     A readonly field for database actions -> Create,Update,Delete,Get Actions
        /// </summary>
        private readonly DatabaseActionsService<StudentViewModel, Student, CreateUpdateStudentViewModel> _CRUD;

        /// <summary>
        ///     Inject services in constructor 
        /// </summary>
        /// <param name="logger"> Logger service </param>
        /// <param name="CRUD"> CRUD Service </param>
        public StudentService
        (
            ILogger<StudentService> logger,
            DatabaseActionsService<StudentViewModel, Student, CreateUpdateStudentViewModel> CRUD
        )
        {
            _CRUD = CRUD;
            _logger = logger;
        }

        #endregion

        #region Get all students from student table 

        /// <summary>
        ///     Get all student from database
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A list of all student</returns>

        public async Task<Response<List<StudentViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllStudents = await _CRUD.GetAll(cancellationToken);
            return getAllStudents;
        }

        #endregion

        #region Get a student by id from student table

        /// <summary>
        ///     Get a single student
        /// </summary>
        /// <param name="id"> Id of a student </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The object of a specific student </returns>

        public async Task<Response<StudentViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getStudent = await _CRUD.GetSpecificRecord(id, "Student", cancellationToken);
            return getStudent;
        }

        #endregion

        #region Create a new student in student table

        /// <summary>
        ///     Creates a new student 
        /// </summary>
        /// <param name="viewModel"> Teacher object </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The created student </returns>

        public async Task<Response<StudentViewModel>> PostRecord
        (
            CreateUpdateStudentViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postStudent = await _CRUD.PostRecord(viewModel, "Student", cancellationToken);
            return postStudent;
        }

        #endregion

        #region Update a existing student in student table 

        /// <summary>
        ///     Updates a student  
        /// </summary>
        /// <param name="id"> Id of a student </param>
        /// <param name="viewModel"> Object that holds the new values of student </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The updated student </returns>

        public async Task<Response<StudentViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateStudentViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updateStudent = await _CRUD.PutRecord(id, viewModel, "Student", cancellationToken);
            return updateStudent;
        }

        #endregion

        #region Delete a existing student by id from student table 

        /// <summary>
        ///     Deletes a student 
        /// </summary>
        /// <param name="id"> Id of the student </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A message telling if the student was deleted or not </returns>

        public async Task<Response<StudentViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteStudent = await _CRUD.DeleteRecord(id, "Student", cancellationToken);
            return deleteStudent;
        }

        #endregion

        #region Check if the student exist in student table 

        /// <summary>
        ///     Chkecks if the record exists in database 
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> True of false </returns>

        public async Task<bool> Bool
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var getAllStudents = await _CRUD.GetAll(cancellationToken);
                var result = getAllStudents.Value;
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