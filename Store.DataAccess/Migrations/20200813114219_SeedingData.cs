using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccess.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "07f78335-1758-4bf2-892c-7a4120b38b09", "Admin", null },
                    { 2L, "f97d93db-934a-4307-b27d-8908eb6269fe", "Client", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1L, 0, "ff5f6164-482a-413a-a81f-3465a51748a5", "emma@domain.com", false, "Emma", "Jones", false, null, null, null, "", null, false, null, false, null },
                    { 2L, 0, "6af873ba-849c-4f83-9326-6ba67ec63e7d", "ls@mail.com", false, "Lincoln", "Smith", false, null, null, null, "", null, false, null, false, null },
                    { 3L, 0, "3b3a73ab-0578-4fe2-b8e2-adec2a73a707", "zoe@mail.com", false, "Zoe", "Wilson", false, null, null, null, "", null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Brit Bennett" },
                    { 2L, "Brad Thor" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "TransactionId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 2L }
                });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, 0, "Hardcover – June 2, 2020", false, 16.2m, 0, "The Vanishing Half: A Novel", 0 },
                    { 2L, 0, "Your source for breaking news", true, 8m, 0, "New York Post", 1 }
                });

            migrationBuilder.InsertData(
                table: "AuthorInPrintingEditions",
                columns: new[] { "AuthorId", "PrintingEditionId", "Date" },
                values: new object[] { 1L, 1L, new DateTime(2020, 8, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ApplicationUserId", "Date", "Description", "PaymentId" },
                values: new object[] { 2L, 3L, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), "Journal order", 2L });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ApplicationUserId", "Date", "Description", "PaymentId" },
                values: new object[] { 1L, 1L, new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), "Book order", 1L });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Amount", "Count", "Currency", "OrderId", "PrintingEditionId" },
                values: new object[] { 1L, 2, 1, 0, 1L, 1L });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Amount", "Count", "Currency", "OrderId", "PrintingEditionId" },
                values: new object[] { 2L, 1, 1, 0, 2L, 2L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AuthorInPrintingEditions",
                keyColumns: new[] { "AuthorId", "PrintingEditionId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
