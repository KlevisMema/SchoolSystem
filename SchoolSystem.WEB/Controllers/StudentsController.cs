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
        private readonly IStudentService _studentService;
        private readonly StatusCodeResponse<StudentViewModel, List<StudentViewModel>> _statusCodeResponse;

        /// <summary>
        /// Inject Student Services 
        /// </summary>
        /// <param name="studentService"></param>
        /// <param name="statusCodeResponse"></param>
        public StudentsController(
            IStudentService studentService, 
            StatusCodeResponse<StudentViewModel, List<StudentViewModel>> statusCodeResponse)
        {
            _studentService = studentService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns> All Students </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<List<StudentViewModel>>> GetStudents()
        {
            var students  = await _studentService.GetStudets();
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
        public async Task<ActionResult<List<StudentViewModel>>> GetSpecificStudent(Guid id)
        {
            var student = await _studentService.GetSpecificStudent(id);
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
        public async Task<ActionResult<StudentViewModel>> CreateStudent([FromForm] CreateStudentViewModel newStudent)
        {
            var createStudent = await _studentService.CreateStudent(newStudent);
            return _statusCodeResponse.ControllerResponse(createStudent);
        }

        /// <summary>
        /// Update a student 
        /// </summary>
        /// <param name="id">Id of the teacher</param>
        /// <param name="teacher"> student object</param>
        /// <returns>The updtated student </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<StudentViewModel>> PutStudent([FromRoute] Guid id, [FromForm] UpdateStudentViewModel student)
        {
            var updatedStudent = await _studentService.PutStudent(id, student);
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
            var deleteStudent = await _studentService.DeleteStudent(id);
            return _statusCodeResponse.ControllerResponse(deleteStudent);
        }
    }
}