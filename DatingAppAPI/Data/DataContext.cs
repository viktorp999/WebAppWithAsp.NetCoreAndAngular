using DatingAppAPI.Entities;
using DatingAppAPI.Entities.Config;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<UserLike> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfig());
            modelBuilder.ApplyConfiguration(new PhotoConfig());
            modelBuilder.ApplyConfiguration(new UserLikeConfig());
            modelBuilder.ApplyConfiguration(new MessageConfig());
        }
    }
}
