using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using TaskSystem.Models;

namespace TaskSystem.Data
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
