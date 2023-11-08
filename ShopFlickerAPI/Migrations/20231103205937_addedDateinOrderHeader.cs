using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopFlickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedDateinOrderHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 3, 19, 59, 37, 415, DateTimeKind.Utc).AddTicks(5313), new DateTime(2023, 11, 3, 20, 59, 37, 415, DateTimeKind.Utc).AddTicks(5310) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 3, 18, 59, 37, 415, DateTimeKind.Utc).AddTicks(5324), new DateTime(2023, 11, 3, 20, 59, 37, 415, DateTimeKind.Utc).AddTicks(5323) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 3, 17, 59, 37, 415, DateTimeKind.Utc).AddTicks(5327), new DateTime(2023, 11, 3, 20, 59, 37, 415, DateTimeKind.Utc).AddTicks(5326) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 3, 16, 59, 37, 415, DateTimeKind.Utc).AddTicks(5329), new DateTime(2023, 11, 3, 20, 59, 37, 415, DateTimeKind.Utc).AddTicks(5328) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 3, 15, 59, 37, 415, DateTimeKind.Utc).AddTicks(5332), new DateTime(2023, 11, 3, 20, 59, 37, 415, DateTimeKind.Utc).AddTicks(5331) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "OrderHeader");

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 22, 14, 42, 59, 230, DateTimeKind.Utc).AddTicks(903), new DateTime(2023, 10, 22, 15, 42, 59, 230, DateTimeKind.Utc).AddTicks(898) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 22, 13, 42, 59, 230, DateTimeKind.Utc).AddTicks(919), new DateTime(2023, 10, 22, 15, 42, 59, 230, DateTimeKind.Utc).AddTicks(919) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 22, 12, 42, 59, 230, DateTimeKind.Utc).AddTicks(922), new DateTime(2023, 10, 22, 15, 42, 59, 230, DateTimeKind.Utc).AddTicks(921) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 22, 11, 42, 59, 230, DateTimeKind.Utc).AddTicks(925), new DateTime(2023, 10, 22, 15, 42, 59, 230, DateTimeKind.Utc).AddTicks(924) });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 22, 10, 42, 59, 230, DateTimeKind.Utc).AddTicks(927), new DateTime(2023, 10, 22, 15, 42, 59, 230, DateTimeKind.Utc).AddTicks(927) });
        }
    }
}
