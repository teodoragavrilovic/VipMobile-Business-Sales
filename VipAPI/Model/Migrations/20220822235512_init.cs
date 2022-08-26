using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PIB = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebPage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfFaundation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "PackageTypes",
                columns: table => new
                {
                    PackageTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageTypes", x => x.PackageTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "THServiceRequests",
                columns: table => new
                {
                    THServiceRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THServiceRequests", x => x.THServiceRequestId);
                    table.ForeignKey(
                        name: "FK_THServiceRequests_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_THServiceRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "TariffPackages",
                columns: table => new
                {
                    TariffPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffPackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvlbMinutes = table.Column<int>(type: "int", nullable: false),
                    AvlbSMS = table.Column<int>(type: "int", nullable: false),
                    AvlbMB = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PackageTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffPackages", x => x.TariffPackageId);
                    table.ForeignKey(
                        name: "FK_TariffPackages_PackageTypes_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalTable: "PackageTypes",
                        principalColumn: "PackageTypeId");
                });

            migrationBuilder.CreateTable(
                name: "THServices",
                columns: table => new
                {
                    THServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicePrice = table.Column<double>(type: "float", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THServices", x => x.THServiceId);
                    table.ForeignKey(
                        name: "FK_THServices_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId");
                });

            migrationBuilder.CreateTable(
                name: "THOffers",
                columns: table => new
                {
                    THOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfirmationDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    THServiceRequestId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THOffers", x => x.THOfferId);
                    table.ForeignKey(
                        name: "FK_THOffers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_THOffers_THServiceRequests_THServiceRequestId",
                        column: x => x.THServiceRequestId,
                        principalTable: "THServiceRequests",
                        principalColumn: "THServiceRequestId");
                });

            migrationBuilder.CreateTable(
                name: "OfferItems",
                columns: table => new
                {
                    OfferItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    THOfferId = table.Column<int>(type: "int", nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    THServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferItems", x => new { x.THOfferId, x.OfferItemId });
                    table.ForeignKey(
                        name: "FK_OfferItems_THOffers_THOfferId",
                        column: x => x.THOfferId,
                        principalTable: "THOffers",
                        principalColumn: "THOfferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferItems_THServices_THServiceId",
                        column: x => x.THServiceId,
                        principalTable: "THServices",
                        principalColumn: "THServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_THServiceId",
                table: "OfferItems",
                column: "THServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffPackages_PackageTypeId",
                table: "TariffPackages",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_THOffers_EmployeeId",
                table: "THOffers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_THOffers_THServiceRequestId",
                table: "THOffers",
                column: "THServiceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_THServiceRequests_ClientId",
                table: "THServiceRequests",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_THServiceRequests_EmployeeId",
                table: "THServiceRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_THServices_ServiceTypeId",
                table: "THServices",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferItems");

            migrationBuilder.DropTable(
                name: "TariffPackages");

            migrationBuilder.DropTable(
                name: "THOffers");

            migrationBuilder.DropTable(
                name: "THServices");

            migrationBuilder.DropTable(
                name: "PackageTypes");

            migrationBuilder.DropTable(
                name: "THServiceRequests");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
