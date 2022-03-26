using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A1.Migrations
{
    public partial class migrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 1,
                column: "dateClosed",
                value: new DateTime(2022, 3, 25, 18, 13, 58, 464, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 2,
                column: "dateClosed",
                value: new DateTime(2022, 3, 25, 18, 13, 58, 464, DateTimeKind.Local).AddTicks(4760));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 1,
                column: "dateClosed",
                value: new DateTime(2022, 3, 25, 18, 1, 42, 287, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 2,
                column: "dateClosed",
                value: new DateTime(2022, 3, 25, 18, 1, 42, 287, DateTimeKind.Local).AddTicks(9500));
        }
    }
}
