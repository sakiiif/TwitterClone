using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            // Primary Key
            builder.HasKey(m => m.Id);

            // Properties

            builder.Property(m => m.SenderId)
                .IsRequired();

            builder.Property(m => m.ReceiverId)
                .IsRequired();

            builder.Property(m => m.Content)
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(m => m.IsRead)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(m => m.SentAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            // 1 user can send many messages(To same or different users), but a message belongs to 1 sender
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .HasConstraintName("fk_senders_users")
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion of sender if they have sent messages
                // .ondelete(DeleteBehavior.SetNull); // Set sender to null if they are deleted, lost the user identity though
                                                   // or soft delete by adding a IsDeleted property to the User entity
                                                   // and filtering out deleted users in queries

            // 1 user can receive many messages(From same or different users), but a message belongs to 1 receiver
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .HasConstraintName("fk_receivers_users")
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion of receiver if they have received messages

            // Check Constraint
            builder.ToTable(t => t.HasCheckConstraint(
                "ck_messages_sender_receiver",
                "\"SenderId\" <> \"ReceiverId\""
            ));

            // Indexes
            builder.HasIndex(m => new
            {
                m.SenderId,
                m.ReceiverId,
                m.SentAt
            });
        }
    }
}
