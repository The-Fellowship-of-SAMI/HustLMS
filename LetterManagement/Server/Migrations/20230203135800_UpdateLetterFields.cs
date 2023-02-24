using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLetterFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateAdditionalField_Letters_LetterId",
                table: "TemplateAdditionalField");

            migrationBuilder.DropIndex(
                name: "IX_TemplateAdditionalField_LetterId",
                table: "TemplateAdditionalField");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "TemplateAdditionalField");

            migrationBuilder.DropColumn(
                name: "FieldValue",
                table: "TemplateAdditionalField");

            migrationBuilder.DropColumn(
                name: "LetterId",
                table: "TemplateAdditionalField");

            migrationBuilder.CreateTable(
                name: "LetterAdditionalField",
                columns: table => new
                {
                    LetterAdditionalFieldId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LetterTemplateAdditionalFieldId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FieldValueString = table.Column<string>(type: "TEXT", nullable: true),
                    FieldValueBool = table.Column<bool>(type: "INTEGER", nullable: true),
                    FieldValueDateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LetterId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterAdditionalField", x => x.LetterAdditionalFieldId);
                    table.ForeignKey(
                        name: "FK_LetterAdditionalField_Letters_LetterId",
                        column: x => x.LetterId,
                        principalTable: "Letters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LetterAdditionalField_LetterId",
                table: "LetterAdditionalField",
                column: "LetterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LetterAdditionalField");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "TemplateAdditionalField",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FieldValue",
                table: "TemplateAdditionalField",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LetterId",
                table: "TemplateAdditionalField",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateAdditionalField_LetterId",
                table: "TemplateAdditionalField",
                column: "LetterId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateAdditionalField_Letters_LetterId",
                table: "TemplateAdditionalField",
                column: "LetterId",
                principalTable: "Letters",
                principalColumn: "Id");
        }
    }
}
