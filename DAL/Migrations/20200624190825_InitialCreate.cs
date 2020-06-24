using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<long>(nullable: false),
                    Passenger = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    TrainNumber = table.Column<int>(nullable: false),
                    CarriageNumber = table.Column<int>(nullable: false),
                    Seat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarriageEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    Class = table.Column<int>(nullable: false),
                    TrainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarriageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarriageEntity_TrainEntities_TrainId",
                        column: x => x.TrainId,
                        principalTable: "TrainEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitiesTrains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainEntityId = table.Column<int>(nullable: false),
                    CityEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitiesTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitiesTrains_CityEntity_CityEntityId",
                        column: x => x.CityEntityId,
                        principalTable: "CityEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitiesTrains_TrainEntities_TrainEntityId",
                        column: x => x.TrainEntityId,
                        principalTable: "TrainEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaysTrains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayId = table.Column<int>(nullable: false),
                    TrainEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaysTrains_DayEntity_DayId",
                        column: x => x.DayId,
                        principalTable: "DayEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DaysTrains_TrainEntities_TrainEntityId",
                        column: x => x.TrainEntityId,
                        principalTable: "TrainEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    IsTaken = table.Column<bool>(nullable: false),
                    CarriageEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatEntity_CarriageEntity_CarriageEntityId",
                        column: x => x.CarriageEntityId,
                        principalTable: "CarriageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CityEntity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kyiv" },
                    { 2, "Lviv" },
                    { 3, "Zhytomyr" },
                    { 4, "Chernivtsi" },
                    { 5, "Sumy" }
                });

            migrationBuilder.InsertData(
                table: "DayEntity",
                columns: new[] { "Id", "Date" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "TrainEntities",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "CarriageEntity",
                columns: new[] { "Id", "Class", "Number", "TrainId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 1 },
                    { 3, 2, 1, 2 },
                    { 4, 4, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "CitiesTrains",
                columns: new[] { "Id", "CityEntityId", "TrainEntityId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 1, 2 },
                    { 6, 3, 2 },
                    { 7, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "DaysTrains",
                columns: new[] { "Id", "DayId", "TrainEntityId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 1, 2 },
                    { 5, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "SeatEntity",
                columns: new[] { "Id", "CarriageEntityId", "IsTaken", "Number" },
                values: new object[,]
                {
                    { 1, 1, false, 1 },
                    { 2, 1, false, 2 },
                    { 3, 1, false, 3 },
                    { 4, 2, false, 1 },
                    { 5, 2, false, 2 },
                    { 6, 2, false, 3 },
                    { 7, 3, false, 1 },
                    { 8, 3, false, 2 },
                    { 9, 3, false, 3 },
                    { 10, 4, false, 1 },
                    { 11, 4, false, 2 },
                    { 12, 4, false, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarriageEntity_TrainId",
                table: "CarriageEntity",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTrains_CityEntityId",
                table: "CitiesTrains",
                column: "CityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTrains_TrainEntityId",
                table: "CitiesTrains",
                column: "TrainEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DaysTrains_DayId",
                table: "DaysTrains",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_DaysTrains_TrainEntityId",
                table: "DaysTrains",
                column: "TrainEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatEntity_CarriageEntityId",
                table: "SeatEntity",
                column: "CarriageEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitiesTrains");

            migrationBuilder.DropTable(
                name: "DaysTrains");

            migrationBuilder.DropTable(
                name: "SeatEntity");

            migrationBuilder.DropTable(
                name: "TicketEntities");

            migrationBuilder.DropTable(
                name: "CityEntity");

            migrationBuilder.DropTable(
                name: "DayEntity");

            migrationBuilder.DropTable(
                name: "CarriageEntity");

            migrationBuilder.DropTable(
                name: "TrainEntities");
        }
    }
}
