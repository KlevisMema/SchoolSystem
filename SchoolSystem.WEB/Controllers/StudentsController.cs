using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Student;

namespace SchoolSystem.WEB.Controllers
{
    /// <summary>
    /// Student Api Controller default route : api/Students 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ICrudInterfaces<StudentViewModel, CreateUpdateStudentViewModel> _studentService;
        private readonly IValidator<CreateUpdateStudentViewModel> _modelValidator;
        private readonly StatusCodeResponse<StudentViewModel, List<StudentViewModel>> _statusCodeResponse;

        /// <summary>
        /// Inject Student Services 
        /// </summary>
        /// <param name="studentService"></param>
        /// <param name="statusCodeResponse"></param>
        /// <param name="modelValidator"></param>
        public StudentsController(
            ICrudInterfaces<StudentViewModel, CreateUpdateStudentViewModel> studentService,
            StatusCodeResponse<StudentViewModel, List<StudentViewModel>> statusCodeResponse,
            IValidator<CreateUpdateStudentViewModel> modelValidator)
        {
            _studentService = studentService;
            _statusCodeResponse = statusCodeResponse;
            _modelValidator = modelValidator;
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns> All Students </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<StudentViewModel>>> GetStudents()
        {
            var students  = await _studentService.GetRecords();
            return _statusCodeResponse.ControllerResponse(students);
        }

        /// <summary>
        /// Get a specific student by id 
        /// </summary>
        /// <param name="id"> Id of the student </param>
        /// <returns> The student by that id </returns>
        [HttpGet("GetSpecificStudent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<StudentViewModel>>> GetSpecificStudent(Guid id)
        {
            var student = await _studentService.GetRecord(id);
            return _statusCodeResponse.ControllerResponse(student);
        }

        /// <summary>
        /// Create student
        /// </summary>
        /// <param name="newStudent"> Student object cotainig {FullName,Email,Password,Phone,Sex,Adress} </param>
        /// <returns> The created student </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentViewModel>> CreateStudent([FromForm] CreateUpdateStudentViewModel newStudent)
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(newStudent);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createStudent = await _studentService.PostRecord(newStudent);
            return _statusCodeResponse.ControllerResponse(createStudent);
        }

        /// <summary>
        /// Update a student 
        /// </summary>
        /// <param name="id">Id of the teacher</param>
        /// <param name="student"> student object</param>
        /// <returns>The updtated student </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentViewModel>> PutStudent([FromRoute] Guid id, [FromForm] CreateUpdateStudentViewModel student)
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(student);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updatedStudent = await _studentService.PutRecord(id, student);
            return _statusCodeResponse.ControllerResponse(updatedStudent);
        }

        /// <summary>
        /// Delete a student
        /// </summary>
        /// <param name="id">Id of the student </param>
        /// <returns>A message if it deleted or not </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentViewModel>> DeleteStudent(Guid id)
        {
            var deleteStudent = await _studentService.DeleteRecord(id);
            return _statusCodeResponse.ControllerResponse(deleteStudent);
        }
    }
}