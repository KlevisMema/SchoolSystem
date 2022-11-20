using FluentValidation;
using SchoolSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// StudentClasroom API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StudentClasroomsController : ControllerBase
    {
        private readonly I_Valid_Id<Student> i_Valid_Student_Id;
        private readonly I_Valid_Id<Clasroom> i_Valid_Clasroom_Id;
        private readonly IValidator<CreateUpdateStudentClasroomViewModel> _modelValidator;
        private readonly StatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> _statusCodeResponse;
        private readonly ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> _studentClasroomService;
        private async Task<CustomMesageResponse> ValidateId(Guid clasroomid, Guid studentId, CancellationToken cancellationToken)
        {
            var clasroom = await i_Valid_Clasroom_Id.Bool(clasroomid, cancellationToken);
            var student = await i_Valid_Student_Id.Bool(studentId, cancellationToken);

            if (!clasroom)
                return CustomMesageResponse.NotFound(clasroom, "Invalid clasroom id");
            if (!student)
                return CustomMesageResponse.NotFound(student, "Invalid student id");

            return CustomMesageResponse.Succsess();
        }

        /// <summary>
        /// Inject services
        /// </summary>
        /// <param name="studentClasroomService">Student Clasroom servivce</param>
        /// <param name="modelValidator">Model validator service</param>
        /// <param name="statusCodeResponse">Status code response service</param>
        /// <param name="i_Valid_Clasroom_Id">Clasroom valid id service</param>
        /// <param name="i_Valid_Student_Id">Student valid id service</param>
        public StudentClasroomsController
        (
            I_Valid_Id<Student> i_Valid_Student_Id,
            I_Valid_Id<Clasroom> i_Valid_Clasroom_Id,
            IValidator<CreateUpdateStudentClasroomViewModel> modelValidator,
            StatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> statusCodeResponse,
            ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> studentClasroomService
        )
        {
            _modelValidator = modelValidator;
            _statusCodeResponse = statusCodeResponse;
            this.i_Valid_Student_Id = i_Valid_Student_Id;
            this.i_Valid_Clasroom_Id = i_Valid_Clasroom_Id;
            _studentClasroomService = studentClasroomService;
        }

        /// <summary>
        /// Get all student clasrooms
        /// </summary>
        /// <returns>All students with in a clasroom</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<StudentClasroom>>> GetStudentClasrooms
        (
            CancellationToken cancellationToken
        )
        {
            var studentClasrooms = await _studentClasroomService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(studentClasrooms);
        }

        /// <summary>
        /// Get single student clasroom
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns>A student in a clasroom</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<ActionResult<StudentClasroom>> GetStudentClasroom
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var studentClasroom = await _studentClasroomService.GetRecord(id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(studentClasroom);
        }

        /// <summary>
        /// Update a studentclasroom record in StudentClasroom table
        /// </summary>
        /// <param name="studentClasroom">Data from client</param>
        /// <returns>The updated record</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<IActionResult> PutStudentClasroom
        (
            [FromForm] CreateUpdateStudentClasroomViewModel studentClasroom,
            CancellationToken cancellationToken
        )
        {
            var Ids = await ValidateId(studentClasroom.ClasroomId, studentClasroom.StudentId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(studentClasroom);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updatedAttendance = await _studentClasroomService.PutRecord(studentClasroom.StudentId, studentClasroom, cancellationToken);
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
        public async Task<ActionResult<StudentClasroom>> PostStudentClasroom
        (
            [FromForm] CreateUpdateStudentClasroomViewModel studentClasroom,
            CancellationToken cancellationToken
        )
        {
            var Ids = await ValidateId(studentClasroom.ClasroomId, studentClasroom.StudentId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(studentClasroom);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createStudentClasroom = await _studentClasroomService.PostRecord(studentClasroom, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createStudentClasroom);
        }

        /// <summary>
        /// Deletes a studentClasroom form database
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns>A message telling if the record was deleted succsessfully</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<IActionResult> DeleteStudentClasroom
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteStudentClasroom = await _studentClasroomService.DeleteRecord(id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteStudentClasroom);
        }
    }
}