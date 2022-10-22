using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.DTO.ViewModels;

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

        /// <summary>
        /// Inject Student Services 
        /// </summary>
        /// <param name="studentService"></param>
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns> All Students </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StudentViewModel))]
        public async Task<ActionResult<List<StudentViewModel>>> GetStudents()
        {
            var students  = await _studentService.GetStudets();

            if (students.Success)
                return Ok(students.Value);

            return BadRequest(students.Message);
        }

        /// <summary>
        /// Get a specific by id 
        /// </summary>
        /// <param name="id"> Id of the student </param>
        /// <returns> The student by that id </returns>
        [HttpGet("GetSpecificStudent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StudentViewModel))]
        public async Task<ActionResult<List<StudentViewModel>>> GetSpecificStudent(Guid id)
        {
            var student = await _studentService.GetSpecificStudent(id);

            if (student.Success)
                return Ok(student.Value);

            if (student.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound(student.Message);

            return BadRequest(student.Message);
        }

        /// <summary>
        /// Create student
        /// </summary>
        /// <param name="newStudent"> Student object cotainig {FullName,Email,Password,Phone,Sex,Adress} </param>
        /// <returns> The created student </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StudentViewModel))]
        public async Task<ActionResult<StudentViewModel>> CreateStudent([FromForm] CreateStudentViewModel newStudent)
        {
            if (ModelState.IsValid)
            {
                var createStudent = await _studentService.CreateStudent(newStudent);

                if (createStudent.Success)
                    return Ok(createStudent.Value);

                return BadRequest(createStudent.Message);
            }
            return BadRequest(ModelState);
        }
    }
}