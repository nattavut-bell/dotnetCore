﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG_Project.Migrations
{
    public partial class BulkCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bulk",
                columns: table => new
                {
                    BulkId = table.Column<int>(nullable: false),
                    BulkName = table.Column<string>(maxLength: 20, nullable: true),
                    BulkCode = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulk", x => x.BulkId);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    StockCount = table.Column<int>(nullable: false),
                    ProductGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductGroupId",
                table: "Product",
                column: "ProductGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bulk");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductGroup");
        }
    }
}