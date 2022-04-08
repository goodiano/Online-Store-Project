using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateProjectOne.Persistance.Migrations
{
    public partial class EditRequestPay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 5, 1, 25, 13, 820, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 4, 5, 1, 25, 13, 820, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 4, 5, 1, 25, 13, 820, DateTimeKind.Local).AddTicks(869));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 5, 0, 11, 58, 949, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 4, 5, 0, 11, 58, 949, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 4, 5, 0, 11, 58, 949, DateTimeKind.Local).AddTicks(9265));
        }
    }
}
