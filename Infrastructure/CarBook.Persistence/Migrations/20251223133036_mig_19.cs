using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DropOffDate",
                table: "Reservations",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "DropOffTime",
                table: "Reservations",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<DateOnly>(
                name: "PickUpDate",
                table: "Reservations",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "PickUpTime",
                table: "Reservations",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    ReservationID = table.Column<int>(type: "int", nullable: false),
                    PickUpLocationID = table.Column<int>(type: "int", nullable: false),
                    DropUpLocationID = table.Column<int>(type: "int", nullable: false),
                    PickUpDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DropOffDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PickUpTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    DropOffTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    PickUpDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropOffDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID");
                    table.ForeignKey(
                        name: "FK_Rentals_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ReservationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AppUserID",
                table: "Reservations",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarID",
                table: "Rentals",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_ReservationID",
                table: "Rentals",
                column: "ReservationID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AppUsers_AppUserID",
                table: "Reservations",
                column: "AppUserID",
                principalTable: "AppUsers",
                principalColumn: "AppUserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AppUsers_AppUserID",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_AppUserID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DropOffDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DropOffTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PickUpDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PickUpTime",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustormerMail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "RentACarProcesses",
                columns: table => new
                {
                    RentACarProcessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    DropOffDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DropOffDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropOffTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    DropUpLocation = table.Column<int>(type: "int", nullable: false),
                    PickUpDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PickUpDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickUpLocation = table.Column<int>(type: "int", nullable: false),
                    PickUpTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentACarProcesses", x => x.RentACarProcessID);
                    table.ForeignKey(
                        name: "FK_RentACarProcesses_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentACarProcesses_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentACarProcesses_CarID",
                table: "RentACarProcesses",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_RentACarProcesses_CustomerID",
                table: "RentACarProcesses",
                column: "CustomerID");
        }
    }
}
