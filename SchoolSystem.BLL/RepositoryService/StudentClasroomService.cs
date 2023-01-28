using AutoMapper;
using SchoolSystem.DAL.Models;
using SchoolSystem.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.RepositoryService.CrudService;

namespace SchoolSystem.BLL.RepositoryService
{
    public class StudentClasroomService : ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        private readonly CRUD<StudentClasroomViewModel, StudentClasroom, CreateUpdateStudentClasroomViewModel> _CRUD;

        public StudentClasroomService
        (
            IMapper mapper,
            ApplicationDbContext dbContext,
            CRUD<StudentClasroomViewModel, StudentClasroom, CreateUpdateStudentClasroomViewModel> CRUD
        )
        {
            _CRUD = CRUD;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all exams from studentclasrooms
        /// </summary>
        /// <returns> a list of all studentclasrooms</returns>
        public async Task<Response<List<StudentClasroomViewModel>>> GetRecords
        (
            CancellationToken cancellationToken
        )
        {
            var getAllStudentClasrooms = await _CRUD.GetAll(cancellationToken);
            return getAllStudentClasrooms;
        }

        /// <summary>
        /// Get a single studentclasroom
        /// </summary>
        /// <param name="id"> Id of a studentclasroom</param>
        /// <returns> The object of a specific studentclasroom</returns>
        public async Task<Response<StudentClasroomViewModel>> GetRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var test = await _dbContext.StudentClasrooms.FirstOrDefaultAsync(x => x.StudentId.Equals(id));
            return Response<StudentClasroomViewModel>.Ok(_mapper.Map<StudentClasroomViewModel>(test));
            //var getStudentClasroom = await _CRUD.GetSpecificRecord(id, "Student Clasroom", cancellationToken);
            //return getStudentClasroom;
        }

        /// <summary>
        /// Updates a student clasroom  
        /// </summary>
        /// <param name="id">Id of a student clasroom </param>
        /// <param name="viewModel">Object that holds the new values of student clasroom  </param>
        /// <returns>The updated student clasroom </returns>
        public async Task<Response<StudentClasroomViewModel>> PutRecord
        (
            Guid id,
            CreateUpdateStudentClasroomViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var updateStudentClasroom = await _CRUD.PutRecord(id, viewModel, "Student Clasroom", cancellationToken);
            return updateStudentClasroom;
        }

        /// <summary>
        /// Creates a new student clasroom 
        /// </summary>
        /// <param name="viewModel">student clasroom  object </param>
        /// <returns>The created student clasroom </returns>
        public async Task<Response<StudentClasroomViewModel>> PostRecord
        (
            CreateUpdateStudentClasroomViewModel viewModel,
            CancellationToken cancellationToken
        )
        {
            var postStudentClasroom = await _CRUD.PostRecord(viewModel, "Student Clasroom", cancellationToken);
            return postStudentClasroom;
        }

        /// <summary>
        /// Deletes a student clasroom  
        /// </summary>
        /// <param name="id">Id of the student clasroom </param>
        /// <returns>A message telling if the student clasroom was deleted or not</returns>
        public async Task<Response<StudentClasroomViewModel>> DeleteRecord
        (
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var deleteStudentClasroom = await _CRUD.DeleteRecord(id, "Student Clasroom", cancellationToken);
            return deleteStudentClasroom;
        }
    }
}