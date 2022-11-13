using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Teacher;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

namespace SchoolSystem.BLL.RepositoryService
{
    public class TeacherService : ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel>, I_Valid_Id<Teacher>
    {
        private readonly ILogger<TeacherService> _logger;
        private readonly CRUD<TeacherViewModel, Teacher, CreateUpdateTeacherViewModel> _CRUD;

        public TeacherService
        (
            ILogger<TeacherService> logger,
            CRUD<TeacherViewModel, Teacher, CreateUpdateTeacherViewModel> CRUD
        )
        {
            _CRUD = CRUD;
            _logger = logger;
        }

        /// <summary>
        /// Get all teachers from database
        /// </summary>
        /// <returns> a list of all teachers</returns>
        public async Task<Response<List<TeacherViewModel>>> GetRecords
        (
        )
        {
            var getAllTeachers = await _CRUD.GetAll();
            return getAllTeachers;
        }

        /// <summary>
        /// Get a single teacher
        /// </summary>
        /// <param name="id"> Id of a teacher</param>
        /// <returns> The object of a specific teacher</returns>
        public async Task<Response<TeacherViewModel>> GetRecord
        (
            Guid id
        )
        {
            var getTeacher = await _CRUD.GetSpecificRecord(id, "Teacher");
            return getTeacher;
        }

        /// <summary>
        /// Creates a new teacher 
        /// </summary>
        /// <param name="viewModel">Teacher object </param>
        /// <returns>The created teacher</returns>
        public async Task<Response<TeacherViewModel>> PostRecord
        (
            CreateUpdateTeacherViewModel viewModel
        )
        {
            var postTeacher = await _CRUD.PostRecord(viewModel, "Teacher");
            return postTeacher;
        }

        /// <summary>
        /// Updates a teacher  
        /// </summary>
        /// <param name="id">Id of a teacher</param>
        /// <param name="viewModel">Object that holds the new values of teacher </param>
        /// <returns>The updated teacher</returns>
        public async Task<Response<TeacherViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateTeacherViewModel viewModel
        )
        {
            var updateTeacher = await _CRUD.PutRecord(id, viewModel, "Teacher");
            return updateTeacher;
        }

        /// <summary>
        /// Deletes a teacher 
        /// </summary>
        /// <param name="id">Id of the teacher</param>
        /// <returns>A message telling if the teacher was deleted or not</returns>
        public async Task<Response<TeacherViewModel>> DeleteRecord
        (
            Guid id
        )
        {
            var deleteTeacher = await _CRUD.DeleteRecord(id, "Teacher");
            return deleteTeacher;
        }

        /// <summary>
        /// Returns True or false if the teacher exists in database
        /// </summary>
        /// <param name="id">Id of the teacher</param>
        /// <returns>True or false</returns>
        public async Task<bool> Bool
        (
            Guid id
        )
        {
            try
            {
                var getAllTeachers = await _CRUD.GetAll();
                var result = getAllTeachers.Value;
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