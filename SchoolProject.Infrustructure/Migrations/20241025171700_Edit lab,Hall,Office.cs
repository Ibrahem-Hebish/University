using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class EditlabHallOffice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Office",
                type: "VARCHAR(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Floor",
                table: "Office",
                type: "VARCHAR(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lab",
                type: "VARCHAR(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Floor",
                table: "Lab",
                type: "VARCHAR(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Office",
                type: "VARCHAR(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Floor",
                table: "Office",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lab",
                type: "VARCHAR(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Floor",
                table: "Lab",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1)",
                oldMaxLength: 1);
        }
    }
}
