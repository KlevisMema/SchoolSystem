using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DAL.DataBase;
using SchoolSystem.DTO.ObjectTransform;
using SchoolSystem.DTO.ViewModels;

namespace SchoolSystem.BLL.RepositoryService
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all students from Students table
        public async Task<Response<List<StudentViewModel>>> GetStudets()
        {
            try
            {
                var students = await _context.Students.ToListAsync();

                if (students is null)
                    return Response<List<StudentViewModel>>.ErrorMsg("Server error.. . . .");

                return Response<List<StudentViewModel>>
                            .Ok(students.Select(objTransform => objTransform.AsStudentViewModel())
                            .ToList());
            }
            catch (Exception ex)
            {
                return Response<List<StudentViewModel>>.ErrorMsg(ex.Message);
            }
        }

        // Get a specific student by id
        public async Task<Response<StudentViewModel>> GetSpecificStudent(Guid id)
        {
            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(x=>x.Id == id);

                if (student is null)
                    return Response<StudentViewModel>.NotFound("Student doesn't exists");

                return Response<StudentViewModel>.Ok(student.AsStudentViewModel());
            }
            catch (Exception ex)
            {
                return Response<StudentViewModel>.ErrorMsg(ex.Message);
            }
        }

        // Create student 
        public async Task<Response<StudentViewModel>> CreateStudent(CreateStudentViewModel newStudent)
        {
            try
            {
                await _context.Students.AddAsync(newStudent.AsStudent());
                await _context.SaveChangesAsync();

                return Response<StudentViewModel>.Ok(newStudent.AsStudent().AsStudentViewModel());
            }
            catch (Exception ex)
            {
                return Response<StudentViewModel>.ErrorMsg(ex.Message);
            }
        }
    }
}