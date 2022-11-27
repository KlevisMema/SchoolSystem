#region Usings

using MediatR;
using FluentValidation;
using SchoolSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Commands;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    ///     Issue API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateUpdateIssueViewModel> _modelValidator;

        #region Inject services in the ctor 

        /// <summary>
        /// Inject services
        /// </summary>
        /// <param name="modelValidator">Model validator service</param>
        /// <param name="mediator"> Mediator service </param>

        public IssuesController
        (
            IMediator mediator,
            IValidator<CreateUpdateIssueViewModel> modelValidator
        )
        {
            _mediator = mediator;
            _modelValidator = modelValidator;
        }

        #endregion

        #region Get all issues 

        /// <summary>
        ///     Get all issues
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A list of issues </returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<Issue>>> GetIssues
        (
            CancellationToken cancellationToken
        )
        {
            var getAllQuery = new GetAllIssuesQuery();
            var result = await _mediator.Send(getAllQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Get issue by id endpoint

        /// <summary>
        ///     Get a single issue by id
        /// </summary>
        /// <param name="id">Id of the issue</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The issue </returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<Issue>> GetIssue
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var getByIdQuery = new GetIssueByIdQuery(id);
            var result = await _mediator.Send(getByIdQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Update issue endpoint

        /// <summary>
        ///     Update an issue
        /// </summary>
        /// <param name="id">Id of the issue</param>
        /// <param name="issue">Issue cliennt object  </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The updated issue </returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> PutIssue
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateIssueViewModel issue,
            CancellationToken cancellationToken
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(issue);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updateQuery = new UpdateIssueCommand(id, issue);
            var result = await _mediator.Send(updateQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Create issues endpoint

        /// <summary>
        ///     Create a new issue
        /// </summary>
        /// <param name="issue">Issue object from client</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message telling if the issue was created or not </returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<Issue>> PostIssue
        (
            [FromForm] CreateUpdateIssueViewModel issue,
            CancellationToken cancellationToken
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(issue);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createQuery = new CreateIssueCommand(issue);
            var result = await _mediator.Send(createQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Delete an issue endpoint

        /// <summary>
        ///     Delete an issue
        /// </summary>
        /// <param name="id">Id of the issue</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message telling if the issue was deleted or not </returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteIssue
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteQuery = new DeleteIssueCommand(id);
            var result = await _mediator.Send(deleteQuery, cancellationToken);
            return result;
        }

        #endregion
    }
}