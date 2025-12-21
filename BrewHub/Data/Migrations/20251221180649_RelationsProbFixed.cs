using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrewHub.Data.migrations
{
    /// <inheritdoc />
    public partial class RelationsProbFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "postId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "postId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Categories");
        }
    }
}
