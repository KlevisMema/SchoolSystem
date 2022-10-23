using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SchoolSystem.API.ControllerRespose;
using SchoolSystem.BLL.RepositoryService;
using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.DAL.DataBase;
using SchoolSystem.DTO.Mappings;
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

            //services.AddAutoMapper(typeof(MappingsTeacher));

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingsTeacher());
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient(typeof(StatusCodeResponse<>));
            services.AddTransient(typeof(CRUD<,,,>));

            return services;
        }
    }
}