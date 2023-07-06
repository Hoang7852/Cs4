using Asm_Ph21208.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace _3_Asp.Net_MVC.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p=>p.Username).IsRequired().
                HasColumnType("varchar(256)");
            builder.Property(p => p.Username).IsRequired().
                HasColumnType("varchar(256)");
            //builder.HasOne(p => p.Roles).WithOne();

        }
    }
}
