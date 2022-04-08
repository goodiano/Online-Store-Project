using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateProjectOne.Persistance.Migrations
{
    public partial class AddCountInProductDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "AddProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 3, 31, 7, 58, 25, 584, DateTimeKind.Local).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 3, 31, 7, 58, 25, 584, DateTimeKind.Local).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 3, 31, 7, 58, 25, 584, DateTimeKind.Local).AddTicks(1078));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "AddProducts");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 3, 31, 7, 0, 59, 609, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 3, 31, 7, 0, 59, 609, DateTimeKind.Local).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 3, 31, 7, 0, 59, 609, DateTimeKind.Local).AddTicks(7455));
        }
    }
}
