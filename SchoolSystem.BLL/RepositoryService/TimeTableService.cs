using SchoolSystem.DAL.Models;
using SchoolSystem.DAL.DataBase;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.TimeTable;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

namespace SchoolSystem.BLL.RepositoryService
{
    public class TimeTableService : ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel>, I_Valid_Id<TimeTable>
    {
        private readonly ILogger<TimeTableService> _logger;
        private readonly CRUD<TimeTableViewModel, TimeTable, CreateUpdateTimeTableViewModel> _CRUD;

        public TimeTableService
        (
            ILogger<TimeTableService> logger,
            CRUD<TimeTableViewModel, TimeTable, CreateUpdateTimeTableViewModel> CRUD
        )
        {
            _CRUD = CRUD;
            _logger = logger;
        }

        /// <summary>
        /// Get all exams from time tables
        /// </summary>
        /// <returns> a list of all time tables</returns>
        public async Task<Response<List<TimeTableViewModel>>> GetRecords
        (
        )
        {
            var getAllTimeTables = await _CRUD.GetAll();
            return getAllTimeTables;
        }

        /// <summary>
        /// Get a single time table
        /// </summary>
        /// <param name="id"> Id of a time table</param>
        /// <returns> The object of a specific time table</returns>
        public async Task<Response<TimeTableViewModel>> GetRecord
        (
            Guid id
        )
        {
            var getTimeTable = await _CRUD.GetSpecificRecord(id, "Time Table");
            return getTimeTable;
        }

        /// <summary>
        /// Updates a time table  
        /// </summary>
        /// <param name="id">Id of a time table</param>
        /// <param name="viewModel">Object that holds the new values of time table </param>
        /// <returns>The updated time table</returns>
        public async Task<Response<TimeTableViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateTimeTableViewModel viewModel
        )
        {
            var updatetTmeTable = await _CRUD.PutRecord(id, viewModel, "Time Table");
            return updatetTmeTable;
        }

        /// <summary>
        /// Creates a new time table 
        /// </summary>
        /// <param name="viewModel">time table object </param>
        /// <returns>The created time table</returns>
        public async Task<Response<TimeTableViewModel>> PostRecord
        (
            CreateUpdateTimeTableViewModel viewModel
        )
        {
            var postTimeTable = await _CRUD.PostRecord(viewModel, "Time Table");
            return postTimeTable;
        }

        /// <summary>
        /// Deletes a time table 
        /// </summary>
        /// <param name="id">Id of the time table</param>
        /// <returns>A message telling if the time table was deleted or not</returns>
        public async Task<Response<TimeTableViewModel>> DeleteRecord
        (
            Guid id
        )
        {
            var deleteTimeTable = await _CRUD.DeleteRecord(id, "Time Table");
            return deleteTimeTable;
        }

        /// <summary>
        /// Returns True or false if the time table exists in database
        /// </summary>
        /// <param name="id">Id of the TimeTable</param>
        /// <returns>True or false</returns>
        public async Task<bool> Bool
        (
            Guid id
        )
        {
            try
            {
                var getTimeTables = await _CRUD.GetAll();
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
    }
}