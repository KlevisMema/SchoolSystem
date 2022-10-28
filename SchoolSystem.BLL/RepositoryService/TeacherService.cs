using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Teacher;

namespace SchoolSystem.BLL.RepositoryService
{
    public class TeacherService : ICrudInterfaces<TeacherViewModel, CreateUpdateTeacherViewModel>
    {
        private readonly CRUD<TeacherViewModel, Teacher, CreateUpdateTeacherViewModel> _CRUD;

        public TeacherService(
            CRUD<TeacherViewModel, Teacher, CreateUpdateTeacherViewModel> CRUD)
        {
            _CRUD = CRUD;
        }

        /// <summary>
        /// Get all teachers from database
        /// </summary>
        /// <returns> a list of all teachers</returns>
        public async Task<Response<List<TeacherViewModel>>> GetRecords()
        {
            var getAllTeachers = await _CRUD.GetAll();
            return getAllTeachers;
        }

        /// <summary>
        /// Get a single teacher
        /// </summary>
        /// <param name="id"> Id of a teacher</param>
        /// <returns> The object of a specific teacher</returns>
        public async Task<Response<TeacherViewModel>> GetRecord(Guid id)
        {
            var getTeacher = await _CRUD.GetSpecificRecord(id, "Teacher");
            return getTeacher;
        }

        /// <summary>
        /// Creates a new teacher 
        /// </summary>
        /// <param name="teacher">Teacher object </param>
        /// <returns>The created teacher</returns>
        public async Task<Response<TeacherViewModel>> PostRecord(CreateUpdateTeacherViewModel viewModel)
        {
            var postTeacher = await _CRUD.PostRecord(viewModel, "Teacher");
            return postTeacher;
        }

        /// <summary>
        /// Updates a teacher  
        /// </summary>
        /// <param name="id">Id of a teacher</param>
        /// <param name="teacher">Object that holds the new values of teacher </param>
        /// <returns>The updated teacher</returns>
        public async Task<Response<TeacherViewModel>> PutRecord(Guid id, CreateUpdateTeacherViewModel examViewModel)
        {
            var updateTeacher = await _CRUD.PutRecord(id, examViewModel, "Teacher");
            return updateTeacher;
        }

        /// <summary>
        /// Deletes a teacher 
        /// </summary>
        /// <param name="id">Id of the teacher</param>
        /// <returns>A message telling if the teacher was deleted or not</returns>
        public async Task<Response<TeacherViewModel>> DeleteRecord(Guid id)
        {
            var deleteTeacher = await _CRUD.DeleteRecord(id, "Teacher");
            return deleteTeacher;
        }
    }
}