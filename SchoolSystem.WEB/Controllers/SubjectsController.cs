using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.DTO.ViewModels.Subject;
using SchoolSystem.BLL.RepositoryServiceInterfaces;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Subject API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IValidator<CreateUpdateSubjectViewModel> _modelValidator;
        private readonly ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> _subjectService;
        private readonly StatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> _statusCodeResponse;

        /// <summary>
        /// Inject services
        /// </summary>
        /// <param name="modelValidator"> ModelVlidator service</param>
        /// <param name="statusCodeResponse"> Status Code response service</param>
        /// <param name="subjectService"> Subject service </param>
        public SubjectsController
        (
            IValidator<CreateUpdateSubjectViewModel> modelValidator,
            ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> subjectService,
            StatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> statusCodeResponse
        )
        {
            _subjectService = subjectService;
            _modelValidator = modelValidator;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        /// Get all Subjects
        /// </summary>
        /// <returns> All subjects </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<SubjectViewModel>>> GetSubjects
        (
        )
        {
            var subjects = await _subjectService.GetRecords();
            return _statusCodeResponse.ControllerResponse(subjects);
        }

        /// <summary>
        /// Get a specific subject
        /// </summary>
        /// <param name="id">Id of the subject </param>
        /// <returns> The subject info </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<SubjectViewModel>> GetSubject
        (
           [FromRoute] Guid id
        )
        {
            var subject = await _subjectService.GetRecord(id);
            return _statusCodeResponse.ControllerResponse(subject);
        }

        /// <summary>
        /// Update a subject 
        /// </summary>
        /// <param name="id">Id of the subject</param>
        /// <param name="subject"> Subject object</param>
        /// <returns>The updtated subject </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<SubjectViewModel>> PutSubject
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateSubjectViewModel subject
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(subject);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updatedSubject = await _subjectService.PutRecord(id, subject);
            return _statusCodeResponse.ControllerResponse(updatedSubject);
        }

        /// <summary>
        /// Create a subject 
        /// </summary>
        /// <param name="subject"> Subject object </param>
        /// <returns> The created subject </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<SubjectViewModel>> PostSubject
        (
            [FromForm] CreateUpdateSubjectViewModel subject
        )
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(subject);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createSubject = await _subjectService.PostRecord(subject);
            return _statusCodeResponse.ControllerResponse(createSubject);
        }

        /// <summary>
        /// Delete a subject
        /// </summary>
        /// <param name="id">Id of the subject </param>
        /// <returns>A message if it deleted or not </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<SubjectViewModel>> DeleteSubject
        (
            [FromRoute] Guid id
        )
        {
            var deleteSubject = await _subjectService.DeleteRecord(id);
            return _statusCodeResponse.ControllerResponse(deleteSubject);
        }
    }
}