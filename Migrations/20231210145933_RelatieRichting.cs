using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesDoigtsDeFees.Migrations
{
    /// <inheritdoc />
    public partial class RelatieRichting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Richtings_RichtingId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_RichtingId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "RichtingId",
                table: "Groups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RichtingId",
                table: "Groups",
                type: "int",
                nullable: true);

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
        }
    }
}
