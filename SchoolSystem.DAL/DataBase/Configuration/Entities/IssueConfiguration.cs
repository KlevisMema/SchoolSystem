using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.DAL.Models;

namespace SchoolSystem.DAL.DataBase.Configuration.Entities
{
    public class IssueConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.Property(x => x.Status).HasDefaultValue(2).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.TeacherId).IsRequired();
            builder.Property(x => x.StudentId).IsRequired();
        }
    }
}
