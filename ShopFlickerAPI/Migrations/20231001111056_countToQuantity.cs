using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopFlickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class countToQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "ShoppingCarts",
                newName: "Quantity");

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 1, 10, 10, 55, 917, DateTimeKind.Utc).AddTicks(6114), new DateTime(2023, 10, 1, 11, 10, 55, 917, DateTimeKind.Utc).AddTicks(6108) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 1, 9, 10, 55, 917, DateTimeKind.Utc).AddTicks(6131), new DateTime(2023, 10, 1, 11, 10, 55, 917, DateTimeKind.Utc).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 1, 8, 10, 55, 917, DateTimeKind.Utc).AddTicks(6135), new DateTime(2023, 10, 1, 11, 10, 55, 917, DateTimeKind.Utc).AddTicks(6134) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 1, 7, 10, 55, 917, DateTimeKind.Utc).AddTicks(6139), new DateTime(2023, 10, 1, 11, 10, 55, 917, DateTimeKind.Utc).AddTicks(6139) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 1, 6, 10, 55, 917, DateTimeKind.Utc).AddTicks(6143), new DateTime(2023, 10, 1, 11, 10, 55, 917, DateTimeKind.Utc).AddTicks(6142) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ShoppingCarts",
                newName: "Count");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Desc", "ImagePath", "ImageUrl", "Name", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 28, 11, 44, 39, 273, DateTimeKind.Local).AddTicks(3761), "Fresh carrots from the local farm.", "none", "none", "Carrots", 1.99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 8, 28, 11, 44, 39, 273, DateTimeKind.Local).AddTicks(3813), "Organic broccoli for a healthy diet.", "none", "none", "Broccoli", 2.4900000000000002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 6, 28, 11, 44, 39, 273, DateTimeKind.Local).AddTicks(3826), "Leafy green spinach, perfect for salads.", "none", "none", "Spinach", 1.79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 7, 28, 11, 44, 39, 273, DateTimeKind.Local).AddTicks(3829), "Vine-ripened tomatoes for your recipes.", "none", "none", "Tomatoes", 2.9900000000000002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 7, 28, 11, 44, 39, 273, DateTimeKind.Local).AddTicks(3835), "Crunchy cucumbers for snacking.", "none", "none", "Cucumbers", 1.49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 5, 44, 39, 273, DateTimeKind.Utc).AddTicks(4190), new DateTime(2023, 9, 28, 6, 44, 39, 273, DateTimeKind.Utc).AddTicks(4189) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 4, 44, 39, 273, DateTimeKind.Utc).AddTicks(4198), new DateTime(2023, 9, 28, 6, 44, 39, 273, DateTimeKind.Utc).AddTicks(4196) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 3, 44, 39, 273, DateTimeKind.Utc).AddTicks(4203), new DateTime(2023, 9, 28, 6, 44, 39, 273, DateTimeKind.Utc).AddTicks(4202) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 2, 44, 39, 273, DateTimeKind.Utc).AddTicks(4206), new DateTime(2023, 9, 28, 6, 44, 39, 273, DateTimeKind.Utc).AddTicks(4206) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 1, 44, 39, 273, DateTimeKind.Utc).AddTicks(4210), new DateTime(2023, 9, 28, 6, 44, 39, 273, DateTimeKind.Utc).AddTicks(4210) });
        }
    }
}
