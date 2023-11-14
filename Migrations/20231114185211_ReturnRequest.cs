using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IqraPearls.Migrations
{
    /// <inheritdoc />
    public partial class ReturnRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "List<int>",
                columns: table => new
                {
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReturnRequestTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ReasonForReturn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeReturnRequested = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReturnStatus = table.Column<int>(type: "int", nullable: false),
                    ReturnChoice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnRequestTable", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SellerReturnRequestTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReasonForReturn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReasonForAcceptanceOrDenial = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductIdToReturn = table.Column<int>(type: "int", nullable: false),
                    ProductIdonOrder = table.Column<int>(type: "int", nullable: false),
                    QuantityToReturn = table.Column<int>(type: "int", nullable: false),
                    isRequestAccepted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TimeReturnRequested = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SellersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerReturnRequestTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerReturnRequestTable_Sellerss_SellersId",
                        column: x => x.SellersId,
                        principalTable: "Sellerss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductRequestRelationship",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ReturnRequestModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRequestRelationship", x => new { x.ProductId, x.ReturnRequestModelId });
                    table.ForeignKey(
                        name: "FK_ProductRequestRelationship_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRequestRelationship_ReturnRequestTable_ReturnRequestM~",
                        column: x => x.ReturnRequestModelId,
                        principalTable: "ReturnRequestTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRequestRelationship_ReturnRequestModelId",
                table: "ProductRequestRelationship",
                column: "ReturnRequestModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerReturnRequestTable_SellersId",
                table: "SellerReturnRequestTable",
                column: "SellersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "List<int>");

            migrationBuilder.DropTable(
                name: "ProductRequestRelationship");

            migrationBuilder.DropTable(
                name: "SellerReturnRequestTable");

            migrationBuilder.DropTable(
                name: "ReturnRequestTable");
        }
    }
}
