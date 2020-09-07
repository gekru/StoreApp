using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccess.Migrations
{
    public partial class UserEntitiesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "f01bc558-b039-46b1-8760-a8549143d9e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "75eeddfa-dd68-483f-bba1-3b7635834d5a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "ea8f01dc-4945-4a55-9bc0-27e37de460de");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "b6d30a1c-e811-4643-9833-d670a0899609");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "339ef1d1-ae2d-46b0-9916-9501081ed4fc");

            migrationBuilder.UpdateData(
                table: "AuthorInPrintingEditions",
                keyColumns: new[] { "AuthorId", "PrintingEditionId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreationDate",
                value: new DateTime(2020, 9, 7, 10, 11, 29, 652, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 7, 10, 11, 29, 649, DateTimeKind.Local).AddTicks(5586));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 7, 10, 11, 29, 651, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 7, 10, 11, 29, 652, DateTimeKind.Local).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 7, 10, 11, 29, 652, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 7, 10, 11, 29, 652, DateTimeKind.Local).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 7, 10, 11, 29, 652, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 7, 10, 11, 29, 652, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 7, 10, 11, 29, 652, DateTimeKind.Local).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 7, 10, 11, 29, 651, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 7, 10, 11, 29, 652, DateTimeKind.Local).AddTicks(1861));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "9c34f40f-4c65-417f-8888-73a5c5966f5d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "c1711610-c491-4315-9977-d43c3c00df58");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "a4c591f5-c2cd-43aa-ab77-987fdf139437");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "0beaede7-bece-4948-b134-4944321a2187");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "583d25ed-9cfa-4236-a660-19acac10c9a9");

            migrationBuilder.UpdateData(
                table: "AuthorInPrintingEditions",
                keyColumns: new[] { "AuthorId", "PrintingEditionId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreationDate",
                value: new DateTime(2020, 9, 2, 10, 53, 8, 691, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 2, 10, 53, 8, 688, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 2, 10, 53, 8, 690, DateTimeKind.Local).AddTicks(8848));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 2, 10, 53, 8, 691, DateTimeKind.Local).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 2, 10, 53, 8, 691, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 2, 10, 53, 8, 691, DateTimeKind.Local).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 2, 10, 53, 8, 691, DateTimeKind.Local).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 2, 10, 53, 8, 691, DateTimeKind.Local).AddTicks(6965));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 2, 10, 53, 8, 691, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 2, 10, 53, 8, 690, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 2, 10, 53, 8, 691, DateTimeKind.Local).AddTicks(1533));
        }
    }
}
