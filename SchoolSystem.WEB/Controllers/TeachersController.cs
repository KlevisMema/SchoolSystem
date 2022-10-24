using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Teacher;

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
        private readonly IValidator<CreateTeacherViewModel> _createModelValidator;
        private readonly IValidator<UpdateTeacherViewModel> _updateModelValidator;
        private readonly StatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> _statusCodeResponse;

        /// <summary>
        /// Inject teacher service 
        /// </summary>
        /// <param name="statusCodeResponse"></param>
        /// <param name="teacherService"></param>
        /// <param name="createModelValidator"></param>
        /// <param name="updateModelValidator"></param>
        public TeachersController(
            ITeacherService teacherService,
            StatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> statusCodeResponse,
            IValidator<CreateTeacherViewModel> createModelValidator,
            IValidator<UpdateTeacherViewModel> updateModelValidator)
        {
            _teacherService = teacherService;
            _statusCodeResponse = statusCodeResponse;
            _createModelValidator = createModelValidator;
            _updateModelValidator = updateModelValidator;
        }

        /// <summary>
        /// Get all Teachers
        /// </summary>
        /// <returns> All Students </returns>
        [HttpGet]
        public async Task<ActionResult<List<TeacherViewModel>>> GetTeachers()
        {
            var teachers = await _teacherService.GetTeachers();
            return _statusCodeResponse.ControllerResponse(teachers);
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
            return _statusCodeResponse.ControllerResponse(teacher); 
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
            ValidationResult validationResult = await _updateModelValidator.ValidateAsync(teacher);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updatedTeacher = await _teacherService.PutTeacher(id, teacher);
            return _statusCodeResponse.ControllerResponse(updatedTeacher);
        }

        /// <summary>
        /// Create a teacher 
        /// </summary>
        /// <param name="teacher"> Teacher object </param>
        /// <returns> The created techer </returns>
        [HttpPost]
        public async Task<ActionResult<TeacherViewModel>> PostTeacher([FromForm] CreateTeacherViewModel teacher)
        {
            ValidationResult validationResult = await _createModelValidator.ValidateAsync(teacher);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createTeacher = await _teacherService.PostTeacher(teacher);
            return _statusCodeResponse.ControllerResponse(createTeacher);
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
            return _statusCodeResponse.ControllerResponse(deleteTeacher);
        }
    }
}