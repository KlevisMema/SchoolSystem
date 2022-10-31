using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.DTO.ViewModels.StudentClasroom;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// StudentClasroom API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentClasroomsController : ControllerBase
    {
        private readonly ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> _studentClasroomService;
        private readonly IValidator<CreateUpdateStudentClasroomViewModel> _modelValidator;
        private readonly StatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> _statusCodeResponse;

        
        private async Task<CustomMesageResponse> ValidateId(Guid teacherId, Guid studentId)
        {
            //var teacher = await _Teacher_Valid_Id.Bool(teacherId);
            //var student = await _Student_Valid_Id.Bool(studentId);

            //if (!teacher)
            //    return CustomMesageResponse.NotFound(teacher, "Invalid teacher id");
            //if (!student)
            //    return CustomMesageResponse.NotFound(student, "Invalid student id");

            return CustomMesageResponse.Succsess();
        }

        /// <summary>
        /// Inject services
        /// </summary>
        /// <param name="studentClasroomService"></param>
        /// <param name="modelValidator"></param>
        /// <param name="statusCodeResponse"></param>
        /// <param name="teacher_Valid_Id"></param>
        /// <param name="student_Valid_Id"></param>
        public StudentClasroomsController
        (
            ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> studentClasroomService, 
            IValidator<CreateUpdateStudentClasroomViewModel> modelValidator, 
            StatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> statusCodeResponse
        )
        {
            _studentClasroomService = studentClasroomService;
            _modelValidator = modelValidator;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        /// Get all student clasrooms
        /// </summary>
        /// <returns>All students with in a clasroom</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<StudentClasroom>>> GetStudentClasrooms()
        {
            var studentClasrooms = await _studentClasroomService.GetRecords();
            return _statusCodeResponse.ControllerResponse(studentClasrooms);
        }

        /// <summary>
        /// Get single student clasroom
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns>A student in a clasroom</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentClasroom>> GetStudentClasroom(Guid id)
        {
            var studentClasroom = await _studentClasroomService.GetRecord(id);
            return _statusCodeResponse.ControllerResponse(studentClasroom);
        }

        /// <summary>
        /// Update a studentclasroom record in StudentClasroom table
        /// </summary>
        /// <param name="studentClasroom">Data from client</param>
        /// <returns>The updated record</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> PutStudentClasroom([FromForm] CreateUpdateStudentClasroomViewModel studentClasroom)
        {
            var Ids = await ValidateId(studentClasroom.ClasroomId, studentClasroom.StudentId);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(studentClasroom);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updatedAttendance = await _studentClasroomService.PutRecord(studentClasroom.StudentId, studentClasroom);
            return _statusCodeResponse.ControllerResponse(updatedAttendance);
        }

        /// <summary>
        /// Create a studentclasroom record in database
        /// </summary>
        /// <param name="studentClasroom">Data from client</param>
        /// <returns>A message telling if the record was created or not</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentClasroom>> PostStudentClasroom([FromForm] CreateUpdateStudentClasroomViewModel studentClasroom)
        {
            var Ids = await ValidateId(studentClasroom.ClasroomId, studentClasroom.StudentId);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(studentClasroom);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createStudentClasroom = await _studentClasroomService.PostRecord(studentClasroom);
            return _statusCodeResponse.ControllerResponse(createStudentClasroom);
        }

        /// <summary>
        /// Deletes a studentClasroom form database
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns>A message telling if the record was deleted succsessfully</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteStudentClasroom(Guid id)
        {
            var deleteStudentClasroom = await _studentClasroomService.DeleteRecord(id);
            return _statusCodeResponse.ControllerResponse(deleteStudentClasroom);
        }
    }
}