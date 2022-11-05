using SchoolSystem.DAL.Models;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.Clasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

namespace SchoolSystem.BLL.RepositoryService
{
    public class ClasroomService : ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel>
    {
        private readonly CRUD<ClasroomViewModel, Clasroom, CreateUpdateClasroomViewModel> _CRUD;

        public ClasroomService
        (
            CRUD<ClasroomViewModel, Clasroom, CreateUpdateClasroomViewModel> CRUD
        )
        {
            _CRUD = CRUD;
        }

        /// <summary>
        /// Get all clasrooms
        /// </summary>
        /// <returns> a list of all time clasrooms</returns>
        public async Task<Response<List<ClasroomViewModel>>> GetRecords
        (
        )
        {
            var getAllClasrooms = await _CRUD.GetAll();
            return getAllClasrooms;
        }

        /// <summary>
        /// Get a single clasroom
        /// </summary>
        /// <param name="id"> Id of a clasroom</param>
        /// <returns> The object of a specific clasroom</returns>
        public async Task<Response<ClasroomViewModel>> GetRecord
        (
            Guid id
        )
        {
            var getClasroom = await _CRUD.GetSpecificRecord(id, "Clasroom");
            return getClasroom;
        }

        /// <summary>
        /// Updates a clasroom  
        /// </summary>
        /// <param name="id">Id of a clasroom </param>
        /// <param name="viewModel">Object that holds the new values of clasroom </param>
        /// <returns>The updated clasroom</returns>
        public async Task<Response<ClasroomViewModel>> PutRecord
        (
            Guid id, 
            CreateUpdateClasroomViewModel viewModel
        )
        {
            var updatetClasroom = await _CRUD.PutRecord(id, viewModel, "Clasroom");
            return updatetClasroom;
        }

        /// <summary>
        /// Creates a new clasroom 
        /// </summary>
        /// <param name="viewModel">clasroom object </param>
        /// <returns>The created clasroom</returns>
        public async Task<Response<ClasroomViewModel>> PostRecord
        (
            CreateUpdateClasroomViewModel viewModel
        )
        {
            var postClasroom = await _CRUD.PostRecord(viewModel, "Clasroom");
            return postClasroom;
        }

        /// <summary>
        /// Deletes a clasroom 
        /// </summary>
        /// <param name="id">Id of the clasroom</param>
        /// <returns>A message telling if the clasroom was deleted or not</returns>
        public async Task<Response<ClasroomViewModel>> DeleteRecord
        (
            Guid id
        )
        {
            var deleteClasroom = await _CRUD.DeleteRecord(id, "Clasroom");
            return deleteClasroom;
        }
    }
}