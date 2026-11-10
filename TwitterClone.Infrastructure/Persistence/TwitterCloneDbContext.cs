using Microsoft.EntityFrameworkCore;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence
{
    public class TwitterCloneDbContext : DbContext
    {
        public TwitterCloneDbContext(DbContextOptions<TwitterCloneDbContext> options) : base(options)
        {
        }

        // corresponding tables for each entity
        public DbSet<User> Users => Set<User>();
        public DbSet<Tweet> Tweets => Set<Tweet>();
        public DbSet<Bookmark> Bookmarks => Set<Bookmark>();
        public DbSet<Follow> Follows => Set<Follow>();
        public DbSet<Like> Likes => Set<Like>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<Retweet> Retweets => Set<Retweet>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) // runs/called on migration
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TwitterCloneDbContext).Assembly); // apply all configurations from this assembly/project(Infrastructure)

            // required for TPH (Table Per Hierarchy) inheritance mapping for Notification entity and its derived classes
            modelBuilder.Entity<Notification>()
                .HasDiscriminator(n => n.Type)
                .HasValue<CommentNotification>("Comment")
                .HasValue<FriendRequestNotification>("FriendRequest")
                .HasValue<LikeNotification>("Like")
                .HasValue<MentionNotification>("Mention")
                .HasValue<SystemNotification>("System");
        }
    }
}
