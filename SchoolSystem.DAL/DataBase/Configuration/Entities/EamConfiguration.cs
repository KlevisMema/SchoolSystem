using SchoolSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolSystem.DAL.DataBase.Configuration.Entities
{
    public class EamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).HasDefaultValue("").IsRequired();
            builder.Property(x => x.Type).HasDefaultValue(0).IsRequired();
        }
    }
}