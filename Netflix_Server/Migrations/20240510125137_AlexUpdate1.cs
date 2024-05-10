using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netflix_Server.Migrations
{
    /// <inheritdoc />
    public partial class AlexUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserId",
                table: "Movies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_UserId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Movies");
        }
    }
}
