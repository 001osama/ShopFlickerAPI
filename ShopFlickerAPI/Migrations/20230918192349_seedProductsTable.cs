using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopFlickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "CreatedDate", "Desc", "Name" },
                values: new object[,]
                {
                    { 1, 1.99, new DateTime(2023, 7, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9841), "Fresh carrots from the local farm.", "Carrots" },
                    { 2, 2.4900000000000002, new DateTime(2023, 8, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9887), "Organic broccoli for a healthy diet.", "Broccoli" },
                    { 3, 1.79, new DateTime(2023, 6, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9893), "Leafy green spinach, perfect for salads.", "Spinach" },
                    { 4, 2.9900000000000002, new DateTime(2023, 7, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9899), "Vine-ripened tomatoes for your recipes.", "Tomatoes" },
                    { 5, 1.49, new DateTime(2023, 7, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9903), "Crunchy cucumbers for snacking.", "Cucumbers" },
                    { 6, 1.49, new DateTime(2023, 7, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9908), "Crunchy cucumbers for snacking.", "Cucumbers" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
