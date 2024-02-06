using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelitinerary.Server.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TimeEnd", "TimeStart" },
                values: new object[] { new DateTime(2024, 2, 6, 21, 24, 38, 801, DateTimeKind.Local).AddTicks(9947), new DateTime(2024, 2, 6, 15, 24, 38, 801, DateTimeKind.Local).AddTicks(9945) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TimeEnd", "TimeStart" },
                values: new object[] { new DateTime(2024, 2, 6, 20, 41, 28, 216, DateTimeKind.Local).AddTicks(841), new DateTime(2024, 2, 6, 14, 41, 28, 216, DateTimeKind.Local).AddTicks(840) });
        }
    }
}
