using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DAL.DataBase;
using SchoolSystem.DTO.ObjectTransform;
using SchoolSystem.DTO.ViewModels;
using System.Collections.Generic;

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
    }
}