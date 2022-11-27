﻿#region Usings

using MediatR;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Result.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Result.Commands;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Results API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IExists _exists;
        private readonly IValidator<CreateUpdateResultViewModel> _modelValidator;

        #region Inject services in the ctor 

        /// <summary>
        ///     Inject Services
        /// </summary>
        /// <param name="mediator"> Mediator service </param>
        /// <param name="modelValidator"> Validator service </param>
        /// <param name="exists">Exists service</param>

        public ResultsController
        (
            IExists exists,
            IValidator<CreateUpdateResultViewModel> modelValidator,
            IMediator mediator
        )
        {
            _exists = exists;
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
            var checkIds = await _exists.DoesExists(result.ExamId, result.StudentId, result.SubjectId);

            if (!checkIds)
                return NotFound("Invalid ids!!");

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
            var checkIds = await _exists.DoesExists(result.ExamId, result.StudentId, result.SubjectId);

            if (!checkIds)
                return NotFound("Invalid ids!!");

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