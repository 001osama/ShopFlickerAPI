using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopFlickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class removingCartAdditionFromDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "CreatedDate", "ProductId", "Quantity", "TotalPrice", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 3, 19, 59, 37, 415, DateTimeKind.Utc).AddTicks(5313), 1, 3, 10.99, new DateTime(2023, 11, 3, 20, 59, 37, 415, DateTimeKind.Utc).AddTicks(5310), "49372f70-f714-417a-bfbf-2b7595975a88" },
                    { 2, new DateTime(2023, 11, 3, 18, 59, 37, 415, DateTimeKind.Utc).AddTicks(5324), 2, 2, 5.9900000000000002, new DateTime(2023, 11, 3, 20, 59, 37, 415, DateTimeKind.Utc).AddTicks(5323), "49372f70-f714-417a-bfbf-2b7595975a88" },
                    { 3, new DateTime(2023, 11, 3, 17, 59, 37, 415, DateTimeKind.Utc).AddTicks(5327), 3, 1, 8.4900000000000002, new DateTime(2023, 11, 3, 20, 59, 37, 415, DateTimeKind.Utc).AddTicks(5326), "49372f70-f714-417a-bfbf-2b7595975a88" },
                    { 4, new DateTime(2023, 11, 3, 16, 59, 37, 415, DateTimeKind.Utc).AddTicks(5329), 4, 4, 12.99, new DateTime(2023, 11, 3, 20, 59, 37, 415, DateTimeKind.Utc).AddTicks(5328), "49372f70-f714-417a-bfbf-2b7595975a88" },
                    { 5, new DateTime(2023, 11, 3, 15, 59, 37, 415, DateTimeKind.Utc).AddTicks(5332), 5, 2, 7.9900000000000002, new DateTime(2023, 11, 3, 20, 59, 37, 415, DateTimeKind.Utc).AddTicks(5331), "49372f70-f714-417a-bfbf-2b7595975a88" }
                });
        }
    }
}
