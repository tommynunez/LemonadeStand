using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LemonadeStand.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LemonadeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "date('now')"),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "date('now')"),
                    Deleted = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LemonadeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(75)", nullable: false),
                    Email = table.Column<string>(type: "varchar(75)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(75)", nullable: false),
                    TotalCost = table.Column<double>(type: "REAL", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "date('now')"),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "date('now')"),
                    Deleted = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "date('now')"),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "date('now')"),
                    Deleted = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LemonadeTypeId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "date('now')"),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "date('now')"),
                    Deleted = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Product_LemonadeTypes",
                        column: x => x.LemonadeTypeId,
                        principalTable: "LemonadeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_Product_Sizes",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineIitem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "date('now')"),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "date('now')"),
                    Deleted = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineIitem", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Order_LineItems",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_Product_LineItems",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LemonadeType",
                columns: new[] { "Id", "Created", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 5, 10, 38, 30, 562, DateTimeKind.Local).AddTicks(6730), null, "Regular Lemonade" },
                    { 2, new DateTime(2025, 2, 5, 10, 38, 30, 562, DateTimeKind.Local).AddTicks(6740), null, "Pink Lemonade" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Created", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 5, 10, 38, 30, 562, DateTimeKind.Local).AddTicks(8620), null, "Regular Size" },
                    { 2, new DateTime(2025, 2, 5, 10, 38, 30, 562, DateTimeKind.Local).AddTicks(8630), null, "Large Size" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Amount", "Created", "Deleted", "LemonadeTypeId", "SizeId" },
                values: new object[,]
                {
                    { 1, 0.75, new DateTime(2025, 2, 5, 10, 38, 30, 563, DateTimeKind.Local).AddTicks(4620), null, 1, 1 },
                    { 2, 1.5, new DateTime(2025, 2, 5, 10, 38, 30, 563, DateTimeKind.Local).AddTicks(4630), null, 1, 2 },
                    { 3, 0.75, new DateTime(2025, 2, 5, 10, 38, 30, 563, DateTimeKind.Local).AddTicks(4640), null, 2, 1 },
                    { 4, 1.5, new DateTime(2025, 2, 5, 10, 38, 30, 563, DateTimeKind.Local).AddTicks(4650), null, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineIitem_OrderId",
                table: "LineIitem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_LineIitem_ProductId",
                table: "LineIitem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_LemonadeTypeId",
                table: "Product",
                column: "LemonadeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SizeId",
                table: "Product",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineIitem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "LemonadeType");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
