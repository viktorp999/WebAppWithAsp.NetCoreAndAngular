using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatingAppAPI.Entities.Config
{
    public class PhotoConfig : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.AppUserId).HasColumnName("UserId");
            builder.HasOne(u => u.AppUser).WithMany(p => p.Photos).HasForeignKey(fk => fk.AppUserId);
        }
    }
}
