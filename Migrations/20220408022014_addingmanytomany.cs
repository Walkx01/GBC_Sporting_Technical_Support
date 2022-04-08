using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A1.Migrations
{
    public partial class addingmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "state",
                table: "Customers",
                type: "nvarchar(51)",
                maxLength: 51,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "postCode",
                table: "Customers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Customers",
                type: "nvarchar(51)",
                maxLength: 51,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Customers",
                type: "nvarchar(51)",
                maxLength: 51,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Customers",
                type: "nvarchar(51)",
                maxLength: 51,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "Customers",
                type: "nvarchar(51)",
                maxLength: 51,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "Customers",
                type: "nvarchar(51)",
                maxLength: 51,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => new { x.customerId, x.productId });
                    table.ForeignKey(
                        name: "FK_Registrations_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 1,
                columns: new[] { "dateClosed", "dateOpened" },
                values: new object[] { new DateTime(2022, 4, 7, 22, 20, 14, 97, DateTimeKind.Local).AddTicks(9944), new DateTime(2022, 4, 7, 22, 20, 14, 97, DateTimeKind.Local).AddTicks(9946) });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 2,
                columns: new[] { "dateClosed", "dateOpened" },
                values: new object[] { new DateTime(2022, 4, 7, 22, 20, 14, 97, DateTimeKind.Local).AddTicks(9950), new DateTime(2022, 4, 7, 22, 20, 14, 97, DateTimeKind.Local).AddTicks(9951) });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_productId",
                table: "Registrations",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.AlterColumn<string>(
                name: "state",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(51)",
                oldMaxLength: 51);

            migrationBuilder.AlterColumn<string>(
                name: "postCode",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(51)",
                oldMaxLength: 51);

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(51)",
                oldMaxLength: 51);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(51)",
                oldMaxLength: 51);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(51)",
                oldMaxLength: 51);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(51)",
                oldMaxLength: 51);

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 1,
                columns: new[] { "dateClosed", "dateOpened" },
                values: new object[] { new DateTime(2022, 4, 7, 16, 13, 38, 27, DateTimeKind.Local).AddTicks(7120), new DateTime(2022, 4, 7, 16, 13, 38, 27, DateTimeKind.Local).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentID",
                keyValue: 2,
                columns: new[] { "dateClosed", "dateOpened" },
                values: new object[] { new DateTime(2022, 4, 7, 16, 13, 38, 27, DateTimeKind.Local).AddTicks(7130), new DateTime(2022, 4, 7, 16, 13, 38, 27, DateTimeKind.Local).AddTicks(7140) });
        }
    }
}
