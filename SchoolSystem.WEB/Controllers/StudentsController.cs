#region Usings

using MediatR;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Student;
using SchoolSystem.BLL.MediatrService.Actions.Student.Queries;
using SchoolSystem.BLL.MediatrService.Actions.Student.Commands;

#endregion

namespace SchoolSystem.WEB.Controllers
{
    /// <summary>
    /// Student Api Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateUpdateStudentViewModel> _modelValidator;

        #region Inject all services in ctor

        /// <summary>
        /// Inject Student Services 
        /// </summary>
        /// <param name="modelValidator"></param>
        /// <param name="mediator"></param>

        public StudentsController
        (
            IMediator mediator,
            IValidator<CreateUpdateStudentViewModel> modelValidator
        )
        {
            _mediator = mediator;
            _modelValidator = modelValidator;
        }
        #endregion

        #region Get all students endpoint

        /// <summary>
        ///     Get all students
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> All Students </returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<StudentViewModel>>> GetStudents
        (
            CancellationToken cancellationToken
        )
        {
            var getAllQuery = new GetAllStudentsQuery();
            var result = await _mediator.Send(getAllQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Get a student by id endpoint

        /// <summary>
        ///     Get a specific student by id 
        /// </summary>
        /// <param name="id"> Id of the student </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The student by that id </returns>

        [HttpGet("GetSpecificStudent")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<StudentViewModel>>> GetSpecificStudent
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getByIdQuery = new GetStudentByIdQuery(id);
            var result = await _mediator.Send(getByIdQuery, cancellationToken);
            return result;
        }

        #endregion

        #region Create a student endpoint

        /// <summary>
        ///     Create student
        /// </summary>
        /// <param name="newStudent"> Student object cotainig {FullName,Email,Password,Phone,Sex,Adress} </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The created student </returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentViewModel>> CreateStudent
        (
            [FromForm] CreateUpdateStudentViewModel newStudent,
            CancellationToken cancellationToken
        )
        {
            #region Validate /CreateUpdateStudentViewModel/ object values
            ValidationResult validationResult = await _modelValidator.ValidateAsync(newStudent, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));
            #endregion

            #region Create Student
            var createCommad = new CreateStudentCommad(newStudent);
            var result = await _mediator.Send(createCommad, cancellationToken);
            return result;
            #endregion
        }
        #endregion

        #region Update a student endpoint

        /// <summary>
        ///     Update a student 
        /// </summary>
        /// <param name="id"> Id of the teacher </param>
        /// <param name="student"> Student object </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The updtated student </returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentViewModel>> PutStudent
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateStudentViewModel student,
            CancellationToken cancellationToken
        )
        {
            #region Validate /CreateUpdateStudentViewModel/ object values
            ValidationResult validationResult = await _modelValidator.ValidateAsync(student, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));
            #endregion

            #region Update Student
            var updateCommad = new UpdateStudentCommand(id, student);
            var result = await _mediator.Send(updateCommad, cancellationToken);
            return result;
            #endregion
        }

        #endregion

        #region Delete student endpoint

        /// <summary>
        ///     Delete a student
        /// </summary>
        /// <param name="id"> Id of the student </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message if it deleted or not </returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentViewModel>> DeleteStudent
        (
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteCommad = new DeleteStudentCommand(id);
            var result = await _mediator.Send(deleteCommad, cancellationToken);
            return result;
        }

        #endregion
    }
}