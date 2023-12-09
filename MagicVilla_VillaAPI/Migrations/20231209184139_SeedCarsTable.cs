using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCarsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Cars",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CountryOfOrigin", "CreatedDate", "Description", "MaxSpeed", "Model", "Price" },
                values: new object[,]
                {
                    { 1, "Rolls Royce", "England", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "You already know what it is", 300, "Phantom", 1000000f },
                    { 2, "Tesla", "US", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "You already know what it is", 200, "S", 200000f },
                    { 3, "S", "England", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "You already know what it is", 500, "Trash", 55f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
