using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopFlickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedingCartsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 14, 43, 56, 257, DateTimeKind.Local).AddTicks(673));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 24, 14, 43, 56, 257, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 24, 14, 43, 56, 257, DateTimeKind.Local).AddTicks(701));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 14, 43, 56, 257, DateTimeKind.Local).AddTicks(703));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 14, 43, 56, 257, DateTimeKind.Local).AddTicks(706));

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "Count", "CreatedDate", "Price", "ProductId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2023, 9, 24, 8, 43, 56, 257, DateTimeKind.Utc).AddTicks(954), 10.99, 1, new DateTime(2023, 9, 24, 9, 43, 56, 257, DateTimeKind.Utc).AddTicks(953), "49372f70-f714-417a-bfbf-2b7595975a88" },
                    { 2, 2, new DateTime(2023, 9, 24, 7, 43, 56, 257, DateTimeKind.Utc).AddTicks(961), 5.9900000000000002, 2, new DateTime(2023, 9, 24, 9, 43, 56, 257, DateTimeKind.Utc).AddTicks(960), "49372f70-f714-417a-bfbf-2b7595975a88" },
                    { 3, 1, new DateTime(2023, 9, 24, 6, 43, 56, 257, DateTimeKind.Utc).AddTicks(964), 8.4900000000000002, 3, new DateTime(2023, 9, 24, 9, 43, 56, 257, DateTimeKind.Utc).AddTicks(963), "49372f70-f714-417a-bfbf-2b7595975a88" },
                    { 4, 4, new DateTime(2023, 9, 24, 5, 43, 56, 257, DateTimeKind.Utc).AddTicks(967), 12.99, 4, new DateTime(2023, 9, 24, 9, 43, 56, 257, DateTimeKind.Utc).AddTicks(966), "49372f70-f714-417a-bfbf-2b7595975a88" },
                    { 5, 2, new DateTime(2023, 9, 24, 4, 43, 56, 257, DateTimeKind.Utc).AddTicks(969), 7.9900000000000002, 5, new DateTime(2023, 9, 24, 9, 43, 56, 257, DateTimeKind.Utc).AddTicks(969), "49372f70-f714-417a-bfbf-2b7595975a88" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShoppingCarts");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 14, 34, 1, 366, DateTimeKind.Local).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 24, 14, 34, 1, 366, DateTimeKind.Local).AddTicks(5082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 24, 14, 34, 1, 366, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 14, 34, 1, 366, DateTimeKind.Local).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 14, 34, 1, 366, DateTimeKind.Local).AddTicks(5093));
        }
    }
}
