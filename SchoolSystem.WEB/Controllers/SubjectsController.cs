#region Usings

using MediatR;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.DTO.ViewModels.Subject;
using SchoolSystem.BLL.MediatrService.Queries.Subject.Queries;
using SchoolSystem.BLL.MediatrService.Queries.Subject.Commands;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    ///     Subject API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateUpdateSubjectViewModel> _modelValidator;

        #region Injecting services in the ctr

        /// <summary>
        /// Inject services
        /// </summary>
        /// <param name="modelValidator"> ModelVlidator service</param>
        /// <param name="mediator"> Mediator service</param>

        public SubjectsController
        (
            IMediator mediator,
            IValidator<CreateUpdateSubjectViewModel> modelValidator
        )
        {
            _mediator = mediator;
            _modelValidator = modelValidator;
        }

        #endregion

        #region Get all endpoint

        /// <summary>
        ///     Get all Subjects
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> All subjects </returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<SubjectViewModel>>> GetSubjects
        (
            CancellationToken cancellationToken = default
        )
        {
            var getQuery = new GetAllSubjectsQuery();
            var result = await _mediator.Send(getQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Get by id endpoint

        /// <summary>
        ///     Get a specific subject
        /// </summary>
        /// <param name="id"> Id of the subject </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The subject info </returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<SubjectViewModel>> GetSubject
        (
           [FromRoute] Guid id,
           CancellationToken cancellationToken
        )
        {
            var getByIdQuery = new GetSubjectByIdQuery(id);
            var result = await _mediator.Send(getByIdQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Update endpoint

        /// <summary>
        ///     Update a subject 
        /// </summary>
        /// <param name="id"> Id of the subject</param>
        /// <param name="subject"> Subject object</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The updtated subject </returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<SubjectViewModel>> PutSubject
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateSubjectViewModel subject,
            CancellationToken cancellationToken
        )
        {
            #region Validate /CreateUpdateSubjectViewModel/ object values
            ValidationResult validationResult = await _modelValidator.ValidateAsync(subject, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));
            #endregion

            #region Update record
            var updateSubjectCommand = new UpdateSubjectCommand(subject, id);
            var result = await _mediator.Send(updateSubjectCommand, cancellationToken);
            return result;
            #endregion
        }

        #endregion

        #region Create  endpoint

        /// <summary>
        ///     Create a subject 
        /// </summary>
        /// <param name="subject"> Subject object </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The created subject </returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<SubjectViewModel>> PostSubject
        (
            [FromForm] CreateUpdateSubjectViewModel subject,
            CancellationToken cancellationToken
        )
        {
            #region Validate /CreateUpdateSubjectViewModel/ object values
            ValidationResult validationResult = await _modelValidator.ValidateAsync(subject, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));
            #endregion

            #region Create record
            var createSubjectCommand = new CreateSubjectCommand(subject);
            var result = await _mediator.Send(createSubjectCommand, cancellationToken);
            return result;
            #endregion
        }

        #endregion

        #region Delete by id endpoint

        /// <summary>
        ///     Delete a subject
        /// </summary>
        /// <param name="id">Id of the subject </param>
        /// <param name="cancellationToken"> Cancellation Token k</param>
        /// <returns> A message if it deleted or not </returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<SubjectViewModel>> DeleteSubject
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteSubjectCommand = new DeleteSubjectCommand(id);
            var result = await _mediator.Send(deleteSubjectCommand, cancellationToken);
            return result;
        }

        #endregion
    }
}