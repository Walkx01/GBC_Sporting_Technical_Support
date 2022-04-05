using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A1.Migrations
{
    public partial class tada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "country",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Incidents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Bolivia" },
                    { 2, "Cameroon" }
                });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 1,
                columns: new[] { "dateClosed", "dateOpened" },
                values: new object[] { new DateTime(2022, 4, 4, 20, 20, 32, 478, DateTimeKind.Local).AddTicks(6580), new DateTime(2022, 4, 4, 20, 20, 32, 478, DateTimeKind.Local).AddTicks(6581) });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 2,
                columns: new[] { "dateClosed", "dateOpened" },
                values: new object[] { new DateTime(2022, 4, 4, 20, 20, 32, 478, DateTimeKind.Local).AddTicks(6585), new DateTime(2022, 4, 4, 20, 20, 32, 478, DateTimeKind.Local).AddTicks(6587) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "releaseDate",
                value: new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "releaseDate",
                value: new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "releaseDate",
                value: new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "customerID",
                keyValue: 1,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "customerID",
                keyValue: 2,
                column: "CountryId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Countries_CountryId",
                table: "Customers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Countries_CountryId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CountryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "customerID",
                keyValue: 1,
                column: "country",
                value: "Canada");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "customerID",
                keyValue: 2,
                column: "country",
                value: "Cambodia");

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 1,
                columns: new[] { "dateClosed", "dateOpened" },
                values: new object[] { new DateTime(2022, 3, 28, 15, 22, 54, 726, DateTimeKind.Local).AddTicks(5030), null });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 2,
                columns: new[] { "dateClosed", "dateOpened" },
                values: new object[] { new DateTime(2022, 3, 28, 15, 22, 54, 726, DateTimeKind.Local).AddTicks(5040), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "releaseDate",
                value: new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "releaseDate",
                value: new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "releaseDate",
                value: new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
