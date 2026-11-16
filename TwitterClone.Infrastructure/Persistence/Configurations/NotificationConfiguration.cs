using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            // Primary Key
            builder.HasKey(n => n.Id);

            // Properties

            builder.Property(n => n.UserId)
                .IsRequired();

            builder.Property(n => n.Type)
                .IsRequired();

            builder.Property(n => n.IsRead)
                .HasDefaultValue(false)
                .IsRequired();

            // The message is protected, so configure its backing field.
            builder.Property<string>("_message")
                .HasField("_message")
                .HasColumnName("Message")
                .IsRequired();

            // 1 user can have many notifications, but a notification belongs to 1 user
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .HasConstraintName("fk_notifications_users")
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(n => new { n.UserId, n.IsRead });
        }
    }
}
