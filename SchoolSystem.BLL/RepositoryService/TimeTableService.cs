using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DAL.DataBase;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.TimeTable;

namespace SchoolSystem.BLL.RepositoryService
{
    public class TimeTableService : ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel>,
                                    I_Valid_Id<TimeTable>
    {
        private readonly CRUD<TimeTableViewModel, TimeTable, CreateUpdateTimeTableViewModel> _CRUD;
        private readonly ApplicationDbContext _context;

        public TimeTableService
        (
            CRUD<TimeTableViewModel, TimeTable, CreateUpdateTimeTableViewModel> CRUD,
            ApplicationDbContext context
        )
        {
            _CRUD = CRUD;
            _context = context;
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
                var test = await _context.TimeTables.AnyAsync(x => x.Id.Equals(id));
                return test;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}