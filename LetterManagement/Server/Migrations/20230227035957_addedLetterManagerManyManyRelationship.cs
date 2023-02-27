using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class addedLetterManagerManyManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Letters_LetterId",
                table: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Manager_LetterId",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "LetterId",
                table: "Manager");

            migrationBuilder.CreateTable(
                name: "LetterManager",
                columns: table => new
                {
                    LettersId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ManagersId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterManager", x => new { x.LettersId, x.ManagersId });
                    table.ForeignKey(
                        name: "FK_LetterManager_Letters_LettersId",
                        column: x => x.LettersId,
                        principalTable: "Letters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LetterManager_Manager_ManagersId",
                        column: x => x.ManagersId,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LetterManager_ManagersId",
                table: "LetterManager",
                column: "ManagersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LetterManager");

            migrationBuilder.AddColumn<Guid>(
                name: "LetterId",
                table: "Manager",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manager_LetterId",
                table: "Manager",
                column: "LetterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Letters_LetterId",
                table: "Manager",
                column: "LetterId",
                principalTable: "Letters",
                principalColumn: "Id");
        }
    }
}
