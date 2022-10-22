using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DAL.DataBase;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ObjectTransform;
using SchoolSystem.DTO.ViewModels.Teacher;

namespace SchoolSystem.BLL.RepositoryService
{
    public class TeacherService : ITeacherService
    {
        //private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public TeacherService(ApplicationDbContext context/*, IMapper mapper*/)
        {
            _context = context;
            //_mapper = mapper;
        }

        public async Task<Response<IEnumerable<TeacherViewModel>>> GetTeachers()
        {
            try
            {
                List<Teacher> teachers = await _context.Teachers.ToListAsync();
                return Response<IEnumerable<TeacherViewModel>>.Ok(teachers.Select(x => x.AsTeacherViewModel()));
            }
            catch (Exception)
            {
                return Response<IEnumerable<TeacherViewModel>>.ErrorMsg("Server error, try again !!");
            }
        }

        public async Task<Response<TeacherViewModel>> GetTeacher(Guid id)
        {
            try
            {
                var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);

                ArgumentNullException.ThrowIfNull(teacher);

                return Response<TeacherViewModel>.Ok(teacher.AsTeacherViewModel());
            }
            catch (ArgumentNullException)
            {
                return Response<TeacherViewModel>.NotFound("Teacher doesn't exists");
            }
            catch (Exception)
            {
                return Response<TeacherViewModel>.ErrorMsg("Server error, try again !!");
            }
        }

        public async Task<Response<TeacherViewModel>> PutTeacher(Guid id, UpdateTeacherViewModel teacher)
        {
            var _teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);

            ArgumentNullException.ThrowIfNull(_teacher);

            //_context.Entry(_teacher).State = EntityState.Modified;

            _context.Entry(_teacher).CurrentValues.SetValues(teacher);

            try
            {
                await _context.SaveChangesAsync();

                return await GetTeacher(id);
            }
            catch (ArgumentNullException)
            {
                return Response<TeacherViewModel>.NotFound("Teacher doesnt exists");
            }
            catch (Exception)
            {
                return Response<TeacherViewModel>.ErrorMsg("Server error, couldn't update record, try again!!");
            }
        }

        public async Task<Response<TeacherViewModel>> PostTeacher(CreateTeacherViewModel teacher)
        {
            try
            {
                //var teacherTransformObj = _mapper.Map<Teacher>(teacher);

                _context.Teachers.Add(teacher.AsTeacherModel());

                await _context.SaveChangesAsync();

                return Response<TeacherViewModel>.SuccessMessage("Teacher created succsessuflly");
            }
            catch (Exception)
            {
                return Response<TeacherViewModel>.ErrorMsg("Server error, teacher wasn't created succsessuflly try again!!");
            }
        }

        public async Task<Response<TeacherViewModel>> DeleteTeacher(Guid id)
        {
            try
            {
                var teacher = await _context.Teachers.FirstOrDefaultAsync(x=>x.Id == id);

                 ArgumentNullException.ThrowIfNull(teacher);

                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();

                return Response<TeacherViewModel>.SuccessMessage("Teacher deleted successfully...");
            }
            catch (ArgumentNullException)
            {
                return Response<TeacherViewModel>.NotFound("Teacher doesn't exists");
            }
            catch (Exception)
            {
                return Response<TeacherViewModel>.ErrorMsg("Server error, could't delte try again!");
            }
        }
    }
}