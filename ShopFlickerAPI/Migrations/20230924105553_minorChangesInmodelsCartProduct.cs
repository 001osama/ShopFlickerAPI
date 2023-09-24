using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopFlickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class minorChangesInmodelsCartProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Products",
                newName: "Price");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 15, 55, 53, 21, DateTimeKind.Local).AddTicks(5358));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 24, 15, 55, 53, 21, DateTimeKind.Local).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 24, 15, 55, 53, 21, DateTimeKind.Local).AddTicks(5386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 15, 55, 53, 21, DateTimeKind.Local).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 15, 55, 53, 21, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 9, 55, 53, 21, DateTimeKind.Utc).AddTicks(5727), new DateTime(2023, 9, 24, 10, 55, 53, 21, DateTimeKind.Utc).AddTicks(5726) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 8, 55, 53, 21, DateTimeKind.Utc).AddTicks(5736), new DateTime(2023, 9, 24, 10, 55, 53, 21, DateTimeKind.Utc).AddTicks(5736) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 7, 55, 53, 21, DateTimeKind.Utc).AddTicks(5739), new DateTime(2023, 9, 24, 10, 55, 53, 21, DateTimeKind.Utc).AddTicks(5738) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 6, 55, 53, 21, DateTimeKind.Utc).AddTicks(5742), new DateTime(2023, 9, 24, 10, 55, 53, 21, DateTimeKind.Utc).AddTicks(5742) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 5, 55, 53, 21, DateTimeKind.Utc).AddTicks(5745), new DateTime(2023, 9, 24, 10, 55, 53, 21, DateTimeKind.Utc).AddTicks(5744) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Amount");

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

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 8, 43, 56, 257, DateTimeKind.Utc).AddTicks(954), new DateTime(2023, 9, 24, 9, 43, 56, 257, DateTimeKind.Utc).AddTicks(953) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 7, 43, 56, 257, DateTimeKind.Utc).AddTicks(961), new DateTime(2023, 9, 24, 9, 43, 56, 257, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 6, 43, 56, 257, DateTimeKind.Utc).AddTicks(964), new DateTime(2023, 9, 24, 9, 43, 56, 257, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 5, 43, 56, 257, DateTimeKind.Utc).AddTicks(967), new DateTime(2023, 9, 24, 9, 43, 56, 257, DateTimeKind.Utc).AddTicks(966) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 4, 43, 56, 257, DateTimeKind.Utc).AddTicks(969), new DateTime(2023, 9, 24, 9, 43, 56, 257, DateTimeKind.Utc).AddTicks(969) });
        }
    }
}
