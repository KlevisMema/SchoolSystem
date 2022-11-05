using FluentValidation;
using SchoolSystem.DAL.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;

namespace SchoolSystem.API.Controllers
{
    /// <summary>
    /// Results API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        private readonly IExists _exists;
        private readonly IValidator<CreateUpdateResultViewModel> _modelValidator;
        private readonly ICrudService<ResultViewModel, CreateUpdateResultViewModel> _resultService;
        private readonly StatusCodeResponse<ResultViewModel, List<ResultViewModel>> _statusCodeResponse;

        /// <summary>
        /// Inject Services
        /// </summary>
        /// <param name="resultService"> Result service </param>
        /// <param name="modelValidator"> Validator service </param>
        /// <param name="statusCodeResponse"> Status code response service </param>
        /// <param name="exists">Exists service</param>
        public ResultsController
        (
            IExists exists,
            IValidator<CreateUpdateResultViewModel> modelValidator,
            ICrudService<ResultViewModel, CreateUpdateResultViewModel> resultService,
            StatusCodeResponse<ResultViewModel, List<ResultViewModel>> statusCodeResponse
        )
        {
            _exists = exists;
            _resultService = resultService;
            _modelValidator = modelValidator;
            _statusCodeResponse = statusCodeResponse;
        }


        /// <summary>
        /// Get all results
        /// </summary>
        /// <returns> All results </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<Result>>> GetResults
        (
        )
        {
            var results = await _resultService.GetRecords();
            return _statusCodeResponse.ControllerResponse(results);
        }

        /// <summary>
        /// Get a specific result
        /// </summary>
        /// <param name="id">Id of the result </param>
        /// <returns> The result info </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ResultViewModel>> GetResult
        (
            [FromRoute] Guid id
        )
        {
            var result = await _resultService.GetRecord(id);
            return _statusCodeResponse.ControllerResponse(result);
        }

        /// <summary>
        /// Update a result 
        /// </summary>
        /// <param name="id">Id of the result </param>
        /// <param name="result"> Result object </param>
        /// <returns> The updtated result </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ResultViewModel>> PutResult
        (
            [FromRoute] Guid id,
            [FromForm] CreateUpdateResultViewModel result
        )
        {
            var checkIds = await _exists.DoesExists(result.ExamId, result.StudentId, result.SubjectId);

            if (!checkIds)
                return NotFound("Invalid ids!!");

            ValidationResult validationResult = await _modelValidator.ValidateAsync(result);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var updatedResult = await _resultService.PutRecord(id, result);
            return _statusCodeResponse.ControllerResponse(updatedResult);
        }

        /// <summary>
        /// Create a result 
        /// </summary>
        /// <param name="result"> Result object </param>
        /// <returns> The created result </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ResultViewModel>> PostResult
        (
            [FromForm] CreateUpdateResultViewModel result
        )
        {
            var checkIds = await _exists.DoesExists(result.ExamId, result.StudentId, result.SubjectId);

            if (!checkIds)
                return NotFound("Invalid ids!!");

            ValidationResult validationResult = await _modelValidator.ValidateAsync(result);
            if (!validationResult.IsValid)
                return BadRequest(Results.ValidationProblem(validationResult.ToDictionary()));

            var createResult = await _resultService.PostRecord(result);
            return _statusCodeResponse.ControllerResponse(createResult);
        }

        /// <summary>
        /// Delete a result
        /// </summary>
        /// <param name="id">Id of the result </param>
        /// <returns>A message if it deleted or not </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<ResultViewModel>> DeleteResult
        (
            [FromRoute] Guid id
        )
        {
            var deleteResult = await _resultService.DeleteRecord(id);
            return _statusCodeResponse.ControllerResponse(deleteResult);
        }
    }
}