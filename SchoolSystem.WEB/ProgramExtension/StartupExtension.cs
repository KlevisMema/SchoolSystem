using FluentValidation;
using System.Reflection;
using SchoolSystem.DAL.Models;
using Microsoft.OpenApi.Models;
using SchoolSystem.DAL.DataBase;
using SchoolSystem.DTO.Mappings;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DTO.ViewModels.Exam;
using SchoolSystem.DTO.ViewModels.Issue;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.RepositoryService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Result;
using SchoolSystem.DTO.ViewModels.Student;
using SchoolSystem.DTO.ViewModels.Subject;
using SchoolSystem.DTO.ViewModels.Teacher;
using SchoolSystem.DTO.ViewModels.Clasroom;
using SchoolSystem.DTO.ViewModels.TimeTable;
using SchoolSystem.DTO.FluentValidation.Exam;
using SchoolSystem.DTO.ViewModels.Attendance;
using SchoolSystem.DTO.FluentValidation.Issue;
using SchoolSystem.DTO.FluentValidation.Result;
using SchoolSystem.DTO.FluentValidation.Student;
using SchoolSystem.DTO.FluentValidation.Subject;
using SchoolSystem.DTO.FluentValidation.Teacher;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.DTO.FluentValidation.Clasroom;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.DTO.FluentValidation.TimeTable;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.DTO.FluentValidation.Attendance;
using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.DTO.FluentValidation.StudentIssue;
using SchoolSystem.DTO.FluentValidation.StudentClasroom;

namespace SchoolSystem.API.ProgramExtension
{
    /// <summary>
    ///     Startup class to register/configure other services
    /// </summary>
    public static class StartupExtension
    {
        /// <summary>
        ///     Extension method of ServiceCollection 
        /// </summary>
        /// <returns>
        ///     All connfigured services 
        /// </returns>
        public static IServiceCollection InjectServices
        (
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            // Swagger configuration
            services.AddSwaggerGen(optios =>
            {
                optios.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "School System API",
                    License = new OpenApiLicense
                    {
                        Name = "Web Api created by Klevis Mema",
                        Url = new Uri("https://www.linkedin.com/in/klevis-m-ab1b3b140/")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                optios.IncludeXmlComments(xmlPath);
            });

            // AutoMapper service registration
            services.AddAutoMapper(typeof(MappingsExam));
            services.AddAutoMapper(typeof(MappingsIssue));
            services.AddAutoMapper(typeof(MappingsResult));
            services.AddAutoMapper(typeof(MappingsTeacher));
            services.AddAutoMapper(typeof(MappingsStudent));
            services.AddAutoMapper(typeof(MappingsSubject));
            services.AddAutoMapper(typeof(MappingsClasroom));
            services.AddAutoMapper(typeof(MappingsTimeTable));
            services.AddAutoMapper(typeof(MappingsAttendance));
            services.AddAutoMapper(typeof(MappingsStudentIssue));
            services.AddAutoMapper(typeof(MappingsStudentClasroom));

            // Database registration
            services.AddDbContext<ApplicationDbContext>
            (
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            // Services registration
            services.AddTransient<IExists, ResultService>();

            services.AddTransient<I_Valid_Id<Teacher>, TeacherService>();
            services.AddTransient<I_Valid_Id<Student>, StudentService>();
            services.AddTransient<I_Valid_Id<TimeTable>, TimeTableService>();

            services.AddTransient<ICrudService<ExamViewModel, CreateUpdateExamViewModel>, ExamService>();
            services.AddTransient<ICrudService<IssueViewModel, CreateUpdateIssueViewModel>, IssueService>();
            services.AddTransient<ICrudService<ResultViewModel, CreateUpdateResultViewModel>, ResultService>();
            services.AddTransient<ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel>, TeacherService>();
            services.AddTransient<ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel>, SubjectService>();
            services.AddTransient<ICrudService<StudentViewModel, CreateUpdateStudentViewModel>, StudentService>();
            services.AddTransient<ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel>, ClasroomService>();
            services.AddTransient<ICrudService<TimeTableViewModel, CreateUpdateTimeTableViewModel>, TimeTableService>();
            services.AddTransient<ICrudService<AttendanceViewModel, CreateUpdateAttendanceViewModel>, AttendanceService>();
            services.AddTransient<ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel>, StudentClasroomService>();
            services.AddTransient<ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel>, StudentIssueService>();

            // Generic serivces registration
            services.AddTransient(typeof(CRUD<,,>));
            services.AddTransient(typeof(StatusCodeResponse<,>));

            // FluentValidation services registration
            services.AddScoped<IValidator<CreateUpdateExamViewModel>, CreateUpdateExamViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateIssueViewModel>, CreateUpdateIssueViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateResultViewModel>, CreateUpdateResultViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateTeacherViewModel>, CreateUpdateTeacherViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateStudentViewModel>, CreateUpdateStudentViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateSubjectViewModel>, CreateUpdateSubjectViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateClasroomViewModel>, CreateUpdateClasroomViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateTimeTableViewModel>, CreateUpdateTimeTableViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateAttendanceViewModel>, CreateUpdateAttendanceViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateStudentClasroomViewModel>, CreateUpdateStudentClasroomViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateStudentIssueViewModel>, CreateUpdateStudentIssueViewModelValidation>();

            return services;
        }
    }
}