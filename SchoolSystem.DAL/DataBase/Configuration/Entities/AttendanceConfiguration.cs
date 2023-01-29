using SchoolSystem.DAL.Enums;
using SchoolSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolSystem.DAL.DataBase.Configuration.Entities
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.Property(x => x.Status).HasDefaultValue(Status.Missing).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.TeacherId).IsRequired();
            builder.Property(x => x.StudentId).IsRequired();
        }
    }
}