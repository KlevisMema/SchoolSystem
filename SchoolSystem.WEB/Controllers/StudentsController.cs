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
    }
}