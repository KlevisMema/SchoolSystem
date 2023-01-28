#region Usings

using MediatR;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Student.Queries;
using SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Queries;
using SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Commands;
using SchoolSystem.BLL.MediatrService.Actions.Result.Commands;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    ///     Student Issues API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StudentIssuesController : ControllerBase
    {
        #region Validate ids

        private async Task<CustomMesageResponse> ValidateId
        (
            Guid studentId,
            Guid issueId,
            CancellationToken cancellationToken
        )
        {
            var doesIssueExists = new DoesIssueExistsQuery(issueId);
            var resultIssue = await _mediator.Send(doesIssueExists, cancellationToken);

            if (!resultIssue.Exists)
                return resultIssue;

            var doesStudentExists = new DoesStudentExistsQuery(studentId);
            var resultStudent = await _mediator.Send(doesStudentExists, cancellationToken);

            if (!resultStudent.Exists)
                return resultStudent;

            return CustomMesageResponse.Succsess();
        }

        #endregion

        #region Services 

        private readonly IMediator _mediator;
        private readonly IValidator<CreateUpdateStudentIssueViewModel> _modelValidator;

        /// <summary>
        ///     Inject Services
        /// </summary>
        /// <param name="mediator"> Mediator service </param>
        /// <param name="modelValidator"> Validator service </param>

        public StudentIssuesController
        (
            IMediator mediator,
            IValidator<CreateUpdateStudentIssueViewModel> modelValidator
        )
        {
            _mediator = mediator;
            _modelValidator = modelValidator;
        }

        #endregion

        #region Get all student issues endpoint

        /// <summary>
        ///     Get all student student issues
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns>A list of student issues</returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<ActionResult<List<StudentIssueViewModel>>> GetStudentIssues
        (
            CancellationToken cancellationToken
        )
        {
            var GetAllQuery = new GetAllStudentIssuesByIdQuery();
            var result = await _mediator.Send(GetAllQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Get student issues by id endpoint

        /// <summary>
        ///     Get single student issues
        /// </summary>
        /// <param name="IssueId">Id of the Issue</param>
        /// <param name="StudentId">Id of the Student</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns>A student issue</returns>

        [HttpGet("GetStudentIssue")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<ActionResult<StudentIssueViewModel>> GetStudentIssue
        (
             Guid StudentId,
             Guid IssueId,
            CancellationToken cancellationToken
        )
        {
            var GetByIDQuery = new GetStudentIssuesByIdQuery(IssueId, StudentId);
            var result = await _mediator.Send(GetByIDQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Update student issue endpoint

        /// <summary>
        /// Update a student issue
        /// </summary>
        /// <param name="studentIssue">Data from client</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <param name="StudentId"> Student Id </param>
        /// <returns>The updated record</returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<IActionResult> PutStudentIssue
        (
            [FromRoute] Guid StudentId,
            [FromForm] CreateUpdateStudentIssueViewModel studentIssue,
            CancellationToken cancellationToken
        )
        {
            var Ids = await ValidateId(studentIssue.StudentId, studentIssue.IssueId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(studentIssue);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var UpdateCommad = new UpdateStudentIssueCommand(StudentId, studentIssue);
            var resultUpdate = await _mediator.Send(UpdateCommad, cancellationToken);
            return resultUpdate;
        }

        #endregion

        #region Create Student issue endpoint

        /// <summary>
        /// Create a student issue
        /// </summary>
        /// <param name="studentIssue">Data from client</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns>A message telling if the record was created or not</returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<ActionResult<StudentIssueViewModel>> PostStudentIssue
        (
            [FromForm] CreateUpdateStudentIssueViewModel studentIssue,
            CancellationToken cancellationToken
        )
        {
            var Ids = await ValidateId(studentIssue.StudentId, studentIssue.IssueId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(studentIssue);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var CreateCommad = new CreateStudentIssueCommand(studentIssue);
            var resultCreate = await _mediator.Send(CreateCommad, cancellationToken);
            return resultCreate;
        }

        #endregion

        #region Delete Result endpoint

        /// <summary>
        /// Deletes a student issue
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns>A message telling if the record was deleted succsessfully</returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<IActionResult> DeleteStudentIssue
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var DeleteCommad = new DeleteStudentIssueCommand(id);
            var resultDelete = await _mediator.Send(DeleteCommad, cancellationToken);
            return resultDelete;
        }

        #endregion
    }
}