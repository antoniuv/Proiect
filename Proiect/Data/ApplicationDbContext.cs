using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserChannel> UserChannels { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Request> Requests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // definirea relatiei many-to-many dintre Article si Bookmark

            base.OnModelCreating(modelBuilder);

            // definire primary key compus
            modelBuilder.Entity<UserChannel>()
                .HasKey(ab => new { ab.Id, ab.UserId, ab.ChannelId });


            // definire relatii cu modelele Bookmark si Article (FK)

            modelBuilder.Entity<UserChannel>()
                .HasOne(ab => ab.User)
                .WithMany(ab => ab.UserChannels)
                .HasForeignKey(ab => ab.UserId);

            modelBuilder.Entity<UserChannel>()
                .HasOne(ab => ab.Channel)
                .WithMany(ab => ab.UserChannels)
                .HasForeignKey(ab => ab.ChannelId);





            modelBuilder.Entity<Moderator>()
                .HasKey(ab => new { ab.Id, ab.UserId, ab.ChannelId });


            // definire relatii cu modelele Bookmark si Article (FK)

            modelBuilder.Entity<Moderator>()
                .HasOne(ab => ab.User)
                .WithMany(ab => ab.Moderators)
                .HasForeignKey(ab => ab.UserId);

            modelBuilder.Entity<Moderator>()
                .HasOne(ab => ab.Channel)
                .WithMany(ab => ab.Moderators)
                .HasForeignKey(ab => ab.ChannelId);





            modelBuilder.Entity<Request>()
                .HasKey(ab => new { ab.Id, ab.UserId, ab.ChannelId });


            // definire relatii cu modelele Bookmark si Article (FK)

            modelBuilder.Entity<Request>()
                .HasOne(ab => ab.User)
                .WithMany(ab => ab.Requests)
                .HasForeignKey(ab => ab.UserId);

            modelBuilder.Entity<Request>()
                .HasOne(ab => ab.Channel)
                .WithMany(ab => ab.Requests)
                .HasForeignKey(ab => ab.ChannelId);
        }
    }
}
