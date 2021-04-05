using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CCNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CardHolderName = table.Column<string>(type: "TEXT", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SecurityNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CCNumber);
                });

            migrationBuilder.CreateTable(
                name: "Docks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Key = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BikeNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RenterEmail = table.Column<string>(type: "TEXT", nullable: false),
                    IsBikeDamaged = table.Column<bool>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    RentDock = table.Column<int>(type: "INTEGER", nullable: false),
                    ReturnDock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rented = table.Column<bool>(type: "INTEGER", nullable: false),
                    DockId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bikes_Docks_DockId",
                        column: x => x.DockId,
                        principalTable: "Docks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Docks",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Docks",
                column: "Id",
                value: 2);

            migrationBuilder.InsertData(
                table: "Docks",
                column: "Id",
                value: 3);

            migrationBuilder.InsertData(
                table: "Docks",
                column: "Id",
                value: 4);

            migrationBuilder.InsertData(
                table: "Docks",
                column: "Id",
                value: 5);

            migrationBuilder.InsertData(
                table: "Docks",
                column: "Id",
                value: 6);

            migrationBuilder.InsertData(
                table: "Docks",
                column: "Id",
                value: 7);

            migrationBuilder.InsertData(
                table: "Docks",
                column: "Id",
                value: 8);

            migrationBuilder.InsertData(
                table: "Docks",
                column: "Id",
                value: 9);

            migrationBuilder.InsertData(
                table: "Docks",
                column: "Id",
                value: 10);

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 11, 1, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 101, 10, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 93, 9, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 92, 9, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 91, 9, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 83, 8, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 82, 8, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 81, 8, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 73, 7, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 72, 7, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 71, 7, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 63, 6, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 62, 6, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 61, 6, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 53, 5, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 52, 5, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 51, 5, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 43, 4, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 42, 4, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 41, 4, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 33, 3, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 32, 3, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 31, 3, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 23, 2, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 22, 2, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 21, 2, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 13, 1, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 12, 1, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 102, 10, false });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "DockId", "Rented" },
                values: new object[] { 103, 10, false });

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_DockId",
                table: "Bikes",
                column: "DockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Docks");
        }
    }
}
