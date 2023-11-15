using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IqraPearls.Migrations
{
    /// <inheritdoc />
    public partial class SellerOrderRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellerOrderRelationship_Orders_OrderId",
                table: "SellerOrderRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerOrderRelationship_Sellerss_SellersId",
                table: "SellerOrderRelationship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellerOrderRelationship",
                table: "SellerOrderRelationship");

            migrationBuilder.RenameTable(
                name: "SellerOrderRelationship",
                newName: "SellerOrderTable");

            migrationBuilder.RenameIndex(
                name: "IX_SellerOrderRelationship_SellersId",
                table: "SellerOrderTable",
                newName: "IX_SellerOrderTable_SellersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellerOrderTable",
                table: "SellerOrderTable",
                columns: new[] { "OrderId", "SellersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SellerOrderTable_Orders_OrderId",
                table: "SellerOrderTable",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerOrderTable_Sellerss_SellersId",
                table: "SellerOrderTable",
                column: "SellersId",
                principalTable: "Sellerss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellerOrderTable_Orders_OrderId",
                table: "SellerOrderTable");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerOrderTable_Sellerss_SellersId",
                table: "SellerOrderTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellerOrderTable",
                table: "SellerOrderTable");

            migrationBuilder.RenameTable(
                name: "SellerOrderTable",
                newName: "SellerOrderRelationship");

            migrationBuilder.RenameIndex(
                name: "IX_SellerOrderTable_SellersId",
                table: "SellerOrderRelationship",
                newName: "IX_SellerOrderRelationship_SellersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellerOrderRelationship",
                table: "SellerOrderRelationship",
                columns: new[] { "OrderId", "SellersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SellerOrderRelationship_Orders_OrderId",
                table: "SellerOrderRelationship",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerOrderRelationship_Sellerss_SellersId",
                table: "SellerOrderRelationship",
                column: "SellersId",
                principalTable: "Sellerss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
