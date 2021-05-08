using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "CityEntity",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_CityEntity", x => x.Id); });

            migrationBuilder.CreateTable(
                "DayEntity",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_DayEntity", x => x.Id); });

            migrationBuilder.CreateTable(
                "TicketEntities",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_TicketEntities", x => x.Id); });

            migrationBuilder.CreateTable(
                "TrainEntities",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_TrainEntities", x => x.Id); });

            migrationBuilder.CreateTable(
                "CarriageEntity",
                table => new
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
                        "FK_CarriageEntity_TrainEntities_TrainId",
                        x => x.TrainId,
                        "TrainEntities",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "CitiesTrains",
                table => new
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
                        "FK_CitiesTrains_CityEntity_CityEntityId",
                        x => x.CityEntityId,
                        "CityEntity",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CitiesTrains_TrainEntities_TrainEntityId",
                        x => x.TrainEntityId,
                        "TrainEntities",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "DaysTrains",
                table => new
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
                        "FK_DaysTrains_DayEntity_DayId",
                        x => x.DayId,
                        "DayEntity",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_DaysTrains_TrainEntities_TrainEntityId",
                        x => x.TrainEntityId,
                        "TrainEntities",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SeatEntity",
                table => new
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
                        "FK_SeatEntity_CarriageEntity_CarriageEntityId",
                        x => x.CarriageEntityId,
                        "CarriageEntity",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "CityEntity",
                new[] {"Id", "Name"},
                new object[,]
                {
                    {1, "Kyiv"},
                    {2, "Lviv"},
                    {3, "Zhytomyr"},
                    {4, "Chernivtsi"},
                    {5, "Sumy"}
                });

            migrationBuilder.InsertData(
                "DayEntity",
                new[] {"Id", "Date"},
                new object[,]
                {
                    {1, new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Local)},
                    {2, new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Local)},
                    {3, new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Local)}
                });

            migrationBuilder.InsertData(
                "TrainEntities",
                new[] {"Id", "Number"},
                new object[,]
                {
                    {1, 1},
                    {2, 1}
                });

            migrationBuilder.InsertData(
                "CarriageEntity",
                new[] {"Id", "Class", "Number", "TrainId"},
                new object[,]
                {
                    {1, 1, 1, 1},
                    {2, 2, 2, 1},
                    {3, 2, 1, 2},
                    {4, 4, 2, 2}
                });

            migrationBuilder.InsertData(
                "CitiesTrains",
                new[] {"Id", "CityEntityId", "TrainEntityId"},
                new object[,]
                {
                    {1, 1, 1},
                    {2, 2, 1},
                    {3, 3, 1},
                    {4, 4, 1},
                    {5, 1, 2},
                    {6, 3, 2},
                    {7, 5, 2}
                });

            migrationBuilder.InsertData(
                "DaysTrains",
                new[] {"Id", "DayId", "TrainEntityId"},
                new object[,]
                {
                    {1, 1, 1},
                    {2, 2, 1},
                    {3, 3, 1},
                    {4, 1, 2},
                    {5, 3, 2}
                });

            migrationBuilder.InsertData(
                "SeatEntity",
                new[] {"Id", "CarriageEntityId", "IsTaken", "Number"},
                new object[,]
                {
                    {1, 1, false, 1},
                    {2, 1, false, 2},
                    {3, 1, false, 3},
                    {4, 2, false, 1},
                    {5, 2, false, 2},
                    {6, 2, false, 3},
                    {7, 3, false, 1},
                    {8, 3, false, 2},
                    {9, 3, false, 3},
                    {10, 4, false, 1},
                    {11, 4, false, 2},
                    {12, 4, false, 3}
                });

            migrationBuilder.CreateIndex(
                "IX_CarriageEntity_TrainId",
                "CarriageEntity",
                "TrainId");

            migrationBuilder.CreateIndex(
                "IX_CitiesTrains_CityEntityId",
                "CitiesTrains",
                "CityEntityId");

            migrationBuilder.CreateIndex(
                "IX_CitiesTrains_TrainEntityId",
                "CitiesTrains",
                "TrainEntityId");

            migrationBuilder.CreateIndex(
                "IX_DaysTrains_DayId",
                "DaysTrains",
                "DayId");

            migrationBuilder.CreateIndex(
                "IX_DaysTrains_TrainEntityId",
                "DaysTrains",
                "TrainEntityId");

            migrationBuilder.CreateIndex(
                "IX_SeatEntity_CarriageEntityId",
                "SeatEntity",
                "CarriageEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "CitiesTrains");

            migrationBuilder.DropTable(
                "DaysTrains");

            migrationBuilder.DropTable(
                "SeatEntity");

            migrationBuilder.DropTable(
                "TicketEntities");

            migrationBuilder.DropTable(
                "CityEntity");

            migrationBuilder.DropTable(
                "DayEntity");

            migrationBuilder.DropTable(
                "CarriageEntity");

            migrationBuilder.DropTable(
                "TrainEntities");
        }
    }
}