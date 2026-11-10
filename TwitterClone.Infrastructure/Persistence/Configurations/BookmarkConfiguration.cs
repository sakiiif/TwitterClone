using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
    {
        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            builder.ToTable("Bookmarks");

            // Primary Key
            builder.HasKey(b => b.Id);

            // other Properties/columns
            builder.Property(b => b.TweetId)
                .IsRequired();

            builder.Property(b => b.UserId)
                .IsRequired();

            // Foreign Key & relationships

            // 1 tweet can have many bookmarks(Users), but a bookmark belongs to 1 tweet
            builder.HasOne<Tweet>()
                .WithMany()
                .HasForeignKey(b => b.TweetId) // automatically references the 'primary key' of the Tweets table
                .HasConstraintName("fk_bookmarks_tweets")
                .OnDelete(DeleteBehavior.Cascade); // automatic deletion of bookmarks when tweet is deleted


            // 1 user can have many bookmarks(Tweets), but a bookmark belongs to 1 user
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(b => b.UserId) // automatically references the 'primary key' of the Users table
                .HasConstraintName("fk_bookmarks_users")
                .OnDelete(DeleteBehavior.Cascade); // automatic deletion of bookmarks when user is deleted

            // Unique Constraint
            builder.HasIndex(b => new { b.UserId, b.TweetId })
                .IsUnique();
        }
    }
}