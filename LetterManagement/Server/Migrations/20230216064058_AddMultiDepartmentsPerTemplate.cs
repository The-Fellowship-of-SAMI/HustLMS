using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMultiDepartmentsPerTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LetterTemplates_Departments_DepartmentId",
                table: "LetterTemplates");

            migrationBuilder.DropIndex(
                name: "IX_LetterTemplates_DepartmentId",
                table: "LetterTemplates");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "LetterTemplates");

            migrationBuilder.AddColumn<Guid>(
                name: "LetterTemplateId",
                table: "Departments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LetterTemplateId",
                table: "Departments",
                column: "LetterTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_LetterTemplates_LetterTemplateId",
                table: "Departments",
                column: "LetterTemplateId",
                principalTable: "LetterTemplates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_LetterTemplates_LetterTemplateId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_LetterTemplateId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LetterTemplateId",
                table: "Departments");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "LetterTemplates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LetterTemplates_DepartmentId",
                table: "LetterTemplates",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LetterTemplates_Departments_DepartmentId",
                table: "LetterTemplates",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
