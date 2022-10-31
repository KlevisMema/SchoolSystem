using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DAL.DataBase;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Attendance;

namespace SchoolSystem.BLL.RepositoryService
{
    public class AttendanceService : ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel>
    {
        private readonly CRUD<AttendanceViewModel, Attendance, CreateUpdateAttendanceViewModel> _CRUD;
        private readonly ApplicationDbContext _context;

        public AttendanceService(
            CRUD<AttendanceViewModel, Attendance, CreateUpdateAttendanceViewModel> CRUD, ApplicationDbContext context)
        {
            _CRUD = CRUD;
            _context = context;
        }

        /// <summary>
        /// Get all exams from attendances
        /// </summary>
        /// <returns> a list of all attendances</returns>
        public async Task<Response<List<AttendanceViewModel>>> GetRecords()
        {
            var getAllAttendances = await _CRUD.GetAll();
            return getAllAttendances;
        }

        /// <summary>
        /// Get a single attendance
        /// </summary>
        /// <param name="id"> Id of a attendance</param>
        /// <returns> The object of a specific attendance</returns>
        public async Task<Response<AttendanceViewModel>> GetRecord(Guid id)
        {
            var getAttendance = await _CRUD.GetSpecificRecord(id, "Attendance");
            return getAttendance;
        }

        /// <summary>
        /// Updates a attendance  
        /// </summary>
        /// <param name="id">Id of a eattendancexam</param>
        /// <param name="viewModel">Object that holds the new values of attendance </param>
        /// <returns>The updated attendance</returns>
        public async Task<Response<AttendanceViewModel>> PutRecord(Guid id, CreateUpdateAttendanceViewModel viewModel)
        {
            var updateAttendance = await _CRUD.PutRecord(id, viewModel, "Attendance");
            return updateAttendance;
        }

        /// <summary>
        /// Creates a new attendance 
        /// </summary>
        /// <param name="viewModel">attendance object </param>
        /// <returns>The created attendance</returns>
        public async Task<Response<AttendanceViewModel>> PostRecord(CreateUpdateAttendanceViewModel viewModel)
        {
            var postAttendance = await _CRUD.PostRecord(viewModel, "Attendance");
            return postAttendance;
        }

        /// <summary>
        /// Deletes a attendance 
        /// </summary>
        /// <param name="id">Id of the attendance</param>
        /// <returns>A message telling if the attendance was deleted or not</returns>
        public async Task<Response<AttendanceViewModel>> DeleteRecord(Guid id)
        {
            var deleteAttendance = await _CRUD.DeleteRecord(id, "Attendance");
            return deleteAttendance;
        }
    }
}