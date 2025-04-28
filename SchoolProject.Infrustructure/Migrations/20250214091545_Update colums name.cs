using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class Updatecolumsname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Office_OfficeName",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Office_OfficeName",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachingAssistant_Office_OfficeName",
                table: "TeachingAssistant");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "UserTokens",
                newName: "RefreshToken");

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
                name: "FK_TeachingAssistant_Office_OfficeName",
                table: "TeachingAssistant");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "UserTokens",
                newName: "Token");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Office_OfficeName",
                table: "AspNetUsers",
                column: "OfficeName",
                principalTable: "Office",
                principalColumn: "Name",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Office_OfficeName",
                table: "Doctor",
                column: "OfficeName",
                principalTable: "Office",
                principalColumn: "Name",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachingAssistant_Office_OfficeName",
                table: "TeachingAssistant",
                column: "OfficeName",
                principalTable: "Office",
                principalColumn: "Name",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
