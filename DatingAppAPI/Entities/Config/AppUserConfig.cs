using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatingAppAPI.Entities.Config
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.UserName).HasMaxLength(50).IsRequired();

            builder.Property(p => p.KnownAs).IsRequired();

            builder.Property(p => p.Gender).IsRequired();

            builder.Property(p => p.DateOfBirth).IsRequired();

            builder.Property(p => p.City).IsRequired();

            builder.Property(p => p.Country).IsRequired();

            builder.Property(p => p.PasswordHash).IsRequired();

            builder.Property(p => p.PasswordSalt).IsRequired();

            builder.HasMany(p => p.Photos)
                .WithOne(u => u.AppUser)
                .HasForeignKey(fk => fk.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
