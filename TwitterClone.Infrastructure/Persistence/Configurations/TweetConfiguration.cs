using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.ToTable("Tweets");

            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties

            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.Content)
                .IsRequired();

            // 1 user can have many tweets, but a tweet belongs to 1 user
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .HasConstraintName("fk_tweets_users")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
