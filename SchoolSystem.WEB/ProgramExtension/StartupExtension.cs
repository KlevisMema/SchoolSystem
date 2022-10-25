using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.RepositoryService;
using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.DAL.DataBase;
using SchoolSystem.DTO.FluentValidation.Exam;
using SchoolSystem.DTO.FluentValidation.Student;
using SchoolSystem.DTO.FluentValidation.Teacher;
using SchoolSystem.DTO.Mappings;
using SchoolSystem.DTO.ViewModels.Exam;
using SchoolSystem.DTO.ViewModels.Student;
using SchoolSystem.DTO.ViewModels.Teacher;
using System.Reflection;

namespace SchoolSystem.API.ProgramExtension
{
    /// <summary>
    /// Startup class to register/configure other services
    /// </summary>
    public static class StartupExtension
    {
        /// <summary>
        /// Extension method of ServiceCollection 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection InjectServices(this IServiceCollection services, IConfiguration configuration)
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
            services.AddAutoMapper(typeof(MappingsTeacher));
            services.AddAutoMapper(typeof(MappingsStudent));
            services.AddAutoMapper(typeof(MappingsExam));

            // Database registration
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            // Services registration
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IExamService, ExamService>();

            // Generic serivces registration
            services.AddTransient(typeof(StatusCodeResponse<,>));
            services.AddTransient(typeof(ICRUD<,,>), typeof(CRUD<,,>));

            // FluentValidation services registration
            services.AddScoped<IValidator<CreateUpdateTeacherViewModel>, CreateTeacherViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateStudentViewModel>, CreateUpdateStudentViewModelValidation>();
            services.AddScoped<IValidator<CreateUpdateExamViewModel>, CreateUpdateExamViewModelValidation>();

            return services;
        }
    }
}