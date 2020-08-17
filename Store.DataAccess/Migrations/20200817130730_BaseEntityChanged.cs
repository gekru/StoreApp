using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccess.Migrations
{
    public partial class BaseEntityChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "AuthorInPrintingEditions");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PrintingEditions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Payments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Payments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "OrderItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "OrderItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Authors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Authors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AuthorInPrintingEditions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "AuthorInPrintingEditions",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "AuthorInPrintingEditions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "6a210b0a-9663-4767-baef-5cf0b8e8bf80");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "72237bea-50b8-4da0-bf2d-83f598e8b565");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "89a1a769-55a1-4358-8768-7ee5caac7829");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "16b3fc4b-b59d-4b06-b9ca-2148ca7bca05");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "2f97e118-796b-42e1-af0d-af730781450c");

            migrationBuilder.UpdateData(
                table: "AuthorInPrintingEditions",
                keyColumns: new[] { "AuthorId", "PrintingEditionId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreationDate",
                value: new DateTime(2020, 8, 17, 16, 7, 30, 140, DateTimeKind.Local).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 17, 16, 7, 30, 137, DateTimeKind.Local).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 17, 16, 7, 30, 140, DateTimeKind.Local).AddTicks(1830));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 8, 17, 16, 7, 30, 141, DateTimeKind.Local).AddTicks(2296), 1 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 8, 17, 16, 7, 30, 141, DateTimeKind.Local).AddTicks(2352), 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Status" },
                values: new object[] { new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Status" },
                values: new object[] { new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 17, 16, 7, 30, 141, DateTimeKind.Local).AddTicks(89));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 17, 16, 7, 30, 141, DateTimeKind.Local).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Currency", "Type" },
                values: new object[] { new DateTime(2020, 8, 17, 16, 7, 30, 140, DateTimeKind.Local).AddTicks(4449), 1, 1 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Currency", "Type" },
                values: new object[] { new DateTime(2020, 8, 17, 16, 7, 30, 140, DateTimeKind.Local).AddTicks(4534), 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PrintingEditions");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "AuthorInPrintingEditions");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "AuthorInPrintingEditions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "6a2a2784-e626-418d-8d66-045cfb9a1645");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "5362ef69-c2e6-44ca-8455-95ff9a07b67e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "f20cecdb-1866-4a58-b24c-c03d767dcd6a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "1cc61133-c9aa-49e1-adc2-ef4b67f95139");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "3a88e94f-c502-476b-9557-01b5b380f87b");

            migrationBuilder.UpdateData(
                table: "AuthorInPrintingEditions",
                keyColumns: new[] { "AuthorId", "PrintingEditionId" },
                keyValues: new object[] { 1L, 1L },
                column: "Date",
                value: new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Currency",
                value: 0);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Currency",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date", "Status" },
                values: new object[] { new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Local), 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date", "Status" },
                values: new object[] { new DateTime(2020, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Currency", "Type" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Currency", "Type" },
                values: new object[] { 0, 1 });
        }
    }
}
