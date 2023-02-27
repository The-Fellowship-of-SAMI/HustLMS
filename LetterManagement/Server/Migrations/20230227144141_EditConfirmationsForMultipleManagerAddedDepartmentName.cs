using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class EditConfirmationsForMultipleManagerAddedDepartmentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "FinishedConfirmation",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "FinishedConfirmation");
        }
    }
}
