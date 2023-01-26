#region Usings

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

#endregion

namespace SchoolSystem.DAL.DataBase.Configuration.Entities
{
    /// <summary>
    ///     Configure roles by adding new roles if theres no roles in the table
    /// </summary>
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData
            (
                new IdentityRole
                {
                    Name = "Teacher",
                    NormalizedName = "TEACHER",
                },
                new IdentityRole
                {
                    Name = "Student",
                    NormalizedName = "Student",
                }
            );
        }
    }
}