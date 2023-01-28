#region Usings

using MediatR;
using FluentValidation;
using SchoolSystem.DAL.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Exam;
using SchoolSystem.BLL.MediatrService.Actions.Exam.Querys;
using SchoolSystem.BLL.MediatrService.Actions.Exam.Commands;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    ///     Exam API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ExamsController : ControllerBase
    {
        #region Services

        /// <summary>
        ///     Mediator 
        /// </summary>
        private readonly IMediator _mediator;
        /// <summary>
        ///     Model validator for CreateUpdateExamViewModel
        /// </summary>
        private readonly IValidator<CreateUpdateExamViewModel> _modelValidator;

        /// <summary>
        ///     Inject services 
        /// </summary>
        /// <param name="mediator"> Mediator service</param>
        /// <param name="modelValidator"> Model validatior service </param>

        public ExamsController
        (
            IMediator mediator,
            IValidator<CreateUpdateExamViewModel> modelValidator
        )
        {
            _mediator = mediator;
            _modelValidator = modelValidator;
        }

        #endregion

        #region Get all exams endpoint

        /// <summary>
        ///     Get all Exams
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExamViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<ExamViewModel>>> GetExams
        (
            CancellationToken cancellationToken
        )
        {
            var getAllQuery = new GetAllExamsQuery();
            var result = await _mediator.Send(getAllQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Get exam by id endpoint

        /// <summary>
        ///     Get an exam
        /// </summary>
        /// <param name="id"> Id of the exam </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> Details of that exam </returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExamViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ExamViewModel>> GetExam
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var getByIdQuery = new GetExamByIdQuery(id);
            var result = await _mediator.Send(getByIdQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Update exam endpoint

        /// <summary>
        ///     Update an exam
        /// </summary>
        /// <param name="id"> Id of the  exam </param>
        /// <param name="exam"> Exam object from client </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The updated exam </returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExamViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> PutExam
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateExamViewModel exam,
            CancellationToken cancellationToken
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(exam, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updateQuery = new UpdateExamCommand(id, exam);
            var result = await _mediator.Send(updateQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Create exam endpoint

        /// <summary>
        ///     Creates an exam 
        /// </summary>
        /// <param name="exam"> Exam object from client </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message id exam was created or not </returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExamViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<Exam>> PostExam
        (
            [FromForm] CreateUpdateExamViewModel exam,
            CancellationToken cancellationToken
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(exam, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createQuery = new CreateExamCommand(exam);
            var result = await _mediator.Send(createQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Delete exam endpoint

        /// <summary>
        ///     Deletes an exam
        /// </summary>
        /// <param name="id"> Id of the exam </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message if the exam was deleted or not </returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExamViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteExam
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteQuery = new DeleteExamCommand(id);
            var result = await _mediator.Send(deleteQuery, cancellationToken);
            return result;
        }

        #endregion
    }
}