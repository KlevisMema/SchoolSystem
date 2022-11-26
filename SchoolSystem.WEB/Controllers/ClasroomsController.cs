#region Usings

using MediatR;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Clasroom;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Clasroom.Commands;
using SchoolSystem.BLL.MediatrService.Actions.TimeTable.Queries;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    ///     Clasroom API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClasroomsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateUpdateClasroomViewModel> _modelValidator;

        #region Validate ids

        private async Task<SchoolSystem.BLL.ResponseService.CustomMesageResponse> ValidateId
        (
            Guid teacherId,
            Guid timetableId,
            CancellationToken cancellationToken
        )
        {
            var doesTeacherExists = new DoesTeacherExistsQuery(teacherId);
            var resultTeacher = await _mediator.Send(doesTeacherExists, cancellationToken);

            var doesTimeTableExists = new DoestTimeTableExistsQuery(timetableId);
            var resultTimeTable = await _mediator.Send(doesTimeTableExists, cancellationToken);

            if (!resultTeacher.Exists)
                return resultTeacher;
            if (!resultTimeTable.Exists)
                return resultTimeTable;

            return SchoolSystem.BLL.ResponseService.CustomMesageResponse.Succsess();
        }

        #endregion

        #region Inject services to Clasrooms ctor

        /// <summary>
        /// Inject Services
        /// </summary>
        /// <param name="mediator"> Mediator  service</param>
        /// <param name="modelValidator">Model validator service</param>

        public ClasroomsController
        (
            IMediator mediator,
            IValidator<CreateUpdateClasroomViewModel> modelValidator
        )
        {
            _mediator = mediator;
            _modelValidator = modelValidator;
        }

        #endregion

        #region Get all Clasrooms endpoint

        /// <summary>
        ///     Get all clasrooms
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A list of clasrooms </returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<ClasroomViewModel>>> GetClasrooms
        (
            CancellationToken cancellationToken
        )
        {
            var getAllQuery = new GetAllClasroomsQuery();
            var result = await _mediator.Send(getAllQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Get clasroom by id endpoint

        /// <summary>
        ///     Get one clasroom by id
        /// </summary>
        /// <param name="id">Id of the clasroom</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns>The clasroom with that specific id</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ClasroomViewModel>> GetClasroom
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var getByIdQuery = new GetClasroomsByIdQuery(id);
            var result = await _mediator.Send(getByIdQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Put clasroom endpoint

        /// <summary>
        ///     Update a clasroom
        /// </summary>
        /// <param name="id"> Id of the clasroom </param>
        /// <param name="clasroom"> Client data object </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The updated clasroom </returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> PutClasroom
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateClasroomViewModel clasroom,
            CancellationToken cancellationToken
        )
        {
            var Ids = await ValidateId(clasroom.TeacherId, clasroom.TimeTableId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(clasroom, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updateQuery = new UpdateClasroomCommand(id, clasroom);
            var result = await _mediator.Send(updateQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Post clasroom endpoint

        /// <summary>
        ///     Create  a new clasroom
        /// </summary>
        /// <param name="clasroom"> Clasroom client object </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message telling if the clasroom was created or not </returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ClasroomViewModel>> PostClasroom
        (
            [FromForm] CreateUpdateClasroomViewModel clasroom,
            CancellationToken cancellationToken
        )
        {
            var Ids = await ValidateId(clasroom.TeacherId, clasroom.TimeTableId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(clasroom);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createQuery = new CreateClasroomCommand(clasroom);
            var result = await _mediator.Send(createQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Delete clasroom endpoint

        /// <summary>
        ///     Delete a clasroom by id
        /// </summary>
        /// <param name="id"> Id of the clasroom </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message telling if the clasroom was deleted or not </returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteClasroom
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteQuery = new DeleteClasroomCommand(id);
            var result = await _mediator.Send(deleteQuery, cancellationToken);
            return result;
        }

        #endregion
    }
}