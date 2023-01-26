#region Usings

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace SchoolSystem.DAL.DataBase.Configuration.Seeding
{
    /// <summary>
    ///     Seed the database
    /// </summary>
    public class DatabaseSeeding
    {
        /// <summary>
        ///     Create the database if it doesn't exists
        /// </summary>
        /// <param name="applicationBuilder"> Application builder </param>
        /// <returns> Nothing </returns>
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

            var _context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            await _context!.Database.EnsureCreatedAsync();
        }
    }
}