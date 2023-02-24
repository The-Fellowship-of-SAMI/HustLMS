using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedLetterDepartmentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Letters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Letters_DepartmentId",
                table: "Letters",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Letters_Departments_DepartmentId",
                table: "Letters",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letters_Departments_DepartmentId",
                table: "Letters");

            migrationBuilder.DropIndex(
                name: "IX_Letters_DepartmentId",
                table: "Letters");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Letters");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
