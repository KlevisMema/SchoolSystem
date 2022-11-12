using FluentValidation;
using SchoolSystem.DAL.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Attendance API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AttendancesController : ControllerBase
    {
        private readonly I_Valid_Id<Teacher> _Teacher_Valid_Id;
        private readonly I_Valid_Id<Student> _Student_Valid_Id;
        private readonly IValidator<CreateUpdateAttendanceViewModel> _modelValidator;
        private readonly StatusCodeResponse<AttendanceViewModel, List<AttendanceViewModel>> _statusCodeResponse;
        private readonly ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel> _attendanceService;
        private async Task<CustomMesageResponse> ValidateId
        (
            Guid teacherId, 
            Guid studentId
        )
        {
            var teacher = await _Teacher_Valid_Id.Bool(teacherId);
            var student = await _Student_Valid_Id.Bool(studentId);

            if (!teacher)
                return CustomMesageResponse.NotFound(teacher, "Invalid teacher id");
            if (!student)
                return CustomMesageResponse.NotFound(student, "Invalid student id");

            return CustomMesageResponse.Succsess();
        }

        /// <summary>
        /// Inject services 
        /// </summary>
        /// <param name="attendanceService">Exam service</param>
        /// <param name="statusCodeResponse">status code response service</param>
        /// <param name="modelValidator">Model validation service</param>
        /// <param name="Teacher_Valid_Id"></param>
        /// <param name="student_Valid_Id"></param>
        public AttendancesController
        (
            I_Valid_Id<Teacher> Teacher_Valid_Id,
            I_Valid_Id<Student> student_Valid_Id,
            IValidator<CreateUpdateAttendanceViewModel> modelValidator,
            ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel> attendanceService,
            StatusCodeResponse<AttendanceViewModel, List<AttendanceViewModel>> statusCodeResponse
        )
        {
            _modelValidator = modelValidator;
            _Teacher_Valid_Id = Teacher_Valid_Id;
            _Student_Valid_Id = student_Valid_Id;
            _attendanceService = attendanceService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        /// Get all attendances
        /// </summary>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<AttendanceViewModel>>> GetAttendances
        (
        )
        {
            var attendances = await _attendanceService.GetRecords();
            return _statusCodeResponse.ControllerResponse(attendances);
        }

        /// <summary>
        /// Get an attendance
        /// </summary>
        /// <param name="id">Id of the attendance</param>
        /// <returns>Details of that attendance</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AttendanceViewModel>> GetAttendance
        (
            [FromRoute] Guid id
        )
        {
            var attendance = await _attendanceService.GetRecord(id);
            return _statusCodeResponse.ControllerResponse(attendance);
        }

        /// <summary>
        /// Update an attendance
        /// </summary>
        /// <param name="id">Id of the  attendance</param>
        /// <param name="attendance">attendance object from client</param>
        /// <returns>The updated attendance </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> PutAttendance
        (
            [FromRoute] Guid id, 
            [FromForm] CreateUpdateAttendanceViewModel attendance
        )
        {
            var Ids = await ValidateId(attendance.TeacherId, attendance.StudentId);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(attendance);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updatedAttendance = await _attendanceService.PutRecord(id, attendance);
            return _statusCodeResponse.ControllerResponse(updatedAttendance);
        }

        /// <summary>
        /// Creates an attendance 
        /// </summary>
        /// <param name="attendance">attendance object from client</param>
        /// <remarks> 
        ///  Status contains Present with value of 1 and Missing with value of 2
        /// </remarks>
        /// <returns>A message id attendance was created or not</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AttendanceViewModel>> PostAttendance
        (
            [FromForm] CreateUpdateAttendanceViewModel attendance
        )
        {
            var Ids = await ValidateId(attendance.TeacherId, attendance.StudentId);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(attendance);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createAttendance = await _attendanceService.PostRecord(attendance);
            return _statusCodeResponse.ControllerResponse(createAttendance);
        }

        /// <summary>
        /// Deletes an attendance
        /// </summary>
        /// <param name="id">Id of the attendance</param>
        /// <returns>A message if the attendance was deleted or not</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteAttendance
        (   
            [FromRoute] Guid id
        )
        {
            var deleteAttendance = await _attendanceService.DeleteRecord(id);
            return _statusCodeResponse.ControllerResponse(deleteAttendance);
        }
    }
}