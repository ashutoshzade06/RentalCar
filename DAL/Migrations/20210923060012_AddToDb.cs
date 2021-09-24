using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    License = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Fuel_Type = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Driver_License = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Postal_Code = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    Phone_No = table.Column<string>(type: "nvarchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Driver_License);
                });

            migrationBuilder.CreateTable(
                name: "Rented_Cars",
                columns: table => new
                {
                    Rented_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    From_Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To_Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odometer_Before = table.Column<int>(type: "int", nullable: false),
                    Odometer_After = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Car_CarID = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Driver_License = table.Column<string>(type: "nvarchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rented_Cars", x => x.Rented_Id);
                    table.ForeignKey(
                        name: "FK_Rented_Cars_Cars_Car_CarID",
                        column: x => x.Car_CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rented_Cars_Customers_Driver_License",
                        column: x => x.Driver_License,
                        principalTable: "Customers",
                        principalColumn: "Driver_License",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rented_Cars_Car_CarID",
                table: "Rented_Cars",
                column: "Car_CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Rented_Cars_Driver_License",
                table: "Rented_Cars",
                column: "Driver_License");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rented_Cars");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
