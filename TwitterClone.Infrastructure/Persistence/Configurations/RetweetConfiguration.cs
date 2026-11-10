using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class RetweetConfiguration : IEntityTypeConfiguration<Retweet>
    {
        public void Configure(EntityTypeBuilder<Retweet> builder)
        {
            builder.ToTable("Retweets");

            // Primary Key
            builder.HasKey(r => r.Id);

            // Properties

            builder.Property(r => r.TweetId)
                .IsRequired();

            builder.Property(r => r.UserId)
                .IsRequired();

            builder.Property(r => r.Comment)
                .HasMaxLength(100);
                 // .IsRequired(false); // reduntant as Comment is nullable in the entity class

            // 1 tweet can have many retweets(by Users), but a retweet belongs to 1 tweet 
            builder.HasOne<Tweet>()
                .WithMany()
                .HasForeignKey(r => r.TweetId)
                .HasConstraintName("fk_retweets_tweets")
                .OnDelete(DeleteBehavior.Cascade);

            // 1 user can have many retweets(Tweets), but a retweet belongs to 1 user
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .HasConstraintName("fk_retweets_users")
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(r => r.TweetId);

            builder.HasIndex(r => r.UserId);
        }
    }
}
