using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class EditSomeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Office_OfficeId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Lab_LabId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Hall_HallId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachingAssistant_Office_OfficeId",
                table: "TeachingAssistant");

            migrationBuilder.DropIndex(
                name: "IX_TeachingAssistant_OfficeId",
                table: "TeachingAssistant");

            migrationBuilder.DropIndex(
                name: "IX_Subject_HallId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Section_LabId",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Office",
                table: "Office");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lab",
                table: "Lab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hall",
                table: "Hall");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_OfficeId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "TeachingAssistant");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "LabId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Office");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Lab");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Hall");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Doctor");

            migrationBuilder.AddColumn<string>(
                name: "OfficeName",
                table: "TeachingAssistant",
                type: "VARCHAR(5)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HallName",
                table: "Subject",
                type: "VARCHAR(2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LabName",
                table: "Section",
                type: "VARCHAR(4)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeName",
                table: "Doctor",
                type: "VARCHAR(5)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeName",
                table: "AspNetUsers",
                type: "VARCHAR(5)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Office",
                table: "Office",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lab",
                table: "Lab",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hall",
                table: "Hall",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingAssistant_OfficeName",
                table: "TeachingAssistant",
                column: "OfficeName");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_HallName",
                table: "Subject",
                column: "HallName");

            migrationBuilder.CreateIndex(
                name: "IX_Section_LabName",
                table: "Section",
                column: "LabName");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_OfficeName",
                table: "Doctor",
                column: "OfficeName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OfficeName",
                table: "AspNetUsers",
                column: "OfficeName");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Office_OfficeName",
                table: "AspNetUsers",
                column: "OfficeName",
                principalTable: "Office",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Office_OfficeName",
                table: "Doctor",
                column: "OfficeName",
                principalTable: "Office",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Lab_LabName",
                table: "Section",
                column: "LabName",
                principalTable: "Lab",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Hall_HallName",
                table: "Subject",
                column: "HallName",
                principalTable: "Hall",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachingAssistant_Office_OfficeName",
                table: "TeachingAssistant",
                column: "OfficeName",
                principalTable: "Office",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Office_OfficeName",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Office_OfficeName",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Lab_LabName",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Hall_HallName",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachingAssistant_Office_OfficeName",
                table: "TeachingAssistant");

            migrationBuilder.DropIndex(
                name: "IX_TeachingAssistant_OfficeName",
                table: "TeachingAssistant");

            migrationBuilder.DropIndex(
                name: "IX_Subject_HallName",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Section_LabName",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Office",
                table: "Office");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lab",
                table: "Lab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hall",
                table: "Hall");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_OfficeName",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OfficeName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OfficeName",
                table: "TeachingAssistant");

            migrationBuilder.DropColumn(
                name: "HallName",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "LabName",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "OfficeName",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "OfficeName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "TeachingAssistant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LabId",
                table: "Section",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Office",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Lab",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Hall",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Office",
                table: "Office",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lab",
                table: "Lab",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hall",
                table: "Hall",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingAssistant_OfficeId",
                table: "TeachingAssistant",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_HallId",
                table: "Subject",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_LabId",
                table: "Section",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_OfficeId",
                table: "Doctor",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Office_OfficeId",
                table: "Doctor",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Lab_LabId",
                table: "Section",
                column: "LabId",
                principalTable: "Lab",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Hall_HallId",
                table: "Subject",
                column: "HallId",
                principalTable: "Hall",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachingAssistant_Office_OfficeId",
                table: "TeachingAssistant",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "Id");
        }
    }
}
