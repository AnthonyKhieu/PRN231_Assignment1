using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Freight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Category 1" },
                    { 2, "Category 2" },
                    { 3, "Category 3" },
                    { 4, "Category 4" },
                    { 5, "Category 5" }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "MemberId", "City", "CompanyName", "Country", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "LA", "Microsoft", "America", "member1@gmail.com", "P@ssword12345" },
                    { 2, "Hanoi", "Vingroup", "Vietnam", "member2@gmail.com", "P@ssword12345" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Freight", "MemberId", "OrderDate", "RequiredDate", "ShippedDate" },
                values: new object[,]
                {
                    { 1, 10m, 1, new DateTime(2023, 2, 13, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3559), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3567), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3570) },
                    { 2, 10m, 1, new DateTime(2023, 2, 13, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3571), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3571), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3572) },
                    { 3, 10m, 1, new DateTime(2023, 2, 13, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3573), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3573), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3574) },
                    { 4, 10m, 1, new DateTime(2023, 2, 13, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3574), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3575), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3575) },
                    { 5, 10m, 2, new DateTime(2023, 2, 13, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3576), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3576), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3577) },
                    { 6, 10m, 2, new DateTime(2023, 2, 13, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3599), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3600), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3600) },
                    { 7, 10m, 2, new DateTime(2023, 2, 13, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3601), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3601), new DateTime(2023, 2, 20, 17, 13, 14, 386, DateTimeKind.Local).AddTicks(3602) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "ProductName", "UnitPrice", "UnitsInStock", "Weight" },
                values: new object[,]
                {
                    { 1, 1, "Product A", 100m, 100, 0.0 },
                    { 2, 2, "Product B", 100m, 100, 0.0 },
                    { 3, 3, "Product C", 100m, 100, 0.0 },
                    { 4, 4, "Product D", 100m, 100, 0.0 },
                    { 5, 5, "Product E", 100m, 100, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "OrderId", "ProductId", "Discount", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 0.29999999999999999, 10, 100m },
                    { 1, 2, 0.29999999999999999, 10, 100m },
                    { 2, 1, 0.29999999999999999, 10, 100m },
                    { 2, 2, 0.29999999999999999, 10, 100m },
                    { 3, 1, 0.29999999999999999, 10, 100m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_MemberId",
                table: "Order",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                table: "User",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
