using SchoolSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolSystem.DAL.DataBase.Configuration.Entities
{
    public class EamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Type).IsRequired();
        }
    }
}
