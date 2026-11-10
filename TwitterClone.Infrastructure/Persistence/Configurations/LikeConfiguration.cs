using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes");

            // Primary Key
            builder.HasKey(l => l.Id);

            // Properties

            builder.Property(l => l.TweetId)
                .IsRequired();

            builder.Property(l => l.UserId)
                .IsRequired();

            // 1 tweet can have many likes(by Users), but a like belongs to 1 tweet
            builder.HasOne<Tweet>()
                .WithMany()
                .HasForeignKey(l => l.TweetId)
                .HasConstraintName("fk_likes_tweets")
                .OnDelete(DeleteBehavior.Cascade);

            // 1 user can have many likes(Tweets), but a like belongs to 1 user
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .HasConstraintName("fk_likes_users")
                .OnDelete(DeleteBehavior.Cascade);

            // Unique Constraint
            builder.HasIndex(l => new { l.UserId, l.TweetId })
                .IsUnique();

            // Check Constraint
            builder.ToTable(t => t.HasCheckConstraint(
                "ck_likes_user_tweet",
                "\"UserId\" <> \"TweetId\""
            ));
        }
    }
}
