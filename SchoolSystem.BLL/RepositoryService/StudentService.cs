using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Student;

namespace SchoolSystem.BLL.RepositoryService
{
    public class StudentService : IStudentService
    {
        private readonly ICRUD<StudentViewModel, Student, CreateStudentViewModel, UpdateStudentViewModel> _CRUD;

        public StudentService(
            ICRUD<StudentViewModel, Student, CreateStudentViewModel, UpdateStudentViewModel> CRUD)
        {
            _CRUD = CRUD;
        }

        /// <summary>
        /// Get all student from database
        /// </summary>
        /// <returns> a list of all student</returns>
        public async Task<Response<List<StudentViewModel>>> GetStudets()
        {
            var getAllStudents = await _CRUD.GetAll();
            return getAllStudents;
        }

        /// <summary>
        /// Get a single student
        /// </summary>
        /// <param name="id"> Id of a student</param>
        /// <returns> The object of a specific student</returns>
        public async Task<Response<StudentViewModel>> GetSpecificStudent(Guid id)
        {
            var getStudent = await _CRUD.GetSpecificRecord(id, "Student");
            return getStudent;
        }

        /// <summary>
        /// Creates a new student 
        /// </summary>
        /// <param name="teacher">Teacher object </param>
        /// <returns>The created student</returns>
        public async Task<Response<StudentViewModel>> CreateStudent(CreateStudentViewModel newStudent)
        {
            var createNewStudent = await _CRUD.PostRecord(newStudent, "Student");
            return createNewStudent;
        }

        /// <summary>
        /// Updates a student  
        /// </summary>
        /// <param name="id">Id of a student</param>
        /// <param name="teacher">Object that holds the new values of student </param>
        /// <returns>The updated student</returns>
        public async Task<Response<StudentViewModel>> PutStudent(Guid id, UpdateStudentViewModel student)
        {
            var updateStudent = await _CRUD.PutRecord(id, student, "Student");
            return updateStudent;
        }

        /// <summary>
        /// Deletes a student 
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns>A message telling if the student was deleted or not</returns>
        public async Task<Response<StudentViewModel>> DeleteStudent(Guid id)
        {
            var deleteStudent = await _CRUD.DeleteRecord(id, "Student");
            return deleteStudent;
        }
    }
}