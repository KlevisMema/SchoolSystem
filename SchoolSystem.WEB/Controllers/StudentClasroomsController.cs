using MediatR;
using FluentValidation;
using SchoolSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Queries;
using SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Commands;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// StudentClasroom API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StudentClasroomsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly I_Valid_Id<Student> i_Valid_Student_Id;
        private readonly I_Valid_Id<Clasroom> i_Valid_Clasroom_Id;
        private readonly IValidator<CreateUpdateStudentClasroomViewModel> _modelValidator;
        private readonly StatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> _statusCodeResponse;
        private readonly ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> _studentClasroomService;
        private async Task<CustomMesageResponse> ValidateId(Guid clasroomid, Guid studentId, CancellationToken cancellationToken)
        {
            var clasroom = await i_Valid_Clasroom_Id.Bool(clasroomid, cancellationToken);
            var student = await i_Valid_Student_Id.Bool(studentId, cancellationToken);

            if (!clasroom)
                return CustomMesageResponse.NotFound(clasroom, "Invalid clasroom id");
            if (!student)
                return CustomMesageResponse.NotFound(student, "Invalid student id");

            return CustomMesageResponse.Succsess();
        }

        /// <summary>
        /// Inject services
        /// </summary>
        /// <param name="studentClasroomService">Student Clasroom servivce</param>
        /// <param name="modelValidator">Model validator service</param>
        /// <param name="statusCodeResponse">Status code response service</param>
        /// <param name="i_Valid_Clasroom_Id">Clasroom valid id service</param>
        /// <param name="i_Valid_Student_Id">Student valid id service</param>
        /// <param name="mediator"> Mediator Service </param>
        public StudentClasroomsController
        (
            I_Valid_Id<Student> i_Valid_Student_Id,
            I_Valid_Id<Clasroom> i_Valid_Clasroom_Id,
            IValidator<CreateUpdateStudentClasroomViewModel> modelValidator,
            StatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> statusCodeResponse,
            ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> studentClasroomService,
            IMediator mediator
        )
        {
            _modelValidator = modelValidator;
            _statusCodeResponse = statusCodeResponse;
            this.i_Valid_Student_Id = i_Valid_Student_Id;
            this.i_Valid_Clasroom_Id = i_Valid_Clasroom_Id;
            _studentClasroomService = studentClasroomService;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all student clasrooms
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns>All students with in a clasroom</returns>
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

        /// <summary>
        /// Get single student clasroom
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns>A student in a clasroom</returns>
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

        /// <summary>
        /// Update a studentclasroom record in StudentClasroom table
        /// </summary>
        /// <param name="studentClasroom">Data from client</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns>The updated record</returns>
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

        /// <summary>
        /// Create a studentclasroom record in database
        /// </summary>
        /// <param name="studentClasroom">Data from client</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns>A message telling if the record was created or not</returns>
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

        /// <summary>
        /// Deletes a studentClasroom form database
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns>A message telling if the record was deleted succsessfully</returns>
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
    }
}