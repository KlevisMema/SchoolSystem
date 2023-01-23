#region Usings

using SchoolSystem.DAL.Models;
using SchoolSystem.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Result service that implements ICrud interface, IExists interface and, has all buisness logic related to result
    /// </summary>
    public class ResultService : ICrudService<ResultViewModel, CreateUpdateResultViewModel>, IExists
    {
        #region Services 

        /// <summary>
        ///    A readonly field for database context
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        ///    A readonly field for database actions -> Create,Update,Delete,Get Actions
        /// </summary>
        private readonly DatabaseActionsService<ResultViewModel, Result, CreateUpdateResultViewModel> _CRUD;

        /// <summary>
        ///     Inject services in constructor
        /// </summary>
        /// <param name="CRUD"> CRUD Services </param>
        /// <param name="context"> Database context services </param>
        public ResultService
        (
             DatabaseActionsService<ResultViewModel, Result, CreateUpdateResultViewModel> CRUD,
             ApplicationDbContext context
        )
        {
            _CRUD = CRUD;
            _context = context;
        }
        #endregion

        #region Get all result form result table

        /// <summary>
        ///     Get all result from database
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A list of all results </returns>
        
        public async Task<Response<List<ResultViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllResults = await _CRUD.GetAll(cancellationToken);
            return getAllResults;
        }

        #endregion

        #region Get a single result by id from result table

        /// <summary>
        ///     Get a single result
        /// </summary>
        /// <param name="id"> Id of a result </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The object of a specific result </returns>
         
        public async Task<Response<ResultViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getResult = await _CRUD.GetSpecificRecord(id, "Result", cancellationToken);
            return getResult;
        }

        #endregion

        #region Update a existing result in result table

        /// <summary>
        ///     Updates a result  
        /// </summary>
        /// <param name="id"> Id of a result </param>
        /// <param name="viewModel"> Object that holds the new values of result </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The updated result </returns>
         
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

        #endregion

        #region Create a new result in result table 

        /// <summary>
        ///     Creates a new result 
        /// </summary>
        /// <param name="viewModel">  Result object </param>
        /// <param name="cancellationToken"> Cancellation token </param>
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

        #endregion

        #region Deletes a result by id from result table

        /// <summary>
        ///     Deletes a result 
        /// </summary>
        /// <param name="id"> Id of the result </param>
        /// <param name="cancellationToken"> Cancellation token </param>
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

        #endregion

        #region Checks if the result exists or not

        /// <summary>
        ///     Returns true if all ids are valid and false if not
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

        #endregion

    }
}