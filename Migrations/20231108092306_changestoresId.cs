using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IqraPearls.Migrations
{
    /// <inheritdoc />
    public partial class changestoresId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sellerss_sellersId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StoresId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "sellersId",
                table: "Products",
                newName: "SellersId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_sellersId",
                table: "Products",
                newName: "IX_Products_SellersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sellerss_SellersId",
                table: "Products",
                column: "SellersId",
                principalTable: "Sellerss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sellerss_SellersId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SellersId",
                table: "Products",
                newName: "sellersId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SellersId",
                table: "Products",
                newName: "IX_Products_sellersId");

            migrationBuilder.AddColumn<int>(
                name: "StoresId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sellerss_sellersId",
                table: "Products",
                column: "sellersId",
                principalTable: "Sellerss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
