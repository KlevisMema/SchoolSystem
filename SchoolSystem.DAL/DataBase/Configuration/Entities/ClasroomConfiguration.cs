using SchoolSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolSystem.DAL.DataBase.Configuration.Entities
{
    public class ClasroomConfiguration : IEntityTypeConfiguration<Clasroom>
    {
        public void Configure(EntityTypeBuilder<Clasroom> builder)
        {
            builder.Property(x => x.Grade).IsRequired();
            builder.Property(x => x.TeacherId).IsRequired();
            builder.Property(x => x.TimeTableId).IsRequired();
        }
    }
}