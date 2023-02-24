using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class Change1ManagerToManyManagersPerLetter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letters_Manager_ManagerId",
                table: "Letters");

            migrationBuilder.DropIndex(
                name: "IX_Letters_ManagerId",
                table: "Letters");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Letters");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Letters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Letters_ManagerId",
                table: "Letters",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Letters_Manager_ManagerId",
                table: "Letters",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id");
        }
    }
}
