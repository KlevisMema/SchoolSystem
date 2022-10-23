using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Teacher;
using System.Net;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Teachers API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        /// <summary>
        /// Inject teacher service 
        /// </summary>
        /// <param name="teacherService"></param>
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// Get all Teachers
        /// </summary>
        /// <returns> All Students </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherViewModel>>> GetTeachers()
        {
            var teachers = await _teacherService.GetTeachers();

            if (teachers.Success)
                return Ok(teachers.Value);

            return BadRequest(teachers.Message);
        }

        /// <summary>
        /// Get a specific teacher
        /// </summary>
        /// <param name="id">Id of the teacher </param>
        /// <returns> The teacher info </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherViewModel>> GetTeacher(Guid id)
        {
            var teacher = await _teacherService.GetTeacher(id);

            if (teacher.Success)
                return Ok(teacher.Value);

            if (teacher.StatusCode == HttpStatusCode.NotFound)
                return NotFound(teacher.Message);

            return BadRequest(teacher.Message);
        }

        /// <summary>
        /// Update a teacher 
        /// </summary>
        /// <param name="id">Id of the teacher</param>
        /// <param name="teacher"> Teacher object</param>
        /// <returns>The updtated techer </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherViewModel>> PutTeacher([FromRoute] Guid id, [FromForm] UpdateTeacherViewModel teacher)
        {
            var updatedTeacher = await _teacherService.PutTeacher(id, teacher);

            if (updatedTeacher.Success)
                return Ok(updatedTeacher.Value);

            if (updatedTeacher.StatusCode == HttpStatusCode.NotFound)
                return NotFound(updatedTeacher.Message);

            return BadRequest(updatedTeacher.Message);
        }

        /// <summary>
        /// Create a teacher 
        /// </summary>
        /// <param name="teacher"> Teacher object </param>
        /// <returns> The created techer </returns>
        [HttpPost]
        public async Task<ActionResult<TeacherViewModel>> PostTeacher([FromForm] CreateTeacherViewModel teacher)
        {
            var createTeacher = await _teacherService.PostTeacher(teacher);

            if (createTeacher.Success)
                return Ok(createTeacher.Value);

            return BadRequest(createTeacher.Message);
        }

        /// <summary>
        /// Delete a teacher
        /// </summary>
        /// <param name="id">Id of the teacher </param>
        /// <returns>A message if it deleted or not </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeacherViewModel>> DeleteTeacher(Guid id)
        {
            var deleteTeacher = await _teacherService.DeleteTeacher(id);

            if (deleteTeacher.Success)
                return Ok(deleteTeacher.Message);

            return BadRequest(deleteTeacher.Message);

        }
    }
}