using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccess.Migrations
{
    public partial class ApplicationUserChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "09e08986-8e31-4bbe-b2dc-630dd1365879");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "8fadeb1c-5e9b-46e2-8087-ae97ed19e0bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "98efe2bb-16a2-43a3-9680-ebbc9ffe1512", new DateTime(2020, 9, 9, 7, 2, 0, 0, DateTimeKind.Utc).AddTicks(2982) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "a8f38f3d-80a7-4334-b78a-8d29bb420edc", new DateTime(2020, 9, 9, 7, 2, 0, 0, DateTimeKind.Utc).AddTicks(5268) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "2bacb922-019e-458d-96fc-b3d938379007", new DateTime(2020, 9, 9, 7, 2, 0, 0, DateTimeKind.Utc).AddTicks(5293) });

            migrationBuilder.UpdateData(
                table: "AuthorInPrintingEditions",
                keyColumns: new[] { "AuthorId", "PrintingEditionId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreationDate",
                value: new DateTime(2020, 9, 9, 7, 2, 0, 1, DateTimeKind.Utc).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 9, 7, 2, 0, 0, DateTimeKind.Utc).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 9, 7, 2, 0, 0, DateTimeKind.Utc).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 9, 7, 2, 0, 1, DateTimeKind.Utc).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 9, 7, 2, 0, 1, DateTimeKind.Utc).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 9, 7, 2, 0, 1, DateTimeKind.Utc).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 9, 7, 2, 0, 1, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 9, 7, 2, 0, 1, DateTimeKind.Utc).AddTicks(6165));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 9, 7, 2, 0, 1, DateTimeKind.Utc).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 9, 7, 2, 0, 0, DateTimeKind.Utc).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 9, 9, 7, 2, 0, 1, DateTimeKind.Utc).AddTicks(607));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "AspNetUsers",
                type: "bit",
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
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "ea8f01dc-4945-4a55-9bc0-27e37de460de", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "b6d30a1c-e811-4643-9833-d670a0899609", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "339ef1d1-ae2d-46b0-9916-9501081ed4fc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
    }
}
