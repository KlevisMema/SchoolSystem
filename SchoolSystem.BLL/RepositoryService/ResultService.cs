using SchoolSystem.DAL.Models;
using SchoolSystem.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

namespace SchoolSystem.BLL.RepositoryService
{
    public class ResultService : ICrudService<ResultViewModel, CreateUpdateResultViewModel>, IExists
    {
        private readonly ApplicationDbContext _context;
        private readonly CRUD<ResultViewModel, Result, CreateUpdateResultViewModel> _CRUD;

        public ResultService
        (
             CRUD<ResultViewModel, Result, CreateUpdateResultViewModel> CRUD,
             ApplicationDbContext context
        )
        {
            _CRUD = CRUD;
            _context = context;
        }

        /// <summary>
        /// Get all result from database
        /// </summary>
        /// <returns> A list of all results</returns>
        public async Task<Response<List<ResultViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllResults = await _CRUD.GetAll(cancellationToken);
            return getAllResults;
        }

        /// <summary>
        /// Get a single result
        /// </summary>
        /// <param name="id"> Id of a result</param>
        /// <returns> The object of a specific result</returns>
        public async Task<Response<ResultViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getResult = await _CRUD.GetSpecificRecord(id, "Result", cancellationToken);
            return getResult;
        }

        /// <summary>
        /// Updates a result  
        /// </summary>
        /// <param name="id">Id of a result</param>
        /// <param name="viewModel">Object that holds the new values of result </param>
        /// <returns>The updated result</returns>
        public async Task<Response<ResultViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateResultViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updateResult = await _CRUD.PutRecord(id, viewModel, "Result", cancellationToken);
            return updateResult;
        }

        /// <summary>
        /// Creates a new result 
        /// </summary>
        /// <param name="viewModel">  Result object </param>
        /// <returns> The created result </returns>
        public async Task<Response<ResultViewModel>> PostRecord
        (
            CreateUpdateResultViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postResult = await _CRUD.PostRecord(viewModel, "Result", cancellationToken);
            return postResult;
        }

        /// <summary>
        /// Deletes a result 
        /// </summary>
        /// <param name="id"> Id of the result </param>
        /// <returns> A message telling if the result was deleted or not </returns>
        public async Task<Response<ResultViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteResult = await _CRUD.DeleteRecord(id, "Result", cancellationToken);
            return deleteResult;
        }

        /// <summary>
        ///  Returns true if all ids are valid and false if not
        /// </summary>
        /// <param name="examId"></param>
        /// <param name="studentId"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public async Task<bool> DoesExists
        (
            Guid examId,
            Guid studentId,
            Guid subjectId
        )
        {
            try
            {
                var exam = await _context.Exams.AnyAsync(exam => exam.Id.Equals(examId));
                var student = await _context.Students.AnyAsync(student => student.Id.Equals(studentId));
                var subject = await _context.Subjects.AnyAsync(subject => subject.Id.Equals(subjectId));

                if (exam is false || student is false || subject is false)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}