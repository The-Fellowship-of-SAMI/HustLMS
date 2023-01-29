using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class EditedLetterAndLetterTemplateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LetterTemplates_Departments_DepartmentId",
                table: "LetterTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateAdditionalField_TemplateAdditionalField_GroupAdditionalFieldId",
                table: "TemplateAdditionalField");

            migrationBuilder.DropIndex(
                name: "IX_TemplateAdditionalField_GroupAdditionalFieldId",
                table: "TemplateAdditionalField");

            migrationBuilder.RenameColumn(
                name: "GroupAdditionalFieldId",
                table: "TemplateAdditionalField",
                newName: "GroupFieldId");

            migrationBuilder.RenameColumn(
                name: "School",
                table: "Students",
                newName: "SchoolId");

            migrationBuilder.AlterColumn<int>(
                name: "FieldType",
                table: "TemplateAdditionalField",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalText",
                table: "TemplateAdditionalField",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Receiver",
                table: "LetterTemplates",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LetterTemplates",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Footer",
                table: "LetterTemplates",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "LetterTemplates",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Departments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ConfirmationTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    LetterTemplateId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    IsOk = table.Column<bool>(type: "INTEGER", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DepartmentNeedToConfirmId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LetterId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmationTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmationTemplate_Departments_DepartmentNeedToConfirmId",
                        column: x => x.DepartmentNeedToConfirmId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConfirmationTemplate_LetterTemplates_LetterTemplateId",
                        column: x => x.LetterTemplateId,
                        principalTable: "LetterTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConfirmationTemplate_Letters_LetterId",
                        column: x => x.LetterId,
                        principalTable: "Letters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationTemplate_DepartmentNeedToConfirmId",
                table: "ConfirmationTemplate",
                column: "DepartmentNeedToConfirmId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationTemplate_LetterId",
                table: "ConfirmationTemplate",
                column: "LetterId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationTemplate_LetterTemplateId",
                table: "ConfirmationTemplate",
                column: "LetterTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_LetterTemplates_Departments_DepartmentId",
                table: "LetterTemplates",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_SchoolId",
                table: "Students",
                column: "SchoolId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LetterTemplates_Departments_DepartmentId",
                table: "LetterTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_SchoolId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ConfirmationTemplate");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AdditionalText",
                table: "TemplateAdditionalField");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "GroupFieldId",
                table: "TemplateAdditionalField",
                newName: "GroupAdditionalFieldId");

            migrationBuilder.RenameColumn(
                name: "SchoolId",
                table: "Students",
                newName: "School");

            migrationBuilder.AlterColumn<string>(
                name: "FieldType",
                table: "TemplateAdditionalField",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Receiver",
                table: "LetterTemplates",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LetterTemplates",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Footer",
                table: "LetterTemplates",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "LetterTemplates",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateAdditionalField_GroupAdditionalFieldId",
                table: "TemplateAdditionalField",
                column: "GroupAdditionalFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_LetterTemplates_Departments_DepartmentId",
                table: "LetterTemplates",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateAdditionalField_TemplateAdditionalField_GroupAdditionalFieldId",
                table: "TemplateAdditionalField",
                column: "GroupAdditionalFieldId",
                principalTable: "TemplateAdditionalField",
                principalColumn: "Id");
        }
    }
}
