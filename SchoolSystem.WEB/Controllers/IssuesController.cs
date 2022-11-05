using FluentValidation;
using SchoolSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Attendance;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Issue API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IValidator<CreateUpdateIssueViewModel> _modelValidator;
        private readonly ICrudService<IssueViewModel, CreateUpdateIssueViewModel> _issueService;
        private readonly StatusCodeResponse<IssueViewModel, List<IssueViewModel>> _statusCodeResponse;

        /// <summary>
        /// Inject services
        /// </summary>
        /// <param name="modelValidator">Model validator service</param>
        /// <param name="issueService">Issue service </param>
        /// <param name="statusCodeResponse">Status code response service</param>
        public IssuesController
        (
            IValidator<CreateUpdateIssueViewModel> modelValidator,
            ICrudService<IssueViewModel, CreateUpdateIssueViewModel> issueService,
            StatusCodeResponse<IssueViewModel, List<IssueViewModel>> statusCodeResponse
        )
        {
            _issueService = issueService;
            _modelValidator = modelValidator;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        /// Get all issues
        /// </summary>
        /// <returns>A list of issues</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<Issue>>> GetIssues
        (
        )
        {
            var issues = await _issueService.GetRecords();
            return _statusCodeResponse.ControllerResponse(issues);
        }

        /// <summary>
        /// Get a single issue by id
        /// </summary>
        /// <param name="id">Id of the issue</param>
        /// <returns>The issue</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<Issue>> GetIssue
        (
            [FromRoute] Guid id
        )
        {
            var issue = await _issueService.GetRecord(id);
            return _statusCodeResponse.ControllerResponse(issue);
        }

        /// <summary>
        /// Update an issue
        /// </summary>
        /// <param name="id">Id of the issue</param>
        /// <param name="issue">Issue cliennt object  </param>
        /// <returns>The updated issue</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> PutIssue
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateIssueViewModel issue
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(issue);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updatedIssue = await _issueService.PutRecord(id, issue);
            return _statusCodeResponse.ControllerResponse(updatedIssue);
        }

        /// <summary>
        /// Create a new issue
        /// </summary>
        /// <param name="issue">Issue object from client</param>
        /// <returns>A message telling if the issue was created or not</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<Issue>> PostIssue
        (
            [FromForm] CreateUpdateIssueViewModel issue
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(issue);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createIssue = await _issueService.PostRecord(issue);
            return _statusCodeResponse.ControllerResponse(createIssue);
        }

        /// <summary>
        /// Delete an issue
        /// </summary>
        /// <param name="id">Id of the issue</param>
        /// <returns>A message telling if the issue was deleted or not</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteIssue
        (
            [FromRoute] Guid id
        )
        {
            var deleteIssue = await _issueService.DeleteRecord(id);
            return _statusCodeResponse.ControllerResponse(deleteIssue);
        }
    }
}