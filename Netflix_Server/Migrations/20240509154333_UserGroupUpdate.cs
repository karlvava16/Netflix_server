using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netflix_Server.Migrations
{
    /// <inheritdoc />
    public partial class UserGroupUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorImage_Actor_ActorId",
                table: "ActorImage");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieImage_Movies_MovieId",
                table: "MovieImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieImage",
                table: "MovieImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorImage",
                table: "ActorImage");

            migrationBuilder.RenameTable(
                name: "MovieImage",
                newName: "MovieImages");

            migrationBuilder.RenameTable(
                name: "ActorImage",
                newName: "ActorImages");

            migrationBuilder.RenameIndex(
                name: "IX_MovieImage_MovieId",
                table: "MovieImages",
                newName: "IX_MovieImages_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorImage_ActorId",
                table: "ActorImages",
                newName: "IX_ActorImages_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieImages",
                table: "MovieImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorImages",
                table: "ActorImages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PricingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricingPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_PricingPlans_PricingPlanId",
                        column: x => x.PricingPlanId,
                        principalTable: "PricingPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PricingPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_PricingPlans_PricingPlanId",
                        column: x => x.PricingPlanId,
                        principalTable: "PricingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_PricingPlanId",
                table: "Features",
                column: "PricingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PricingPlanId",
                table: "Users",
                column: "PricingPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorImages_Actor_ActorId",
                table: "ActorImages",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieImages_Movies_MovieId",
                table: "MovieImages",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorImages_Actor_ActorId",
                table: "ActorImages");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieImages_Movies_MovieId",
                table: "MovieImages");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PricingPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieImages",
                table: "MovieImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorImages",
                table: "ActorImages");

            migrationBuilder.RenameTable(
                name: "MovieImages",
                newName: "MovieImage");

            migrationBuilder.RenameTable(
                name: "ActorImages",
                newName: "ActorImage");

            migrationBuilder.RenameIndex(
                name: "IX_MovieImages_MovieId",
                table: "MovieImage",
                newName: "IX_MovieImage_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorImages_ActorId",
                table: "ActorImage",
                newName: "IX_ActorImage_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieImage",
                table: "MovieImage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorImage",
                table: "ActorImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorImage_Actor_ActorId",
                table: "ActorImage",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieImage_Movies_MovieId",
                table: "MovieImage",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
