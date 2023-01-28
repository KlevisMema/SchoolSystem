#region Usings

using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Clasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Clasroom service that implements ICrud interface and I_Valid_Id interface, and has all buisness logic related to Clasroom
    /// </summary>
    public class ClasroomService : ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel>, I_Valid_Id<Clasroom>
    {
        #region Services

        /// <summary>
        ///   A readonly field for Loger 
        /// </summary>
        private readonly ILogger<ClasroomService> _logger;
        /// <summary>
        ///   A readonly field for database actions -> Create,Update,Delete,Get Actions
        /// </summary>
        private readonly DatabaseActionsService<ClasroomViewModel, Clasroom, CreateUpdateClasroomViewModel> _CRUD;

        /// <summary>
        ///     Inject services in constructor
        /// </summary>
        /// <param name="logger"> Logger service </param>
        /// <param name="CRUD"> CRUD Service </param>
        public ClasroomService
        (
            ILogger<ClasroomService> logger,
            DatabaseActionsService<ClasroomViewModel, Clasroom, CreateUpdateClasroomViewModel> CRUD
        )
        {
            _CRUD = CRUD;
            _logger = logger;
        }

        #endregion

        #region Get all clasrooms from clasroom table 

        /// <summary>
        ///     Get all clasrooms
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> a list of all time clasrooms</returns>

        public async Task<Response<List<ClasroomViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllClasrooms = await _CRUD.GetAll(cancellationToken);
            return getAllClasrooms;
        }

        #endregion 

        #region Get a clasroom by id from clasroom table 

        /// <summary>
        ///     Get a single clasroom
        /// </summary>
        /// <param name="id"> Id of a clasroom</param>
        /// <param name="cancellationToken"> Cancellation token </param>
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

        #endregion

        #region Update a existing clasroom in clasroom table 

        /// <summary>
        ///     Updates a clasroom  
        /// </summary>
        /// <param name="id"> Id of a clasroom </param>
        /// <param name="viewModel"> Object that holds the new values of clasroom </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The updated clasroom </returns>

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

        #endregion

        #region Creates a new clasroom in clasroom table 

        /// <summary>
        ///     Creates a new clasroom 
        /// </summary>
        /// <param name="viewModel"> Clasroom object </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The created clasroom </returns>
        public async Task<Response<ClasroomViewModel>> PostRecord
        (
            CreateUpdateClasroomViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postClasroom = await _CRUD.PostRecord(viewModel, "Clasroom", cancellationToken);
            return postClasroom;
        }

        #endregion

        #region Delete a clasroom by id in clasroom table 

        /// <summary>
        ///     Deletes a clasroom by id
        /// </summary>
        /// <param name="id"> Id of the clasroom </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A message telling if the clasroom was deleted or not </returns>

        public async Task<Response<ClasroomViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteClasroom = await _CRUD.DeleteRecord(id, "Clasroom", cancellationToken);
            return deleteClasroom;
        }

        #endregion

        #region Checks of the clasroom exists in clasroom table  

        /// <summary>
        ///     Checks if the clasroom exists or not
        /// </summary>
        /// <param name="id"> Id of the clasroom </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> True or False </returns>

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

        #endregion

    }
}