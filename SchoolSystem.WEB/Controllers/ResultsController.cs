#region Usings

using MediatR;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.BLL.MediatrService.Actions.Result.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Result.Commands;
using SchoolSystem.BLL.MediatrService.Actions.Student.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Exam.Queries;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    ///     Results API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        #region Validate ids

        /// <summary>
        ///     Validate Exam id, Student id and subject id
        /// </summary>
        /// <param name="ExamId"> Exam id </param>
        /// <param name="StudentId"> Srudent id </param>
        /// <param name="SubjectId"> Suvject id </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns></returns>
        private async Task<SchoolSystem.BLL.ResponseService.CustomMesageResponse> ValidateId
        (
            Guid ExamId,
            Guid StudentId,
            Guid SubjectId,
            CancellationToken cancellationToken
        )
        {
            var doesExamExists = new DoesExamExistsQuery(ExamId);
            var resultExam = await _mediator.Send(doesExamExists, cancellationToken);

            if (!resultExam.Exists)
                return resultExam;

            var doesStudentExists = new DoesStudentExistsQuery(StudentId);
            var resultStudent = await _mediator.Send(doesStudentExists, cancellationToken);

            if (!resultStudent.Exists)
                return resultStudent;

            var doesSubjectExists = new DoesStudentExistsQuery(SubjectId);
            var resultSubject = await _mediator.Send(doesSubjectExists, cancellationToken);

            if (!resultSubject.Exists)
                return resultSubject;

            return SchoolSystem.BLL.ResponseService.CustomMesageResponse.Succsess();
        }

        #endregion

        #region Services

        /// <summary>
        ///     Mediator 
        /// </summary>
        private readonly IMediator _mediator;
        /// <summary>
        ///     Model validator for CreateUpdateResultViewModel
        /// </summary>
        private readonly IValidator<CreateUpdateResultViewModel> _modelValidator;

        /// <summary>
        ///     Inject Services
        /// </summary>
        /// <param name="mediator"> Mediator service </param>
        /// <param name="modelValidator"> Validator service </param>

        public ResultsController
        (
            IMediator mediator,
            IValidator<CreateUpdateResultViewModel> modelValidator
        )
        {
            _mediator = mediator;
            _modelValidator = modelValidator;
        }

        #endregion

        #region Get all results endpoint

        /// <summary>
        ///     Get all results
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> All results </returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<ResultViewModel>>> GetResults
        (
            CancellationToken cancellationToken
        )
        {
            var GetAllQuery = new GetAllResultsQuery();
            var result = await _mediator.Send(GetAllQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Get result by id endpoint

        /// <summary>
        ///     Get a specific result
        /// </summary>
        /// <param name="id">Id of the result </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The result info </returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ResultViewModel>> GetResult
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var GetByIDQuery = new GetResultByIdQuery(id);
            var result = await _mediator.Send(GetByIDQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Update result endpoint

        /// <summary>
        ///     Update a result 
        /// </summary>
        /// <param name="id">Id of the result </param>
        /// <param name="result"> Result object </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The updtated result </returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ResultViewModel>> PutResult
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateResultViewModel result,
            CancellationToken cancellationToken
        )
        {
            var Ids = await ValidateId(result.ExamId, result.StudentId, result.SubjectId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(result);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var UpdateCommad = new UpdateResultCommand(id, result);
            var resultUpdate = await _mediator.Send(UpdateCommad, cancellationToken);
            return resultUpdate;
        }

        #endregion

        #region Create result endpoint

        /// <summary>
        ///     Create a result 
        /// </summary>
        /// <param name="result"> Result object </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The created result </returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ResultViewModel>> PostResult
        (
            [FromForm] CreateUpdateResultViewModel result,
            CancellationToken cancellationToken
        )
        {
            var Ids = await ValidateId(result.ExamId, result.StudentId, result.SubjectId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(result);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var CreateCommad = new CreateResultCommand(result);
            var resultCreate = await _mediator.Send(CreateCommad, cancellationToken);
            return resultCreate;
        }

        #endregion

        #region Delete Result endpoint

        /// <summary>
        ///     Delete a result
        /// </summary>
        /// <param name="id"> Id of the result </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message if it deleted or not </returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ResultViewModel>> DeleteResult
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var DeleteCommad = new DeleteResultCommand(id);
            var resultDelete = await _mediator.Send(DeleteCommad, cancellationToken);
            return resultDelete;
        }

        #endregion
    }
}