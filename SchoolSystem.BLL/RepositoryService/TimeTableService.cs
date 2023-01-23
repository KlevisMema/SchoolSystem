#region Usings

using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.TimeTable;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

#endregion

namespace SchoolSystem.BLL.RepositoryService
{
    /// <summary>
    ///     Time table service that implements ICrud Service interface,I_Valid_Id interace , and has all buisness logic related to time table 
    /// </summary>
    public class TimeTableService : ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel>, I_Valid_Id<TimeTable>
    {
        #region Services 

        /// <summary>
        ///      A readonly field for logger
        /// </summary>
        private readonly ILogger<TimeTableService> _logger;
        /// <summary>
        ///     A readonly field for database actions -> Create,Update,Delete,Get Actions
        /// </summary>
        private readonly DatabaseActionsService<TimeTableViewModel, TimeTable, CreateUpdateTimeTableViewModel> _CRUD;

        /// <summary>
        ///     Inject services in constructor
        /// </summary>
        /// <param name="CRUD"> CRUD Services </param>
        /// <param name="logger"> Logger Service </param>
        public TimeTableService
        (
            ILogger<TimeTableService> logger,
            DatabaseActionsService<TimeTableViewModel, TimeTable, CreateUpdateTimeTableViewModel> CRUD
        )
        {
            _CRUD = CRUD;
            _logger = logger;
        }

        #endregion

        #region Get all time tables from timetable table 

        /// <summary>
        ///     Get all exams from time tables
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> a list of all time tables </returns>

        public async Task<Response<List<TimeTableViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllTimeTables = await _CRUD.GetAll(cancellationToken);
            return getAllTimeTables;
        }

        #endregion

        #region Get a time table from timetable table

        /// <summary>
        ///     Get a single time table
        /// </summary>
        /// <param name="id"> Id of a time table</param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The object of a specific time table </returns>

        public async Task<Response<TimeTableViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var getTimeTable = await _CRUD.GetSpecificRecord(id, "Time Table", cancellationToken);
            return getTimeTable;
        }

        #endregion

        #region Update a existing time table in timetable table 

        /// <summary>
        ///     Updates a time table  
        /// </summary>
        /// <param name="id"> Id of a time table </param>
        /// <param name="viewModel"> Object that holds the new values of time table </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The updated time table </returns>

        public async Task<Response<TimeTableViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateTimeTableViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updatetTmeTable = await _CRUD.PutRecord(id, viewModel, "Time Table", cancellationToken);
            return updatetTmeTable;
        }

        #endregion

        #region Create a new time table in timetable table 

        /// <summary>
        ///     Creates a new time table 
        /// </summary>
        /// <param name="viewModel"> Time table object </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The created time table </returns>

        public async Task<Response<TimeTableViewModel>> PostRecord
        (
            CreateUpdateTimeTableViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postTimeTable = await _CRUD.PostRecord(viewModel, "Time Table", cancellationToken);
            return postTimeTable;
        }

        #endregion

        #region Delete a time table in timetable table 

        /// <summary>
        ///     Deletes a time table 
        /// </summary>
        /// <param name="id"> Id of the time table </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A message telling if the time table was deleted or not </returns>

        public async Task<Response<TimeTableViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteTimeTable = await _CRUD.DeleteRecord(id, "Time Table", cancellationToken);
            return deleteTimeTable;
        }

        #endregion

        #region Check if the time table exist in database

        /// <summary>
        ///     Returns True or false if the time table exists in database
        /// </summary>
        /// <param name="id"> Id of the TimeTable </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> True or false </returns>

        public async Task<bool> Bool
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var getTimeTables = await _CRUD.GetAll(cancellationToken);
                var result = getTimeTables.Value;
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