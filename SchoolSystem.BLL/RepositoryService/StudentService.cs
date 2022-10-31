using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DAL.DataBase;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Student;

namespace SchoolSystem.BLL.RepositoryService
{
    public class StudentService : ICrudService<StudentViewModel, CreateUpdateStudentViewModel>, I_Valid_Id<Student>
    {
        private readonly CRUD<StudentViewModel, Student, CreateUpdateStudentViewModel> _CRUD;
        private readonly ApplicationDbContext _context;

        public StudentService(
            CRUD<StudentViewModel, Student, CreateUpdateStudentViewModel> CRUD, ApplicationDbContext context)
        {
            _CRUD = CRUD;
            _context = context;
        }

        /// <summary>
        /// Get all student from database
        /// </summary>
        /// <returns> a list of all student</returns>
        public async Task<Response<List<StudentViewModel>>> GetRecords()
        {
            var getAllStudents = await _CRUD.GetAll();
            return getAllStudents;
        }

        /// <summary>
        /// Get a single student
        /// </summary>
        /// <param name="id"> Id of a student</param>
        /// <returns> The object of a specific student</returns>
        public async Task<Response<StudentViewModel>> GetRecord(Guid id)
        {
            var getStudent = await _CRUD.GetSpecificRecord(id, "Student");
            return getStudent;
        }

        /// <summary>
        /// Creates a new student 
        /// </summary>
        /// <param name="viewModel">Teacher object </param>
        /// <returns>The created student</returns>
        public async Task<Response<StudentViewModel>> PostRecord(CreateUpdateStudentViewModel viewModel)
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
        public async Task<Response<StudentViewModel>> PutRecord(Guid id, CreateUpdateStudentViewModel viewModel)
        {
            var updateStudent = await _CRUD.PutRecord(id, viewModel, "Student");
            return updateStudent;
        }

        /// <summary>
        /// Deletes a student 
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns>A message telling if the student was deleted or not</returns>
        public async Task<Response<StudentViewModel>> DeleteRecord(Guid id)
        {
            var deleteStudent = await _CRUD.DeleteRecord(id, "Student");
            return deleteStudent;
        }

        public async Task<bool> Bool(Guid id)
        {
            return await _context.Students.AnyAsync(x=>x.Id.Equals(id));
        }
    }
}