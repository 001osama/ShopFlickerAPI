using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopFlickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedImageUrlinProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 7, 28, 11, 44, 39, 273, DateTimeKind.Local).AddTicks(3761), "none" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 8, 28, 11, 44, 39, 273, DateTimeKind.Local).AddTicks(3813), "none" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 6, 28, 11, 44, 39, 273, DateTimeKind.Local).AddTicks(3826), "none" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 7, 28, 11, 44, 39, 273, DateTimeKind.Local).AddTicks(3829), "none" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImagePath" },
                values: new object[] { new DateTime(2023, 7, 28, 11, 44, 39, 273, DateTimeKind.Local).AddTicks(3835), "none" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

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
    }
}
