using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationshipDepartmentAndTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "FieldType",
                table: "TemplateAdditionalField",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentLetterTemplate",
                columns: table => new
                {
                    DepartmentsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LetterTemplatesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLetterTemplate", x => new { x.DepartmentsId, x.LetterTemplatesId });
                    table.ForeignKey(
                        name: "FK_DepartmentLetterTemplate_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentLetterTemplate_LetterTemplates_LetterTemplatesId",
                        column: x => x.LetterTemplatesId,
                        principalTable: "LetterTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLetterTemplate_LetterTemplatesId",
                table: "DepartmentLetterTemplate",
                column: "LetterTemplatesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLetterTemplate");

            migrationBuilder.AlterColumn<int>(
                name: "FieldType",
                table: "TemplateAdditionalField",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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
    }
}
