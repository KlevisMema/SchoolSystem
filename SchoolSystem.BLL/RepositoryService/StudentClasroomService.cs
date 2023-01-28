#region Usings

using SchoolSystem.DAL.Models;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Student clasroom service that implements ICrud interface, and has all buisness logic related to students 
    /// </summary>
    public class StudentClasroomService : ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel>
    {
        #region Services 

        /// <summary>
        ///     A readonly field for database actions -> Create,Update,Delete,Get Actions
        /// </summary>
        private readonly DatabaseActionsService<StudentClasroomViewModel, StudentClasroom, CreateUpdateStudentClasroomViewModel> _CRUD;

        /// <summary>
        ///     Inject services in constructor
        /// </summary>
        /// <param name="CRUD"> CRUD Services </param>
        public StudentClasroomService
        (
            DatabaseActionsService<StudentClasroomViewModel, StudentClasroom, CreateUpdateStudentClasroomViewModel> CRUD
        )
        {
            _CRUD = CRUD;
        }

        #endregion

        #region Get all student clasrooms form studentclaroom table 

        /// <summary>
        ///     Get all exams from studentclasrooms
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A list of all studentclasrooms </returns>

        public async Task<Response<List<StudentClasroomViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllStudentClasrooms = await _CRUD.GetAll(cancellationToken);
            return getAllStudentClasrooms;
        }

        #endregion

        #region Get a student clasroom by id in studentclaroom table

        /// <summary>
        ///     Get a single studentclasroom
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <param name="id"> Id of a studentclasroom </param>
        /// <returns> The object of a specific studentclasroom </returns>
        public async Task<Response<StudentClasroomViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getStudentClasroom = await _CRUD.GetSpecificRecord(id, "Student Clasroom", cancellationToken);
            return getStudentClasroom;
        }

        #endregion

        #region Update an existing student clasroom in studentclasroom table

        /// <summary>
        ///     Updates a student clasroom  
        /// </summary>
        /// <param name="id"> Id of a student clasroom </param>
        /// <param name="viewModel"> Object that holds the new values of student clasroom  </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The updated student clasroom </returns>

        public async Task<Response<StudentClasroomViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateStudentClasroomViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updateStudentClasroom = await _CRUD.PutRecord(id, viewModel, "Student Clasroom", cancellationToken);
            return updateStudentClasroom;
        }

        #endregion

        #region Creates a new student clas room in studentclasoom table

        /// <summary>
        ///     Creates a new student clasroom 
        /// </summary>
        /// <param name="viewModel"> Student clasroom  object </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The created student clasroom </returns>

        public async Task<Response<StudentClasroomViewModel>> PostRecord
        (
            CreateUpdateStudentClasroomViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postStudentClasroom = await _CRUD.PostRecord(viewModel, "Student Clasroom", cancellationToken);
            return postStudentClasroom;
        }

        #endregion

        #region Deletes a existing student clasroom by id in studentclasroom table

        /// <summary>
        ///     Deletes a student clasroom  
        /// </summary>
        /// <param name="id"> Id of the student clasroom </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message telling if the student clasroom was deleted or not </returns>

        public async Task<Response<StudentClasroomViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteStudentClasroom = await _CRUD.DeleteRecord(id, "Student Clasroom", cancellationToken);
            return deleteStudentClasroom;
        }

        #endregion

    }
}