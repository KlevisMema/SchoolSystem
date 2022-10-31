using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Exam;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Exam API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly ICrudService<ExamViewModel, CreateUpdateExamViewModel> _examService;
        private readonly IValidator<CreateUpdateExamViewModel> _modelValidator;
        private readonly StatusCodeResponse<ExamViewModel, List<ExamViewModel>> _statusCodeResponse;

        /// <summary>
        /// Inject services 
        /// </summary>
        /// <param name="examService">Exam service</param>
        /// <param name="statusCodeResponse">status code response service</param>
        /// <param name="modelValidator">Model validation service</param>
        public ExamsController(
            ICrudService<ExamViewModel, CreateUpdateExamViewModel> examService,
            StatusCodeResponse<ExamViewModel, List<ExamViewModel>> statusCodeResponse,
            IValidator<CreateUpdateExamViewModel> modelValidator)
        {
            _examService = examService;
            _statusCodeResponse = statusCodeResponse;
            _modelValidator = modelValidator;
        }

        /// <summary>
        /// Get all Exams
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExamViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<ExamViewModel>>> GetExams()
        {
            var exams = await _examService.GetRecords();
            return _statusCodeResponse.ControllerResponse(exams);
        }

        /// <summary>
        /// Get an exam
        /// </summary>
        /// <param name="id">Id of the exam</param>
        /// <returns>Details of that exam</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExamViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ExamViewModel>> GetExam([FromRoute] Guid id)
        {
            var exam = await _examService.GetRecord(id);
            return _statusCodeResponse.ControllerResponse(exam);
        }

        /// <summary>
        /// Update an exam
        /// </summary>
        /// <param name="id">Id of the  exam</param>
        /// <param name="exam">Exam object from client</param>
        /// <returns>The updated exam </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExamViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> PutExam([FromRoute] Guid id,[FromForm] CreateUpdateExamViewModel exam)
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(exam);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updatedExam = await _examService.PutRecord(id, exam);
            return _statusCodeResponse.ControllerResponse(updatedExam);
        }

        /// <summary>
        /// Creates an exam 
        /// </summary>
        /// <param name="exam">Exam object from client</param>
        /// <returns>A message id exam was created or not</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExamViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<Exam>> PostExam([FromForm] CreateUpdateExamViewModel exam)
        {
            ValidationResult validationResult = await _modelValidator.ValidateAsync(exam);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createStudent = await _examService.PostRecord(exam);
            return _statusCodeResponse.ControllerResponse(createStudent);
        }

        /// <summary>
        /// Deletes an exam
        /// </summary>
        /// <param name="id">Id of the exam</param>
        /// <returns>A message if the exam was deleted or not</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExamViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteExam([FromRoute] Guid id)
        {
            var deleteExam = await _examService.DeleteRecord(id);
            return _statusCodeResponse.ControllerResponse(deleteExam);
        }
    }
}