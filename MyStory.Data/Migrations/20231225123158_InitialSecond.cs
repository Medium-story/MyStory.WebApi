using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStory.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follow_AspNetUsers_FollowerUserId",
                table: "Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_AspNetUsers_FollowingUserId",
                table: "Follow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follow",
                table: "Follow");

            migrationBuilder.RenameTable(
                name: "Follow",
                newName: "Follows");

            migrationBuilder.RenameColumn(
                name: "FollowId",
                table: "Follows",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_FollowingUserId",
                table: "Follows",
                newName: "IX_Follows_FollowingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_FollowerUserId",
                table: "Follows",
                newName: "IX_Follows_FollowerUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follows",
                table: "Follows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowerUserId",
                table: "Follows",
                column: "FollowerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowingUserId",
                table: "Follows",
                column: "FollowingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowerUserId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowingUserId",
                table: "Follows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follows",
                table: "Follows");

            migrationBuilder.RenameTable(
                name: "Follows",
                newName: "Follow");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Follow",
                newName: "FollowId");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_FollowingUserId",
                table: "Follow",
                newName: "IX_Follow_FollowingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_FollowerUserId",
                table: "Follow",
                newName: "IX_Follow_FollowerUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follow",
                table: "Follow",
                column: "FollowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_AspNetUsers_FollowerUserId",
                table: "Follow",
                column: "FollowerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_AspNetUsers_FollowingUserId",
                table: "Follow",
                column: "FollowingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
