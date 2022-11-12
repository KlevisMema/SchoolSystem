using SchoolSystem.DAL.DataBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolSystem.DAL.DataBase.Configuration.Seeding
{
    public class DatabaseSeeding
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

            var _context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            await _context.Database.EnsureCreatedAsync();
        }
    }
}