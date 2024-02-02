using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatingAppAPI.Entities.Config
{
    public class UserLikeConfig : IEntityTypeConfiguration<UserLike>
    {
        public void Configure(EntityTypeBuilder<UserLike> builder)
        {
            builder.HasKey(k => new { k.SourceUserId, k.TargetUserId });

            builder.HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(fk => fk.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.TargetUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(fk => fk.TargetUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

