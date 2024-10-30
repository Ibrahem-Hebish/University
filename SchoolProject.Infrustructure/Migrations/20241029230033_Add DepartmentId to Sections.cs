using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentIdtoSections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Section",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Section_DepartmentId",
                table: "Section",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Department_DepartmentId",
                table: "Section",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_Department_DepartmentId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_DepartmentId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Section");
        }
    }
}
