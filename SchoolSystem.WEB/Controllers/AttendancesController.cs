#region Usings

using MediatR;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Student.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Attendance.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Attendance.Commands;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Attendance API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AttendancesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateUpdateAttendanceViewModel> _modelValidator;

        #region Validate ids

        private async Task<SchoolSystem.BLL.ResponseService.CustomMesageResponse> ValidateId
        (
            Guid teacherId,
            Guid studentId,
            CancellationToken cancellationToken
        )
        {
            var doesTeacherExists = new DoesTeacherExistsQuery(teacherId);
            var resultTeacher = await _mediator.Send(doesTeacherExists, cancellationToken);

            var doesStudentExists = new DoesStudentExistsQuery(studentId);
            var resultStudent = await _mediator.Send(doesStudentExists, cancellationToken);

            if (!resultTeacher.Exists)
                return resultTeacher;
            if (!resultStudent.Exists)
                return resultStudent;

            return SchoolSystem.BLL.ResponseService.CustomMesageResponse.Succsess();
        }

        #endregion

        #region Inject services to Attendance ctor

        /// <summary>
        ///     Inject services 
        /// </summary>
        /// <param name="modelValidator"> Model validation service </param>
        /// <param name="mediator"> Mediator Service </param>

        public AttendancesController
        (
            IMediator mediator,
            IValidator<CreateUpdateAttendanceViewModel> modelValidator
        )
        {
            _mediator = mediator;
            _modelValidator = modelValidator;
        }

        #endregion

        #region Get all attendances endpoint

        /// <summary>
        /// Get all attendances
        /// </summary>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<AttendanceViewModel>>> GetAttendances
        (
            CancellationToken cancellationToken
        )
        {
            var getAllQuery = new GetAllAttendancesQuery();
            var result = await _mediator.Send(getAllQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Get attendance by id endpoint

        /// <summary>
        ///     Get an attendance
        /// </summary>
        /// <param name="id"> Id of the attendance </param>
        /// <param name="cancellationToken"> Cancellationn Token </param>
        /// <returns> Details of that attendance </returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AttendanceViewModel>> GetAttendance
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var getByIdQuery = new GetAttedanceByIdQuery(id);
            var result = await _mediator.Send(getByIdQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Put attendance endpoint

        /// <summary>
        ///     Update an attendance
        /// </summary>
        /// <param name="id"> Id of the attendance </param>
        /// <param name="attendance"> attendance object from client </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The updated attendance </returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> PutAttendance
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateAttendanceViewModel attendance,
            CancellationToken cancellationToken
        )
        {
            #region Validation
            ValidationResult validationResult = await _modelValidator.ValidateAsync(attendance, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));
            #endregion

            #region Check if teacherid and studentId exists in db
            var Ids = await ValidateId(attendance.TeacherId, attendance.StudentId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);
            #endregion

            #region Update the record
            var updateCommand = new UpdateAttendanceCommand(id, attendance);
            var result = await _mediator.Send(updateCommand, cancellationToken);
            return result;
            #endregion
        }

        #endregion

        #region Post attendance endpoint

        /// <summary>
        ///     Creates an attendance 
        /// </summary>
        /// <param name="attendance"> Attendance object from client </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <remarks> 
        ///     Status contains Present with value of 1 and Missing with value of 2
        /// </remarks>
        /// <returns> A message id attendance was created or not </returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AttendanceViewModel>> PostAttendance
        (
            [FromForm] CreateUpdateAttendanceViewModel attendance,
            CancellationToken cancellationToken
        )
        {
            #region Validate data in //CreateUpdateAttendanceViewModel// object
            ValidationResult validationResult = await _modelValidator.ValidateAsync(attendance, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));
            #endregion

            #region Check if teacherid and studentId exists in db
            var Ids = await ValidateId(attendance.TeacherId, attendance.StudentId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);
            #endregion

            #region Create the record
            var createCommand = new CreateAttendanceCommand(attendance);
            var result = await _mediator.Send(createCommand, cancellationToken);
            return result;
            #endregion
        }

        #endregion

        #region Delete attendance endpoint

        /// <summary>
        ///     Deletes an attendance
        /// </summary>
        /// <param name="id"> Id of the attendance </param>
        /// <param name="cancellationToken"> Cancellation Token</param>
        /// <returns> A message if the attendance was deleted or not </returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteAttendance
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteCommand = new DeleteAttendanceCommand(id);
            var result = await _mediator.Send(deleteCommand, cancellationToken);
            return result;
        }

        #endregion
    }
}