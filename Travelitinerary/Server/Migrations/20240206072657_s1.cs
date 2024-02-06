using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelitinerary.Server.Migrations
{
    /// <inheritdoc />
    public partial class s1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Itineraries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Itineraries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TimeEnd", "TimeStart" },
                values: new object[] { new DateTime(2024, 2, 6, 21, 26, 57, 126, DateTimeKind.Local).AddTicks(3043), new DateTime(2024, 2, 6, 15, 26, 57, 126, DateTimeKind.Local).AddTicks(3042) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Itineraries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Itineraries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TimeEnd", "TimeStart" },
                values: new object[] { new DateTime(2024, 2, 6, 21, 24, 38, 801, DateTimeKind.Local).AddTicks(9947), new DateTime(2024, 2, 6, 15, 24, 38, 801, DateTimeKind.Local).AddTicks(9945) });
        }
    }
}
