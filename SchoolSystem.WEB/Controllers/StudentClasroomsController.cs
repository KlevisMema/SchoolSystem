#region Usings

using MediatR;
using FluentValidation;
using SchoolSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.MediatrService.Actions.Student.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries;
using SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Queries;
using SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands;

#endregion

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    ///     StudentClasroom API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StudentClasroomsController : ControllerBase
    {
        #region Validate Ids

        /// <summary>
        ///     Validate ClasroomId and StudentId 
        /// </summary>
        /// <param name="clasroomid"> Clasroom id </param>
        /// <param name="studentId"> Student Id </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> Custom response message </returns>

        private async Task<CustomMesageResponse> ValidateId(Guid clasroomid, Guid studentId, CancellationToken cancellationToken)
        {
            var doesClasroomExists = new DoesClasroomExistsQuery(clasroomid);
            var resultClasroomExists = await _mediator.Send(doesClasroomExists, cancellationToken);

            if (!resultClasroomExists.Exists)
                return resultClasroomExists;

            var doesStudentExists = new DoesStudentExistsQuery(studentId);
            var resultStudentExists = await _mediator.Send(doesStudentExists, cancellationToken);

            if (!resultStudentExists.Exists)
                return resultStudentExists;

            return CustomMesageResponse.Succsess();
        }

        #endregion

        #region Services 

        private readonly IMediator _mediator;
        private readonly IValidator<CreateUpdateStudentClasroomViewModel> _modelValidator;

        /// <summary>
        ///     Inject services
        /// </summary>
        /// <param name="modelValidator"> Model validator service </param>
        /// <param name="mediator"> Mediator Service </param>
        public StudentClasroomsController
        (
            IValidator<CreateUpdateStudentClasroomViewModel> modelValidator,
            IMediator mediator
        )
        {
            _modelValidator = modelValidator;
            _mediator = mediator;
        }

        #endregion

        #region Get all student clasrooms endpoint 

        /// <summary>
        ///     Get all student clasrooms
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> All students with in a clasroom </returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<StudentClasroom>>> GetStudentClasrooms
        (
            CancellationToken cancellationToken
        )
        {
            var getAllQuery = new GetAllStudentClasroomsQuery();
            var result = await _mediator.Send(getAllQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Get student clasroom endpoint 

        /// <summary>
        ///     Get single student clasroom
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A student in a clasroom </returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<ActionResult<StudentClasroom>> GetStudentClasroom
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var getByIdQuery = new GetStudentClasroomByIdQuery(id);
            var result = await _mediator.Send(getByIdQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Update student clasroom endpoint 

        /// <summary>
        ///     Update a studentclasroom record in StudentClasroom table
        /// </summary>
        /// <param name="studentClasroom"> Data from client </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The updated record </returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<IActionResult> PutStudentClasroom
        (
            [FromForm] CreateUpdateStudentClasroomViewModel studentClasroom,
            CancellationToken cancellationToken
        )
        {
            var Ids = await ValidateId(studentClasroom.ClasroomId, studentClasroom.StudentId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(studentClasroom);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updateQuery = new UpdateStudentClasroomCommand(studentClasroom.StudentId, studentClasroom);
            var result = await _mediator.Send(updateQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Create student clasroom endpoint 

        /// <summary>
        ///     Create a studentclasroom record in database
        /// </summary>
        /// <param name="studentClasroom">Data from client </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message telling if the record was created or not </returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentClasroom>> PostStudentClasroom
        (
            [FromForm] CreateUpdateStudentClasroomViewModel studentClasroom,
            CancellationToken cancellationToken
        )
        {
            var Ids = await ValidateId(studentClasroom.ClasroomId, studentClasroom.StudentId, cancellationToken);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(studentClasroom);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createQuery = new CreateStudentClasroomCommand(studentClasroom);
            var result = await _mediator.Send(createQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Delete student endpoint 

        /// <summary>
        ///     Deletes a studentClasroom form database
        /// </summary>
        /// <param name="id"> Id of the student </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message telling if the record was deleted succsessfully </returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentClasroomViewModel))]
        public async Task<IActionResult> DeleteStudentClasroom
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteQuery = new DeleteStudentClasroomCommand(id);
            var result = await _mediator.Send(deleteQuery, cancellationToken);
            return result;
        }

        #endregion
    }
}