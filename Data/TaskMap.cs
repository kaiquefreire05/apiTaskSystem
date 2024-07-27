using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSystem.Models;

namespace TaskSystem.Data
{
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Desc).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
