using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateProjectOne.Persistance.Migrations
{
    public partial class RequestPay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestPay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isPay = table.Column<bool>(type: "bit", nullable: false),
                    DatePay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefId = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestPay_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RequestPay_UserId",
                table: "RequestPay",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestPay");

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
    }
}
