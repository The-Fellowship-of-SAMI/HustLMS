using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class EditConfirmationsForMultipleManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinishedConfirmation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ManagerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    FinishedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LetterId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishedConfirmation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinishedConfirmation_Letters_LetterId",
                        column: x => x.LetterId,
                        principalTable: "Letters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinishedConfirmation_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinishedConfirmation_LetterId",
                table: "FinishedConfirmation",
                column: "LetterId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedConfirmation_ManagerId",
                table: "FinishedConfirmation",
                column: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinishedConfirmation");
        }
    }
}
