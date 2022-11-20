using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.DTO.ViewModels.TimeTable;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// TimeTable API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TimeTablesController : ControllerBase
    {
        private readonly IValidator<CreateUpdateTimeTableViewModel> _modelValidator;
        private readonly ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> _timeTableService;
        private readonly StatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> _statusCodeResponse;

        /// <summary>
        /// Inject services
        /// </summary>
        /// <param name="timeTableService">Time table service</param>
        /// <param name="modelValidator">Model validator service</param>
        /// <param name="statusCodeResponse">Status code response service</param>
        public TimeTablesController
        (
            IValidator<CreateUpdateTimeTableViewModel> modelValidator,
            ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel> timeTableService,
            StatusCodeResponse<TimeTableViewModel, List<TimeTableViewModel>> statusCodeResponse
        )
        {
            _modelValidator = modelValidator;
            _timeTableService = timeTableService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        /// Get all time tables
        /// </summary>
        /// <returns>A list of time tables </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeTableViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<TimeTableViewModel>>> GetTimeTables
        (
            CancellationToken cancellationToken
        )
        {
            var timeTables = await _timeTableService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(timeTables);
        }

        /// <summary>
        /// Get a time table by id
        /// </summary>
        /// <param name="id">Id of the time table</param>
        /// <returns>A time table info</returns>
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
            var timeTable = await _timeTableService.GetRecord(id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(timeTable);
        }

        /// <summary>
        /// Updates a time table
        /// </summary>
        /// <param name="id">Id of the time table</param>
        /// <param name="timeTable">Object from client</param>
        /// <returns>The updated time table</returns>
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

            var updatedTimeTable = await _timeTableService.PutRecord(id, timeTable, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedTimeTable);
        }

        /// <summary>
        /// Creates a time table 
        /// </summary>
        /// <param name="timeTable">Object from client</param>
        /// <returns>A message telling if the time table was created or not</returns>
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

            var createTimeTable = await _timeTableService.PostRecord(timeTable, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createTimeTable);
        }

        /// <summary>
        /// Deletes a time table by id
        /// </summary>
        /// <param name="id">Id of the time table</param>
        /// <returns>A message telling if the time table was deleted or not</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeTableViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteTimeTable
        (
            [FromForm] Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteTimeTable = await _timeTableService.DeleteRecord(id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteTimeTable);
        }
    }
}