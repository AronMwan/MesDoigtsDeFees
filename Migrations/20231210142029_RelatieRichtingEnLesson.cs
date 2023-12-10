using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class RelatieRichtingEnLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trajects");

            migrationBuilder.AddColumn<int>(
                name: "RichtingId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RichtingName",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RichtingId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Richtings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ended = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Richtings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_RichtingId",
                table: "Lessons",
                column: "RichtingId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_RichtingId",
                table: "Groups",
                column: "RichtingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Richtings_RichtingId",
                table: "Groups",
                column: "RichtingId",
                principalTable: "Richtings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Richtings_RichtingId",
                table: "Lessons",
                column: "RichtingId",
                principalTable: "Richtings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Richtings_RichtingId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Richtings_RichtingId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "Richtings");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_RichtingId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Groups_RichtingId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "RichtingId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "RichtingName",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "RichtingId",
                table: "Groups");

            migrationBuilder.CreateTable(
                name: "Trajects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ended = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Started = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trajects", x => x.Id);
                });
        }
    }
}
