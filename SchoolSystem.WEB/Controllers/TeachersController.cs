using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.DTO.ViewModels.Teacher;
using SchoolSystem.BLL.RepositoryServiceInterfaces;

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
        private readonly ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> _teacherService;
        private readonly StatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> _statusCodeResponse;

        /// <summary>
        /// Inject teacher service 
        /// </summary>
        /// <param name="statusCodeResponse"></param>
        /// <param name="teacherService"></param>
        /// <param name="modelValidator"></param>
        public TeachersController
        (
            IValidator<CreateUpdateTeacherViewModel> modelValidator,
            StatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> statusCodeResponse,
            ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> teacherService
        )
        {
            _teacherService = teacherService;
            _modelValidator = modelValidator;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        /// Get all Teachers
        /// </summary>
        /// <returns> All Teachers </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<TeacherViewModel>>> GetTeachers
        (
        )
        {
            var teachers = await _teacherService.GetRecords();
            return _statusCodeResponse.ControllerResponse(teachers);
        }

        /// <summary>
        /// Get a specific teacher
        /// </summary>
        /// <param name="id">Id of the teacher </param>
        /// <returns> The teacher info </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TeacherViewModel>> GetTeacher
        (
            [FromRoute] Guid id
        )
        {
            var teacher = await _teacherService.GetRecord(id);
            return _statusCodeResponse.ControllerResponse(teacher);
        }

        /// <summary>
        /// Update a teacher 
        /// </summary>
        /// <param name="id">Id of the teacher</param>
        /// <param name="teacher"> Teacher object</param>
        /// <returns>The updtated techer </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TeacherViewModel>> PutTeacher
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateTeacherViewModel teacher
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(teacher);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updatedTeacher = await _teacherService.PutRecord(id, teacher);
            return _statusCodeResponse.ControllerResponse(updatedTeacher);
        }

        /// <summary>
        /// Create a teacher 
        /// </summary>
        /// <param name="teacher"> Teacher object </param>
        /// <returns> The created techer </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TeacherViewModel>> PostTeacher
        (
            [FromForm] CreateUpdateTeacherViewModel teacher
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(teacher);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createTeacher = await _teacherService.PostRecord(teacher);
            return _statusCodeResponse.ControllerResponse(createTeacher);
        }

        /// <summary>
        /// Delete a teacher
        /// </summary>
        /// <param name="id">Id of the teacher </param>
        /// <returns>A message if it deleted or not </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TeacherViewModel>> DeleteTeacher
        (
            [FromRoute] Guid id
        )
        {
            var deleteTeacher = await _teacherService.DeleteRecord(id);
            return _statusCodeResponse.ControllerResponse(deleteTeacher);
        }
    }
}