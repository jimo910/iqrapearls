using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IqraPearls.Migrations
{
    /// <inheritdoc />
    public partial class SellerOrderRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellerss_Orders_OrderId",
                table: "Sellerss");

            migrationBuilder.DropIndex(
                name: "IX_Sellerss_OrderId",
                table: "Sellerss");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Sellerss");

            migrationBuilder.CreateTable(
                name: "SellerOrderRelationship",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SellersId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerOrderRelationship", x => new { x.OrderId, x.SellersId });
                    table.ForeignKey(
                        name: "FK_SellerOrderRelationship_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerOrderRelationship_Sellerss_SellersId",
                        column: x => x.SellersId,
                        principalTable: "Sellerss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SellerOrderRelationship_SellersId",
                table: "SellerOrderRelationship",
                column: "SellersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellerOrderRelationship");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Sellerss",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellerss_OrderId",
                table: "Sellerss",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellerss_Orders_OrderId",
                table: "Sellerss",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
