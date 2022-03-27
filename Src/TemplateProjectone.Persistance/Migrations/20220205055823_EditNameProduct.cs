using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateProjectOne.Persistance.Migrations
{
    public partial class EditNameProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeatures_Products_ProductId",
                table: "ProductFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "AddProducts");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "AddProducts",
                newName: "IX_AddProducts_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddProducts",
                table: "AddProducts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 2, 5, 9, 28, 22, 997, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 2, 5, 9, 28, 22, 997, DateTimeKind.Local).AddTicks(5586));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 2, 5, 9, 28, 22, 997, DateTimeKind.Local).AddTicks(5601));

            migrationBuilder.AddForeignKey(
                name: "FK_AddProducts_Categories_CategoryId",
                table: "AddProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeatures_AddProducts_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                principalTable: "AddProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_AddProducts_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "AddProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddProducts_Categories_CategoryId",
                table: "AddProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeatures_AddProducts_ProductId",
                table: "ProductFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_AddProducts_ProductId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddProducts",
                table: "AddProducts");

            migrationBuilder.RenameTable(
                name: "AddProducts",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_AddProducts_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 1, 31, 15, 5, 47, 646, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 1, 31, 15, 5, 47, 646, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 1, 31, 15, 5, 47, 646, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeatures_Products_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
