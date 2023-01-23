#region Usings 

using SchoolSystem.DAL.Models;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Student Issue servie that implements ICrudService interface, GetRecordFromCompositeKeysTable interface, and has all the logic related to student issue
    /// </summary>
    public class StudentIssueService : ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel>, GetRecordFromCompositeKeysTable<StudentIssueViewModel>
    {
        #region Services 

        /// <summary>
        ///     A readonly field for database actions -> Create,Update,Delete,Get Actions
        /// </summary>
        private readonly DatabaseActionsService<StudentIssueViewModel, StudentIssue, CreateUpdateStudentIssueViewModel> _CRUD;

        /// <summary>
        ///     Inject services in controller
        /// </summary>
        /// <param name="CRUD">CRUD Service </param>
        public StudentIssueService
        (
            DatabaseActionsService<StudentIssueViewModel, StudentIssue, CreateUpdateStudentIssueViewModel> CRUD
        )
        {
            _CRUD = CRUD;
        }

        #endregion

        #region Get all student issues form studentissue table 

        /// <summary>
        ///     Get all student issues
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token  </param>
        /// <returns> A list of all time clasrooms</returns>

        public async Task<Response<List<StudentIssueViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllStudentIssues = await _CRUD.GetAll(cancellationToken);
            return getAllStudentIssues;
        }

        #endregion

        #region Get a student issue by id from student issue table // not used anywhere

        /// <summary>
        ///     Get a single student issue
        /// </summary>
        /// <param name="id"> Id of a clasroom</param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The object of a specific clasroom </returns>

        public async Task<Response<StudentIssueViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getStudentIssues = await _CRUD.GetSpecificRecord(id, "Student issue", cancellationToken);
            return getStudentIssues;
        }

        #endregion

        #region Update an existing student issue from student issue table

        /// <summary>
        ///     Updates a student issue  
        /// </summary>
        /// <param name="id"> Id of a student issue </param>
        /// <param name="viewModel"> Object that holds the new values of student issue </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The updated student issue </returns>

        public async Task<Response<StudentIssueViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateStudentIssueViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updateStudentIssue = await _CRUD.PutRecord(id, viewModel, "Student issue", cancellationToken);
            return updateStudentIssue;
        }

        #endregion

        #region Create a new student issue in student table

        /// <summary>
        ///     Creates a new student issue 
        /// </summary>
        /// <param name="viewModel"> Student issue object </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The created student issue </returns>

        public async Task<Response<StudentIssueViewModel>> PostRecord
        (
            CreateUpdateStudentIssueViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postStudentIssue = await _CRUD.PostRecord(viewModel, "Student issue", cancellationToken);
            return postStudentIssue;
        }

        #endregion

        #region Delete a existing stdent issue from student issue table

        /// <summary>
        ///     Deletes a student issue 
        /// </summary>
        /// <param name="id"> Id of the student issue </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A message telling if the student issue was deleted or not </returns>

        public async Task<Response<StudentIssueViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteStudentIssue = await _CRUD.DeleteRecord(id, "Student issue", cancellationToken);
            return deleteStudentIssue;
        }

        #endregion

        #region Get a student issue from student issue table 

        /// <summary>
        ///     Get a single student issue
        /// </summary>
        /// <param name="FirstId"> Id of the issue</param>
        /// <param name="SecondId"> Id of the student </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> Student issue </returns>
         
        public async Task<Response<StudentIssueViewModel>> GetRecordCompositeKeysTable
        (
            Guid FirstId,
            Guid SecondId,
            CancellationToken cancellationToken
        )
        {
            var getStdentIssue = await _CRUD.GetSpecificRecordCompostieKeyTable(FirstId, SecondId, "Student issue", cancellationToken);
            return getStdentIssue;
        }

        #endregion

    }
}