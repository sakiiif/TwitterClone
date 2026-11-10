using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.ToTable("Follows");

            // Primary Key
            builder.HasKey(f => f.Id);

            // Properties

            builder.Property(f => f.FollowerId)
                .IsRequired();

            builder.Property(f => f.FollowingId)
                .IsRequired();

            //1 user can be followed by many users, but a follow belongs to 1 following
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(f => f.FollowerId)
                .HasConstraintName("fk_follower_users")
                .OnDelete(DeleteBehavior.Cascade);

            // 1 user can follow many users, but a follow belongs to 1 follower
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(f => f.FollowingId)
                .HasConstraintName("fk_following_users")
                .OnDelete(DeleteBehavior.Cascade);

            // Check Constraint - no self-following (follower_id != following_id)
            builder.ToTable(t => t.HasCheckConstraint(
                "ck_follows_no_self_follow",
                "FollowerId <> FollowingId"
            ));

            // Unique Constraint
            builder.HasIndex(f => new { f.FollowerId, f.FollowingId })
                .IsUnique();
        }
    }
}
