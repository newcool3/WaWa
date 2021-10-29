using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserverRideVar01.Migrations
{
    public partial class combinedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityTimezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityPrice = table.Column<int>(type: "int", nullable: false),
                    ActivityLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityNumberLimit = table.Column<int>(type: "int", nullable: true),
                    ActivityDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivityPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IslandId = table.Column<int>(type: "int", nullable: true),
                    ActivityDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Island_IslandId",
                        column: x => x.IslandId,
                        principalTable: "Island",
                        principalColumn: "IslandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderGuid = table.Column<int>(type: "int", nullable: true),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderTimezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTotalPrice = table.Column<int>(type: "int", nullable: true),
                    OrderCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderUpdatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderCustom = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_ActivityOrders_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_IslandId",
                table: "Activities",
                column: "IslandId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityOrders_ActivityId",
                table: "ActivityOrders",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityOrders");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
