using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelitinerary.Server.Migrations
{
    /// <inheritdoc />
    public partial class dateTimeNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TimeEnd", "TimeStart" },
                values: new object[] { new DateTime(2024, 2, 6, 20, 5, 5, 867, DateTimeKind.Local).AddTicks(4472), new DateTime(2024, 2, 6, 14, 5, 5, 867, DateTimeKind.Local).AddTicks(4460) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TimeEnd", "TimeStart" },
                values: new object[] { new DateTime(2024, 2, 6, 20, 3, 57, 95, DateTimeKind.Local).AddTicks(8189), new DateTime(2024, 2, 6, 14, 3, 57, 95, DateTimeKind.Local).AddTicks(8176) });
        }
    }
}
