using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.DTO.ViewModels.Clasroom;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Clasroom API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClasroomsController : ControllerBase
    {
        private readonly ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> _clasroomService;
        private readonly IValidator<CreateUpdateClasroomViewModel> _modelValidator;
        private readonly StatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> _statusCodeResponse;
        private readonly I_Valid_Id<Teacher> _Teacher_Valid_Id;
        private readonly I_Valid_Id<TimeTable> _TimeTable_Valid_Id;

        private async Task<CustomMesageResponse> ValidateId
        (
            Guid teacherId, 
            Guid timetableId
        )
        {
            var teacher = await _Teacher_Valid_Id.Bool(teacherId);
            var timetable = await _TimeTable_Valid_Id.Bool(timetableId);

            if (!teacher)
                return CustomMesageResponse.NotFound(teacher, "Invalid teacher id");
            if (!timetable)
                return CustomMesageResponse.NotFound(timetable, "Invalid timetable id");

            return CustomMesageResponse.Succsess();
        }

        /// <summary>
        /// Inject Services
        /// </summary>
        /// <param name="clasroomService">Clasroom service</param>
        /// <param name="modelValidator">Model validator service</param>
        /// <param name="statusCodeResponse">Status code response</param>
        /// <param name="teacher_Valid_Id">Teacher valid id service</param>
        /// <param name="timeTable_Valid_Id">Time Table valid id service</param>
        public ClasroomsController
        (
            ICrudService<ClasroomViewModel,
            CreateUpdateClasroomViewModel> clasroomService, IValidator<CreateUpdateClasroomViewModel> modelValidator,
            StatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> statusCodeResponse,
            I_Valid_Id<Teacher> teacher_Valid_Id,
            I_Valid_Id<TimeTable> timeTable_Valid_Id
        )
        {
            _clasroomService = clasroomService;
            _modelValidator = modelValidator;
            _statusCodeResponse = statusCodeResponse;
            _Teacher_Valid_Id = teacher_Valid_Id;
            _TimeTable_Valid_Id = timeTable_Valid_Id;
        }

        /// <summary>
        /// Get all clasrooms
        /// </summary>
        /// <returns>A list of clasrooms</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<ClasroomViewModel>>> GetClasrooms
        (
        )
        {
            var clasrooms = await _clasroomService.GetRecords();
            return _statusCodeResponse.ControllerResponse(clasrooms);
        }

        /// <summary>
        /// Get one clasroom by id
        /// </summary>
        /// <param name="id">Id of the clasroom</param>
        /// <returns>The clasroom with that specific id</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ClasroomViewModel>> GetClasroom
        (
            [FromRoute] Guid id
        )
        {
            var clasroom = await _clasroomService.GetRecord(id);
            return _statusCodeResponse.ControllerResponse(clasroom);
        }

        /// <summary>
        /// Update a clasroom
        /// </summary>
        /// <param name="id">Id of the clasroom</param>
        /// <param name="clasroom">Client data object</param>
        /// <returns>The updated clasroom</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> PutClasroom
        (
            [FromRoute] Guid id, 
            [FromForm] CreateUpdateClasroomViewModel clasroom
        )
        {
            var Ids = await ValidateId(clasroom.TeacherId, clasroom.TimeTableId);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(clasroom);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updatedClasroom = await _clasroomService.PutRecord(id, clasroom);
            return _statusCodeResponse.ControllerResponse(updatedClasroom);
        }

        /// <summary>
        /// Create  a new clasroom
        /// </summary>
        /// <param name="clasroom">Clasroom client object</param>
        /// <returns>A message telling if the clasroom  was created or not</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClasroomViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ClasroomViewModel>> PostClasroom
        (
            [FromForm] CreateUpdateClasroomViewModel clasroom
        )
        {
            var Ids = await ValidateId(clasroom.TeacherId, clasroom.TimeTableId);
            if (!Ids.Exists)
                return NotFound(Ids.CustomMessage);

            ValidationResult validationResult = await _modelValidator.ValidateAsync(clasroom);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createClasroom = await _clasroomService.PostRecord(clasroom);
            return _statusCodeResponse.ControllerResponse(createClasroom);
        }

        /// <summary>
        /// Delete a clasroom by id
        /// </summary>
        /// <param name="id">Id of the clasroom</param>
        /// <returns>A message telling if the clasroom was deleted or not</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttendanceViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteClasroom
        (
            Guid id
        )
        {
            var deleteClasroom = await _clasroomService.DeleteRecord(id);
            return _statusCodeResponse.ControllerResponse(deleteClasroom);
        }
    }
}