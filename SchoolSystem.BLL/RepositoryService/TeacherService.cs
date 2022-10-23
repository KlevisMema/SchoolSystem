using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Teacher;

namespace SchoolSystem.BLL.RepositoryService
{
    public class TeacherService : ITeacherService
    {
        private readonly CRUD<TeacherViewModel, Teacher, CreateTeacherViewModel, UpdateTeacherViewModel> _CRUD;

        public TeacherService(
            CRUD<TeacherViewModel, Teacher, CreateTeacherViewModel, UpdateTeacherViewModel> CRUD)
        {
            _CRUD = CRUD;
        }

        /// <summary>
        /// Get all teachers from database
        /// </summary>
        /// <returns> a list of all teachers</returns>
        public async Task<Response<List<TeacherViewModel>>> GetTeachers()
        {
            var response = await _CRUD.GetAll();
            return response;
        }

        /// <summary>
        /// Get a single teacher
        /// </summary>
        /// <param name="id"> Id of a teacher</param>
        /// <returns> The object of a specific teacher</returns>
        public async Task<Response<TeacherViewModel>> GetTeacher(Guid id)
        {
            var response = await _CRUD.GetSpecificRecord(id, "Teacher");
            return response;
        }

        /// <summary>
        /// Updates a teacher  
        /// </summary>
        /// <param name="id">Id of a teacher</param>
        /// <param name="teacher">Object that holds the new values of teacher </param>
        /// <returns>The updated teacher</returns>
        public async Task<Response<TeacherViewModel>> PutTeacher(Guid id, UpdateTeacherViewModel teacher)
        {
            var response = await _CRUD.PutRecord(id, teacher, "Teacher");
            return response;
        }

        /// <summary>
        /// Creates a new teacher 
        /// </summary>
        /// <param name="teacher">Teacher object </param>
        /// <returns>The created teacher</returns>
        public async Task<Response<TeacherViewModel>> PostTeacher(CreateTeacherViewModel teacher)
        {
            var responsePostMethod = await _CRUD.PostRecord(teacher, "Teacher");
            return responsePostMethod;
        }

        /// <summary>
        /// Deletes a teacher 
        /// </summary>
        /// <param name="id">Id of the teacher</param>
        /// <returns>A message telling if the teacher was deleted or not</returns>
        public async Task<Response<TeacherViewModel>> DeleteTeacher(Guid id)
        {
            var deleteResponse = await _CRUD.DeleteRecord(id, "Teacher");
            return deleteResponse;
        }
    }
}