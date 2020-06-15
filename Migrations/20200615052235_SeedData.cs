using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace moneda.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                column: "UserId",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5
                });

            migrationBuilder.InsertData(
                table: "Charges",
                columns: new[] { "ChargeId", "ChargeDate", "UserId", "amount", "currency" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 100.0, 0 },
                    { 2, new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200.0, 1 },
                    { 3, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 200.0, 0 },
                    { 4, new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 300.0, 1 },
                    { 5, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 50.0, 0 },
                    { 6, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 187.0, 1 },
                    { 7, new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 176.0, 0 },
                    { 8, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 60.0, 1 },
                    { 9, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 12.0, 0 },
                    { 10, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 100.0, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "ChargeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "ChargeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "ChargeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "ChargeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "ChargeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "ChargeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "ChargeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "ChargeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "ChargeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "ChargeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);
        }
    }
}
