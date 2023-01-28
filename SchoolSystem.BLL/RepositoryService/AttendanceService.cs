#region Usings

using SchoolSystem.DAL.Models;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Attendance service that implements ICrud Service interface, and has all buisness logic related to attendance
    /// </summary>
    public class AttendanceService : ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel>
    {
        #region Services 

        /// <summary>
        ///     A readonly field for database actions -> Create,Update,Delete,Get Actions
        /// </summary>
        private readonly DatabaseActionsService<AttendanceViewModel, Attendance, CreateUpdateAttendanceViewModel> _CRUD;

        /// <summary>
        ///     Inject services in constructor
        /// </summary>
        /// <param name="CRUD"> CRUD Services </param>
        public AttendanceService
        (
            DatabaseActionsService<AttendanceViewModel, Attendance, CreateUpdateAttendanceViewModel> CRUD
        )
        {
            _CRUD = CRUD;
        }

        #endregion

        #region Get all attendances from attendance table 

        /// <summary>
        ///     Get attendances
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A list of all attendances </returns>

        public async Task<Response<List<AttendanceViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllAttendances = await _CRUD.GetAll(cancellationToken);
            return getAllAttendances;
        }

        #endregion

        #region Get a specific Attendance by id from attendance table 

        /// <summary>
        ///     Get a single attendance by id
        /// </summary>
        /// <param name="id"> Id of a attendance</param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The object of a specific attendance </returns>

        public async Task<Response<AttendanceViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getAttendance = await _CRUD.GetSpecificRecord(id, "Attendance", cancellationToken);
            return getAttendance;
        }

        #endregion

        #region Update a attendance in attendance table 

        /// <summary>
        ///     Updates a attendance  
        /// </summary>
        /// <param name="id"> Id of a attendance</param>
        /// <param name="viewModel"> Object that holds the new values of attendance </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The updated attendance </returns>

        public async Task<Response<AttendanceViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateAttendanceViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updateAttendance = await _CRUD.PutRecord(id, viewModel, "Attendance", cancellationToken);
            return updateAttendance;
        }

        #endregion

        #region Create a new attendance in attendance table 

        /// <summary>
        ///     Creates a new attendance 
        /// </summary>
        /// <param name="viewModel"> Attendance object </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The created attendance</returns>

        public async Task<Response<AttendanceViewModel>> PostRecord
        (
            CreateUpdateAttendanceViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postAttendance = await _CRUD.PostRecord(viewModel, "Attendance", cancellationToken);
            return postAttendance;
        }

        #endregion

        #region Delete a attendance by id in attendance table 

        /// <summary>
        ///     Deletes a attendance by id
        /// </summary>
        /// <param name="id"> Id of the attendance </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A message telling if the attendance was deleted or not </returns>
        public async Task<Response<AttendanceViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteAttendance = await _CRUD.DeleteRecord(id, "Attendance", cancellationToken);
            return deleteAttendance;
        }

        #endregion
    }
}