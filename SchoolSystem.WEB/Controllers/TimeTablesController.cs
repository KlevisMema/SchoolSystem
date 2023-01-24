#region Usings

using MediatR;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.TimeTable;
using SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries;
using SchoolSystem.BLL.MediatrService.Actions.TimeTable.Commands;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    ///     TimeTable API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TimeTablesController : ControllerBase
    {
        #region Services 

        /// <summary>
        ///     Mediator 
        /// </summary>
        private readonly IMediator _mediator;
        /// <summary>
        ///     Model validator for CreateUpdateTimeTableViewModel
        /// </summary>
        private readonly IValidator<CreateUpdateTimeTableViewModel> _modelValidator;

        /// <summary>
        ///     Inject services
        /// </summary>
        /// <param name="mediator"> Mediator service </param>
        /// <param name="modelValidator"> Model validator service </param>

        public TimeTablesController
        (
            IMediator mediator,
            IValidator<CreateUpdateTimeTableViewModel> modelValidator
        )
        {
            _mediator = mediator;
            _modelValidator = modelValidator;
        }

        #endregion

        #region Get all time tables endpoint

        /// <summary>
        ///     Get all time tables
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A list of time tables </returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeTableViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<TimeTableViewModel>>> GetTimeTables
        (
            CancellationToken cancellationToken
        )
        {
            var getAllQuery = new GetAllTimeTablesQuery();
            var result = await _mediator.Send(getAllQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Get a time table by id endpoint

        /// <summary>
        ///     Get a time table by id
        /// </summary>
        /// <param name="id"> Id of the time table </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A time table info </returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeTableViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TimeTableViewModel>> GetTimeTable
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var getByIdQuery = new GetTimeTableByIdQuery(id);
            var result = await _mediator.Send(getByIdQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Update a time table endpoint

        /// <summary>
        ///     Updates a time table
        /// </summary>
        /// <param name="id"> Id of the time table </param>
        /// <param name="timeTable"> Object from client </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The updated time table </returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeTableViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> PutTimeTable
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateTimeTableViewModel timeTable,
            CancellationToken cancellationToken
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(timeTable, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updateQuery = new UpdateTimeTableCommand(id, timeTable);
            var result = await _mediator.Send(updateQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Create a time table endpoint

        /// <summary>
        ///     Creates a time table 
        /// </summary>
        /// <param name="timeTable"> Object from client </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message telling if the time table was created or not </returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeTableViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TimeTableViewModel>> PostTimeTable
        (
            [FromForm] CreateUpdateTimeTableViewModel timeTable,
            CancellationToken cancellationToken
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(timeTable, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createQuery = new CreateTimeTableCommand(timeTable);
            var result = await _mediator.Send(createQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Delete a time table by id endpoint

        /// <summary>
        ///     Deletes a time table by id
        /// </summary>
        /// <param name="id"> Id of the time table </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message telling if the time table was deleted or not </returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeTableViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteTimeTable
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteQuery = new DeleteTimeTableCommand(id);
            var result = await _mediator.Send(deleteQuery, cancellationToken);
            return result;
        }

        #endregion
    }
}