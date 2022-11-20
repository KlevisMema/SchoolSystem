using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Clasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

namespace SchoolSystem.BLL.RepositoryService
{
    public class ClasroomService : ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel>, I_Valid_Id<Clasroom>
    {
        private readonly ILogger<ClasroomService> _logger;
        private readonly CRUD<ClasroomViewModel, Clasroom, CreateUpdateClasroomViewModel> _CRUD;

        public ClasroomService
        (
            ILogger<ClasroomService> logger,
            CRUD<ClasroomViewModel, Clasroom, CreateUpdateClasroomViewModel> CRUD
        )
        {
            _CRUD = CRUD;
            _logger = logger;
        }

        /// <summary>
        /// Get all clasrooms
        /// </summary>
        /// <returns> a list of all time clasrooms</returns>
        public async Task<Response<List<ClasroomViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllClasrooms = await _CRUD.GetAll(cancellationToken);
            return getAllClasrooms;
        }

        /// <summary>
        /// Get a single clasroom
        /// </summary>
        /// <param name="id"> Id of a clasroom</param>
        /// <returns> The object of a specific clasroom</returns>
        public async Task<Response<ClasroomViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getClasroom = await _CRUD.GetSpecificRecord(id, "Clasroom", cancellationToken);
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
            CreateUpdateClasroomViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updatetClasroom = await _CRUD.PutRecord(id, viewModel, "Clasroom", cancellationToken);
            return updatetClasroom;
        }

        /// <summary>
        /// Creates a new clasroom 
        /// </summary>
        /// <param name="viewModel">clasroom object </param>
        /// <returns>The created clasroom</returns>
        public async Task<Response<ClasroomViewModel>> PostRecord
        (
            CreateUpdateClasroomViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postClasroom = await _CRUD.PostRecord(viewModel, "Clasroom", cancellationToken);
            return postClasroom;
        }

        /// <summary>
        /// Deletes a clasroom 
        /// </summary>
        /// <param name="id">Id of the clasroom</param>
        /// <returns>A message telling if the clasroom was deleted or not</returns>
        public async Task<Response<ClasroomViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteClasroom = await _CRUD.DeleteRecord(id, "Clasroom", cancellationToken);
            return deleteClasroom;
        }

        /// <summary>
        ///     Returns true or false if the clasroom exists or not
        /// </summary>
        /// <param name="id">Id of the clasroom</param>
        public async Task<bool> Bool
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var clasroomServices = await _CRUD.GetAll(cancellationToken);
                var result = clasroomServices.Value;
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
    }
}