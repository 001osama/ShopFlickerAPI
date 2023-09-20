using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopFlickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class addUsersToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 20, 22, 36, 35, 160, DateTimeKind.Local).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 20, 22, 36, 35, 160, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 20, 22, 36, 35, 160, DateTimeKind.Local).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 20, 22, 36, 35, 160, DateTimeKind.Local).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 20, 22, 36, 35, 160, DateTimeKind.Local).AddTicks(8551));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9893));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9899));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9903));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "CreatedDate", "Desc", "Name" },
                values: new object[] { 6, 1.49, new DateTime(2023, 7, 19, 0, 23, 49, 318, DateTimeKind.Local).AddTicks(9908), "Crunchy cucumbers for snacking.", "Cucumbers" });
        }
    }
}
