using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterClone.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MakePhoneNumberOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_messages_sender_receiver",
                table: "Messages");

            migrationBuilder.DropCheckConstraint(
                name: "ck_likes_user_tweet",
                table: "Likes");

            migrationBuilder.DropCheckConstraint(
                name: "ck_follows_no_self_follow",
                table: "Follows");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddCheckConstraint(
                name: "ck_messages_sender_receiver",
                table: "Messages",
                sql: "\"SenderId\" <> \"ReceiverId\"");

            migrationBuilder.AddCheckConstraint(
                name: "ck_likes_user_tweet",
                table: "Likes",
                sql: "\"UserId\" <> \"TweetId\"");

            migrationBuilder.AddCheckConstraint(
                name: "ck_follows_no_self_follow",
                table: "Follows",
                sql: "\"FollowerId\" <> \"FollowingId\"");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_messages_sender_receiver",
                table: "Messages");

            migrationBuilder.DropCheckConstraint(
                name: "ck_likes_user_tweet",
                table: "Likes");

            migrationBuilder.DropCheckConstraint(
                name: "ck_follows_no_self_follow",
                table: "Follows");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "ck_messages_sender_receiver",
                table: "Messages",
                sql: "SenderId <> ReceiverId");

            migrationBuilder.AddCheckConstraint(
                name: "ck_likes_user_tweet",
                table: "Likes",
                sql: "UserId <> TweetId");

            migrationBuilder.AddCheckConstraint(
                name: "ck_follows_no_self_follow",
                table: "Follows",
                sql: "FollowerId <> FollowingId");
        }
    }
}
