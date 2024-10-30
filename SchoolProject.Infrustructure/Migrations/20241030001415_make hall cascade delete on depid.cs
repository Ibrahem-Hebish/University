using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class makehallcascadedeleteondepid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_Office_Department_DepartmentId",
                table: "Office");

            // Re-add the foreign key constraint with the new OnDelete behavior
            migrationBuilder.AddForeignKey(
                name: "FK_Office_Department_DepartmentId",
                table: "Office",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            // Drop the existing foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Department_DepartmentId",
                table: "Hall");

            // Re-add the foreign key constraint with the new OnDelete behavior
            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Department_DepartmentId",
                table: "Hall",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            // Drop the existing foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_Lab_Department_DepartmentId",
                table: "Lab");

            // Re-add the foreign key constraint with the new OnDelete behavior
            migrationBuilder.AddForeignKey(
                name: "FK_Lab_Department_DepartmentId",
                table: "Lab",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the foreign key constraint in the Down method
            migrationBuilder.DropForeignKey(
                name: "FK_Office_Department_DepartmentId",
                table: "Office");

            // Re-add the original foreign key constraint to revert changes
            migrationBuilder.AddForeignKey(
                name: "FK_Office_Department_DepartmentId",
                table: "Office",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.DropForeignKey(
                name: "FK_Lab_Department_DepartmentId",
                table: "Lab");

            // Re-add the original foreign key constraint to revert changes
            migrationBuilder.AddForeignKey(
                name: "FK_Lab_Department_DepartmentId",
                table: "Lab",
                column: "DeprtmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Department_DepartmentId",
                table: "Hall");

            // Re-add the original foreign key constraint to revert changes
            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Department_DepartmentId",
                table: "Hall",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

        }
    }
}
