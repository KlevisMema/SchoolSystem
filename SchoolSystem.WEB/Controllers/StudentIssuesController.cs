using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;


namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Student Issues API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StudentIssuesController : ControllerBase
    {
        private readonly IValidator<CreateUpdateStudentIssueViewModel> _modelValidator;
        private readonly StatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> _statusCodeResponse;
        private readonly ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> _studentIssueService;
        private async Task<CustomMesageResponse> ValidateId(Guid studentId, Guid issueId)
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
        /// <param name="modelValidator">Model validator service</param>
        /// <param name="statusCodeResponse">Status code response service</param>
        /// <param name="studentIssueService">Student issue service</param>
        public StudentIssuesController
        (
            IValidator<CreateUpdateStudentIssueViewModel> modelValidator,
            StatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> statusCodeResponse,
            ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> studentIssueService
        )
        {
            _modelValidator = modelValidator;
            _statusCodeResponse = statusCodeResponse;
            _studentIssueService = studentIssueService;
        }

        /// <summary>
        /// Get all student student issues
        /// </summary>
        /// <returns>A list of student issues</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<ActionResult<List<StudentIssueViewModel>>> GetStudentIssues
        (
        )
        {
            var studentIssues = await _studentIssueService.GetRecords();
            return _statusCodeResponse.ControllerResponse(studentIssues);
        }

        /// <summary>
        /// Get single student issues
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns>A student issue</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<ActionResult<StudentIssueViewModel>> GetStudentIssue
        (
            [FromRoute] Guid id
        )
        {
            var studentIssue = await _studentIssueService.GetRecord(id);
            return _statusCodeResponse.ControllerResponse(studentIssue);
        }

        /// <summary>
        /// Update a student issue
        /// </summary>
        /// <param name="studentIssue">Data from client</param>
        /// <returns>The updated record</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<IActionResult> PutStudentIssue
        (
            [FromForm] CreateUpdateStudentIssueViewModel studentIssue
        )
        {
            var Ids = await ValidateId(studentIssue.StudentId, studentIssue.IssueId);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(studentIssue);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updateStudentIssue = await _studentIssueService.PutRecord(studentIssue.StudentId, studentIssue);
            return _statusCodeResponse.ControllerResponse(updateStudentIssue);
        }

        /// <summary>
        /// Create a student issue
        /// </summary>
        /// <param name="studentIssue">Data from client</param>
        /// <returns>A message telling if the record was created or not</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<ActionResult<StudentIssueViewModel>> PostStudentIssue
        (
            [FromForm] CreateUpdateStudentIssueViewModel studentIssue
        )
        {
            var Ids = await ValidateId(studentIssue.StudentId, studentIssue.IssueId);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(studentIssue);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createStudentIssue = await _studentIssueService.PostRecord(studentIssue);
            return _statusCodeResponse.ControllerResponse(createStudentIssue);
        }

        /// <summary>
        /// Deletes a student issue
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns>A message telling if the record was deleted succsessfully</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<IActionResult> DeleteStudentIssue
        (
            [FromRoute] Guid id
        )
        {
            var deleteStudentIssue = await _studentIssueService.DeleteRecord(id);
            return _statusCodeResponse.ControllerResponse(deleteStudentIssue);
        }
    }
}