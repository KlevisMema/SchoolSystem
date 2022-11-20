using SchoolSystem.DAL.Models;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

namespace SchoolSystem.BLL.RepositoryService
{
    public class IssueService : ICrudService<IssueViewModel, CreateUpdateIssueViewModel>
    {
        private readonly CRUD<IssueViewModel, Issue, CreateUpdateIssueViewModel> _CRUD;

        public IssueService
        (
            CRUD<IssueViewModel, Issue, CreateUpdateIssueViewModel> CRUD
        )
        {
            _CRUD = CRUD;
        }

        /// <summary>
        /// Get all exams from issues
        /// </summary>
        /// <returns> a list of all issues</returns>
        public async Task<Response<List<IssueViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllIssues = await _CRUD.GetAll(cancellationToken);
            return getAllIssues;
        }

        /// <summary>
        /// Get a single issue
        /// </summary>
        /// <param name="id"> Id of a issue</param>
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

        /// <summary>
        /// Updates a issue  
        /// </summary>
        /// <param name="id">Id of a issue</param>
        /// <param name="viewModel">Object that holds the new values of issue </param>
        /// <returns>The updated issue</returns>
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

        /// <summary>
        /// Creates a new issue 
        /// </summary>
        /// <param name="viewModel">Issue object </param>
        /// <returns>The created issue</returns>
        public async Task<Response<IssueViewModel>> PostRecord
        (
            CreateUpdateIssueViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postIssue = await _CRUD.PostRecord(viewModel, "Issue", cancellationToken);
            return postIssue;
        }

        /// <summary>
        /// Deletes a issue 
        /// </summary>
        /// <param name="id">Id of the issue</param>
        /// <returns>A message telling if the issue was deleted or not</returns>
        public async Task<Response<IssueViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteIssue = await _CRUD.DeleteRecord(id, "Issue", cancellationToken);
            return deleteIssue;
        }
    }
}