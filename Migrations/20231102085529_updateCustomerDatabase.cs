using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IqraPearls.Migrations
{
    /// <inheritdoc />
    public partial class updateCustomerDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Customerss",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customerss",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Customerss",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customerss",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "GeneratedSalt",
                table: "Customerss",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Customerss");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customerss");

            migrationBuilder.DropColumn(
                name: "GeneratedSalt",
                table: "Customerss");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Customerss",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customerss",
                newName: "Name");
        }
    }
}
