using SchoolSystem.DAL.Models;
using Microsoft.Extensions.Logging;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Student;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

namespace SchoolSystem.BLL.RepositoryService
{
    public class StudentService : ICrudService<StudentViewModel, CreateUpdateStudentViewModel>, I_Valid_Id<Student>
    {
        private readonly ILogger<StudentService> _logger;
        private readonly CRUD<StudentViewModel, Student, CreateUpdateStudentViewModel> _CRUD;

        public StudentService
        (
            ILogger<StudentService> logger,
            CRUD<StudentViewModel, Student, CreateUpdateStudentViewModel> CRUD
        )
        {
            _CRUD = CRUD;
            _logger = logger;
        }

        /// <summary>
        /// Get all student from database
        /// </summary>
        /// <returns> a list of all student</returns>
        public async Task<Response<List<StudentViewModel>>> GetRecords
        (
        )
        {
            var getAllStudents = await _CRUD.GetAll();
            return getAllStudents;
        }

        /// <summary>
        /// Get a single student
        /// </summary>
        /// <param name="id"> Id of a student</param>
        /// <returns> The object of a specific student</returns>
        public async Task<Response<StudentViewModel>> GetRecord
        (
            Guid id
        )
        {
            var getStudent = await _CRUD.GetSpecificRecord(id, "Student");
            return getStudent;
        }

        /// <summary>
        /// Creates a new student 
        /// </summary>
        /// <param name="viewModel">Teacher object </param>
        /// <returns>The created student</returns>
        public async Task<Response<StudentViewModel>> PostRecord
        (
            CreateUpdateStudentViewModel viewModel
        )
        {
            var postStudent = await _CRUD.PostRecord(viewModel, "Student");
            return postStudent;
        }

        /// <summary>
        /// Updates a student  
        /// </summary>
        /// <param name="id">Id of a student</param>
        /// <param name="viewModel">Object that holds the new values of student </param>
        /// <returns>The updated student</returns>
        public async Task<Response<StudentViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateStudentViewModel viewModel
        )
        {
            var updateStudent = await _CRUD.PutRecord(id, viewModel, "Student");
            return updateStudent;
        }

        /// <summary>
        /// Deletes a student 
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns>A message telling if the student was deleted or not</returns>
        public async Task<Response<StudentViewModel>> DeleteRecord
        (
            Guid id
        )
        {
            var deleteStudent = await _CRUD.DeleteRecord(id, "Student");
            return deleteStudent;
        }

        /// <summary>
        /// Chkecks if the record exists i database or not
        /// </summary>
        /// <returns>True of false</returns>
        public async Task<bool> Bool
        (
            Guid id
        )
        {
            try
            {
                var getAllStudents = await _CRUD.GetAll();
                var result = getAllStudents.Value;
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