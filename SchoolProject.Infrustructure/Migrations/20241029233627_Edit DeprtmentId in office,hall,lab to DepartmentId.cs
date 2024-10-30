using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class EditDeprtmentIdinofficehalllabtoDepartmentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Department_DeprtmentId",
                table: "Hall");

            migrationBuilder.DropForeignKey(
                name: "FK_Lab_Department_DeprtmentId",
                table: "Lab");

            migrationBuilder.DropForeignKey(
                name: "FK_Office_Department_DeprtmentId",
                table: "Office");

            migrationBuilder.RenameColumn(
                name: "DeprtmentId",
                table: "Office",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Office_DeprtmentId",
                table: "Office",
                newName: "IX_Office_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "DeprtmentId",
                table: "Lab",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Lab_DeprtmentId",
                table: "Lab",
                newName: "IX_Lab_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "DeprtmentId",
                table: "Hall",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Hall_DeprtmentId",
                table: "Hall",
                newName: "IX_Hall_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Department_DepartmentId",
                table: "Hall",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lab_Department_DepartmentId",
                table: "Lab",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Office_Department_DepartmentId",
                table: "Office",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Department_DepartmentId",
                table: "Hall");

            migrationBuilder.DropForeignKey(
                name: "FK_Lab_Department_DepartmentId",
                table: "Lab");

            migrationBuilder.DropForeignKey(
                name: "FK_Office_Department_DepartmentId",
                table: "Office");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Office",
                newName: "DeprtmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Office_DepartmentId",
                table: "Office",
                newName: "IX_Office_DeprtmentId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Lab",
                newName: "DeprtmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Lab_DepartmentId",
                table: "Lab",
                newName: "IX_Lab_DeprtmentId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Hall",
                newName: "DeprtmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Hall_DepartmentId",
                table: "Hall",
                newName: "IX_Hall_DeprtmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Department_DeprtmentId",
                table: "Hall",
                column: "DeprtmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lab_Department_DeprtmentId",
                table: "Lab",
                column: "DeprtmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Office_Department_DeprtmentId",
                table: "Office",
                column: "DeprtmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }
    }
}
