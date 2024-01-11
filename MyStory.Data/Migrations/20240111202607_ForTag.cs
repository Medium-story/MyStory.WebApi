using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStory.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tags_TagId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TagId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "TagUser",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagUser", x => new { x.TagsId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TagUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagUser_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagUser_UserId",
                table: "TagUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagUser");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TagId",
                table: "AspNetUsers",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tags_TagId",
                table: "AspNetUsers",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}
