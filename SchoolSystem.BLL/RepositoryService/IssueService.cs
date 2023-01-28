#region Usings

using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Issue service class that implements ICrud service interface, I_Valid_Id interface, and has all buisness logic related to issue
    /// </summary>
    public class IssueService : ICrudService<IssueViewModel, CreateUpdateIssueViewModel>, I_Valid_Id<Issue>
    {
        #region Services 

        /// <summary>
        ///    A readonly field for Logger
        /// </summary>
        private readonly ILogger<ExamService> _logger;
        /// <summary>
        ///    A readonly field for database actions -> Create,Update,Delete,Get Actions
        /// </summary>
        private readonly DatabaseActionsService<IssueViewModel, Issue, CreateUpdateIssueViewModel> _CRUD;

        public IssueService
        (
            ILogger<ExamService> logger,
            DatabaseActionsService<IssueViewModel, Issue, CreateUpdateIssueViewModel> CRUD
        )
        {
            _CRUD = CRUD;
            _logger = logger;
        }

        #endregion

        #region Get all issues from issue table 

        /// <summary>
        ///     Get all  issues
        /// </summary>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A list of all issues</returns>

        public async Task<Response<List<IssueViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllIssues = await _CRUD.GetAll(cancellationToken);
            return getAllIssues;
        }

        #endregion

        #region Get a issue by if from issue table 

        /// <summary>
        ///     Get a single issue
        /// </summary>
        /// <param name="id"> Id of a issue </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The object of a specific issue</returns>

        public async Task<Response<IssueViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getIssue = await _CRUD.GetSpecificRecord(id, "Issue", cancellationToken);
            return getIssue;
        }

        #endregion

        #region Update an existing issue in issue table 

        /// <summary>
        ///     Updates a issue  
        /// </summary>
        /// <param name="id"> Id of a issue</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <param name="viewModel"> Object that holds the new values of issue </param>
        /// <returns> The updated issue </returns>

        public async Task<Response<IssueViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateIssueViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updateIssue = await _CRUD.PutRecord(id, viewModel, "Issue", cancellationToken);
            return updateIssue;
        }

        #endregion

        #region Create a new issue in issue table

        /// <summary>
        ///     Creates a new issue 
        /// </summary>
        /// <param name="viewModel"> Issue object </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> The created issue </returns>

        public async Task<Response<IssueViewModel>> PostRecord
        (
            CreateUpdateIssueViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postIssue = await _CRUD.PostRecord(viewModel, "Issue", cancellationToken);
            return postIssue;
        }

        #endregion

        #region Deletes a issue from issue table

        /// <summary>
        ///     Deletes a issue 
        /// </summary>
        /// <param name="id"> Id of the issue</param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> A message telling if the issue was deleted or not </returns>

        public async Task<Response<IssueViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteIssue = await _CRUD.DeleteRecord(id, "Issue", cancellationToken);
            return deleteIssue;
        }

        #endregion

        #region Checks if the issue exists in the issue table

        /// <summary>
        ///     Returns True or false if the exam exists in database
        /// </summary>
        /// <param name="id"> Id of the student </param>
        /// <param name="cancellationToken"> Cancellation Token </param>
        /// <returns> True or False </returns>
        public async Task<bool> Bool
        (
             Guid id,
             CancellationToken cancellationToken
        )
        {
            try
            {
                var getAllIssues = await _CRUD.GetAll(cancellationToken);
                var result = getAllIssues.Value;
                return result.Any(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {
                _logger.LogError
                (
                    ex,
                    $" Something went wrong \n" +
                    $"Error, something went wrong !! => \n " +
                    $" Method : {ex.TargetSite} \n" +
                    $" Source : {ex.Source} \n" +
                    $"InnerEx : {ex.InnerException} \n"
                );

                return false;
            }
        }

        #endregion

    }
}