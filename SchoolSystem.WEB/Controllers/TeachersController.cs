#region Usings

using MediatR;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Teacher;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Commads;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Teachers API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly IValidator<CreateUpdateTeacherViewModel> _modelValidator;
        private readonly IMediator _mediator;

        #region Services injection into ctor
        /// <summary>
        ///     Inject teacher service 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="modelValidator"></param>

        public TeachersController
        (
            IMediator mediator,
            IValidator<CreateUpdateTeacherViewModel> modelValidator
        )
        {
            _modelValidator = modelValidator;
            _mediator = mediator;
        }

        #endregion

        #region Get all teacher endpoint

        /// <summary>
        ///     Get all Teachers
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token</param>
        /// <returns> All Teachers </returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<TeacherViewModel>>> GetTeachers
        (
            CancellationToken cancellationToken
        )
        {
            var getAllQuery = new GetAllTeachersQuery();
            var result = await _mediator.Send(getAllQuery, cancellationToken);
            return result;
        }
        #endregion

        #region Get a techer by id endpoint

        /// <summary>
        ///     Get a specific teacher
        /// </summary>
        /// <param name="id"> Id of the teacher </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The teacher info </returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TeacherViewModel>> GetTeacher
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var getByIdQuery = new GetTeacherByIdQuery(id);
            var result = await _mediator.Send(getByIdQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Update a teacher endpoint

        /// <summary>
        ///     Update a teacher 
        /// </summary>
        /// <param name="id"> Id of the teacher</param>
        /// <param name="teacher"> Teacher object</param>
        /// <param name="cancellationToken"> Cancellation Token</param>
        /// <returns> The updtated techer </returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TeacherViewModel>> PutTeacher
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateTeacherViewModel teacher,
            CancellationToken cancellationToken
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(teacher, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updateQuery = new UpdateTeacherCommand(id, teacher);
            var result = await _mediator.Send(updateQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Create teacher endpoint

        /// <summary>
        ///     Create a teacher 
        /// </summary>
        /// <param name="teacher"> Teacher object </param>
        /// <param name="cancellationToken"> Cancellation Token</param>
        /// <returns> The created techer </returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TeacherViewModel>> PostTeacher
        (
            [FromForm] CreateUpdateTeacherViewModel teacher,
            CancellationToken cancellationToken
        )
        {
            #region Validate /CreateUpdateTeacherViewModel/ object values
            ValidationResult validationResult = await _modelValidator.ValidateAsync(teacher);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));
            #endregion

            #region Crate Teacher Command
            var createQuery = new CreateTeacherCommand(teacher);
            var result = await _mediator.Send(createQuery, cancellationToken);
            return result;
            #endregion
        }

        #endregion

        #region Delete a teacher by id endpoint

        /// <summary>
        /// Delete a teacher
        /// </summary>
        /// <param name="id">Id of the teacher </param>
        /// <param name="cancellationToken"> Cancellation Token</param>
        /// <returns>A message if it deleted or not </returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TeacherViewModel>> DeleteTeacher
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteQuery = new DeleteTeacherCommand(id);
            var result = await _mediator.Send(deleteQuery, cancellationToken);
            return result;
        }

        #endregion
    }
}