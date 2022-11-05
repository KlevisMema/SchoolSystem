using SchoolSystem.DAL.Models;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Subject;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

namespace SchoolSystem.BLL.RepositoryService
{
    public class SubjectService : ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel>
    {
        private readonly CRUD<SubjectViewModel, Subject, CreateUpdateSubjectViewModel> _CRUD;

        public SubjectService
        (
            CRUD<SubjectViewModel, Subject, CreateUpdateSubjectViewModel> CRUD
        )
        {
            _CRUD = CRUD;
        }

        /// <summary>
        /// Get all subjects from database
        /// </summary>
        /// <returns> A list of all subjects</returns>
        public async Task<Response<List<SubjectViewModel>>> GetRecords
        (
        )
        {
            var getAllSubjects = await _CRUD.GetAll();
            return getAllSubjects;
        }

        /// <summary>
        /// Get a single subject
        /// </summary>
        /// <param name="id"> Id of a subject</param>
        /// <returns> The object of a specific subject</returns>
        public async Task<Response<SubjectViewModel>> GetRecord
        (
            Guid id
        )
        {
            var getSubject = await _CRUD.GetSpecificRecord(id, "Subject");
            return getSubject;
        }

        /// <summary>
        /// Updates a subject  
        /// </summary>
        /// <param name="id">Id of a subject</param>
        /// <param name="viewModel">Object that holds the new values of subject </param>
        /// <returns>The updated subject</returns>
        public async Task<Response<SubjectViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateSubjectViewModel viewModel
        )
        {
            var updateSubject = await _CRUD.PutRecord(id, viewModel, "Subject");
            return updateSubject;
        }

        /// <summary>
        /// Creates a new subject 
        /// </summary>
        /// <param name="viewModel">subject object </param>
        /// <returns>The created subject</returns>
        public async Task<Response<SubjectViewModel>> PostRecord
        (
            CreateUpdateSubjectViewModel viewModel
        )
        {
            var postSubject = await _CRUD.PostRecord(viewModel, "Subject");
            return postSubject;
        }

        /// <summary>
        /// Deletes a subject 
        /// </summary>
        /// <param name="id">Id of the subject</param>
        /// <returns>A message telling if the subject was deleted or not</returns>
        public async Task<Response<SubjectViewModel>> DeleteRecord
        (
            Guid id
        )
        {
            var deleteSubject = await _CRUD.DeleteRecord(id, "Subject");
            return deleteSubject;
        }
    }
}