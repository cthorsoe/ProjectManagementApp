using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementApp.Migrations
{
    public partial class RenamedPasswordColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "User",
                newName: "PasswordSalt");

            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "User",
                newName: "PasswordHash");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "User",
                newName: "Salt");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "User",
                newName: "Hash");
        }
    }
}
