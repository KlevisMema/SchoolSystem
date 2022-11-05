using SchoolSystem.DAL.Models;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

namespace SchoolSystem.BLL.RepositoryService
{
    public class StudentIssueService : ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel>
    {
        private readonly CRUD<StudentIssueViewModel, StudentIssue, CreateUpdateStudentIssueViewModel> _CRUD;

        public StudentIssueService
        (
            CRUD<StudentIssueViewModel, StudentIssue, CreateUpdateStudentIssueViewModel> CRUD
        )
        {
            _CRUD = CRUD;
        }

        /// <summary>
        /// Get all student issues
        /// </summary>
        /// <returns> a list of all time clasrooms</returns>
        public async Task<Response<List<StudentIssueViewModel>>> GetRecords
        (
        )
        {
            var getAllStudentIssues = await _CRUD.GetAll();
            return getAllStudentIssues;
        }

        /// <summary>
        /// Get a single student issue
        /// </summary>
        /// <param name="id"> Id of a clasroom</param>
        /// <returns> The object of a specific clasroom</returns>
        public async Task<Response<StudentIssueViewModel>> GetRecord
        (
            Guid id
        )
        {
            var getStudentIssues = await _CRUD.GetSpecificRecord(id, "Student issue");
            return getStudentIssues;
        }

        /// <summary>
        /// Updates a student issue  
        /// </summary>
        /// <param name="id">Id of a student issue </param>
        /// <param name="viewModel">Object that holds the new values of student issue </param>
        /// <returns>The updated student issue</returns>
        public async Task<Response<StudentIssueViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateStudentIssueViewModel viewModel
        )
        {
            var updateStudentIssue = await _CRUD.PutRecord(id, viewModel, "Student issue");
            return updateStudentIssue;
        }

        /// <summary>
        /// Creates a new student issue 
        /// </summary>
        /// <param name="viewModel">Student issue object </param>
        /// <returns>The created student issue</returns>
        public async Task<Response<StudentIssueViewModel>> PostRecord
        (
            CreateUpdateStudentIssueViewModel viewModel
        )
        {
            var postStudentIssue = await _CRUD.PostRecord(viewModel, "Student issue");
            return postStudentIssue;
        }

        /// <summary>
        /// Deletes a student issue 
        /// </summary>
        /// <param name="id">Id of the student issue</param>
        /// <returns>A message telling if the student issue was deleted or not</returns>
        public async Task<Response<StudentIssueViewModel>> DeleteRecord
        (
            Guid id
        )
        {
            var deleteStudentIssue = await _CRUD.DeleteRecord(id, "Student issue");
            return deleteStudentIssue;
        }
    }
}