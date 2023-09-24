using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopFlickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class changedCartModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ShoppingCarts",
                newName: "TotalPrice");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 18, 49, 29, 961, DateTimeKind.Local).AddTicks(5851));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 24, 18, 49, 29, 961, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 24, 18, 49, 29, 961, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 18, 49, 29, 961, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 24, 18, 49, 29, 961, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 12, 49, 29, 961, DateTimeKind.Utc).AddTicks(6425), new DateTime(2023, 9, 24, 13, 49, 29, 961, DateTimeKind.Utc).AddTicks(6423) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 11, 49, 29, 961, DateTimeKind.Utc).AddTicks(6441), new DateTime(2023, 9, 24, 13, 49, 29, 961, DateTimeKind.Utc).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 10, 49, 29, 961, DateTimeKind.Utc).AddTicks(6445), new DateTime(2023, 9, 24, 13, 49, 29, 961, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 9, 49, 29, 961, DateTimeKind.Utc).AddTicks(6448), new DateTime(2023, 9, 24, 13, 49, 29, 961, DateTimeKind.Utc).AddTicks(6447) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 24, 8, 49, 29, 961, DateTimeKind.Utc).AddTicks(6451), new DateTime(2023, 9, 24, 13, 49, 29, 961, DateTimeKind.Utc).AddTicks(6451) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "ShoppingCarts",
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
    }
}
