using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopFlickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeOrderHeaderandOrderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carrier",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "City",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "PaymentDueDate",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "ShippingDate",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "State",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "OrderHeader");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "OrderDetails",
                newName: "Quantity");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderDetails",
                newName: "Count");

            migrationBuilder.AddColumn<string>(
                name: "Carrier",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDueDate",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShippingDate",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrackingNumber",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
