#region Usings 

using SchoolSystem.DAL.Models;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Subject;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Subject service that implements ICrudService interface, and has all the buisness logic related to subject
    /// </summary>
    public class SubjectService : ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel>
    {
        #region Services 

        /// <summary>
        ///     A readonly field for database actions -> Create,Update,Delete,Get Actions
        /// </summary>
        private readonly DatabaseActionsService<SubjectViewModel, Subject, CreateUpdateSubjectViewModel> _CRUD;

        /// <summary>
        ///     Inject services in constructor
        /// </summary>
        /// <param name="CRUD"> CRUD Services </param>
        public SubjectService
        (
            DatabaseActionsService<SubjectViewModel, Subject, CreateUpdateSubjectViewModel> CRUD
        )
        {
            _CRUD = CRUD;
        }

        #endregion

        #region Get all subjects from subject table

        /// <summary>
        ///     Get all subjects from database
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A list of all subjects </returns>

        public async Task<Response<List<SubjectViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllSubjects = await _CRUD.GetAll(cancellationToken);
            return getAllSubjects;
        }

        #endregion

        #region Get a subject by id from subject table

        /// <summary>
        ///     Get a single subject
        /// </summary>
        /// <param name="id"> Id of a subject </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The object of a specific subject </returns>

        public async Task<Response<SubjectViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getSubject = await _CRUD.GetSpecificRecord(id, "Subject", cancellationToken);
            return getSubject;
        }

        #endregion

        #region Update a existing subject in subject table

        /// <summary>
        ///     Updates a subject  
        /// </summary>
        /// <param name="id"> Id of a subject </param>
        /// <param name="viewModel"> Object that holds the new values of subject </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The updated subject </returns>

        public async Task<Response<SubjectViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateSubjectViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updateSubject = await _CRUD.PutRecord(id, viewModel, "Subject", cancellationToken);
            return updateSubject;
        }

        #endregion

        #region Create a new subject in subject table 

        /// <summary>
        ///     Creates a new subject 
        /// </summary>
        /// <param name="viewModel"> Subject object </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The created subject</returns>

        public async Task<Response<SubjectViewModel>> PostRecord
        (
            CreateUpdateSubjectViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postSubject = await _CRUD.PostRecord(viewModel, "Subject", cancellationToken);
            return postSubject;
        }

        #endregion

        #region Delete a existing subject by id in subject table

        /// <summary>
        ///     Deletes a subject 
        /// </summary>
        /// <param name="id"> Id of the subject</param>
        /// <param name="cancellationToken"> Cancellatio token </param>
        /// <returns> A message telling if the subject was deleted or not </returns>

        public async Task<Response<SubjectViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteSubject = await _CRUD.DeleteRecord(id, "Subject", cancellationToken);
            return deleteSubject;
        }

        #endregion

    }
}