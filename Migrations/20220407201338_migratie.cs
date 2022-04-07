using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A1.Migrations
{
    public partial class migratie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yearlyPrice = table.Column<double>(type: "float", nullable: false),
                    releaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Technician",
                columns: table => new
                {
                    TechnicianID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technician", x => x.TechnicianID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerID);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    productID = table.Column<int>(type: "int", nullable: false),
                    technicianID = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dateOpened = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentID);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_customerID",
                        column: x => x.customerID,
                        principalTable: "Customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technician_technicianID",
                        column: x => x.technicianID,
                        principalTable: "Technician",
                        principalColumn: "TechnicianID");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Bolivia" },
                    { 2, "Cameroon" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "code", "name", "releaseDate", "yearlyPrice" },
                values: new object[,]
                {
                    { 1, "22N39FD", "Toothbrush", new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), 28.0 },
                    { 2, "383IIFD", "Mug Holder", new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), 32.920000000000002 },
                    { 3, "00SEDR3", "Banana", new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), 392.02999999999997 }
                });

            migrationBuilder.InsertData(
                table: "Technician",
                columns: new[] { "TechnicianID", "email", "name", "phone" },
                values: new object[,]
                {
                    { 1, "rufushasanemail@email.com", "Rufus", "290-292-9332" },
                    { 2, "anthony@email.com", "Anthony", "290-832-2201" },
                    { 3, "michaela@email.com", "Michaela", "290-215-1322" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerID", "CountryId", "address", "city", "email", "firstName", "lastName", "phone", "postCode", "state" },
                values: new object[] { 1, 1, "2040 Bunny Road", "Toronto", "mergitu.m.megersa@gmail.com", "Mergitu", "Megersa", "525-223-9201", "H4A 1H1", "Ontario" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerID", "CountryId", "address", "city", "email", "firstName", "lastName", "phone", "postCode", "state" },
                values: new object[] { 2, 1, "440 Round Avenue", "Phnom Penh", "cookietamam@gmail.com", "Cookie", "Aba Tamam", "456-995-3795", "12100", "Ta Khmau" });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentID", "customerID", "dateClosed", "dateOpened", "description", "productID", "technicianID", "title" },
                values: new object[] { 1, 1, new DateTime(2022, 4, 7, 16, 13, 38, 27, DateTimeKind.Local).AddTicks(7120), new DateTime(2022, 4, 7, 16, 13, 38, 27, DateTimeKind.Local).AddTicks(7120), "Bleep bleep, bloop bloop", 1, 1, "Error launching program" });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentID", "customerID", "dateClosed", "dateOpened", "description", "productID", "technicianID", "title" },
                values: new object[] { 2, 2, new DateTime(2022, 4, 7, 16, 13, 38, 27, DateTimeKind.Local).AddTicks(7130), new DateTime(2022, 4, 7, 16, 13, 38, 27, DateTimeKind.Local).AddTicks(7140), "Bloop bloop, bleep bleep", 2, 2, "Redirect to wrong page" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_customerID",
                table: "Incidents",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_productID",
                table: "Incidents",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_technicianID",
                table: "Incidents",
                column: "technicianID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Technician");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
