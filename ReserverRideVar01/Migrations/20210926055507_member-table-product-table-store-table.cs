using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserverRideVar01.Migrations
{
    public partial class membertableproducttablestoretable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQty = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductCost = table.Column<int>(type: "int", nullable: false),
                    ProductPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorePhone = table.Column<int>(type: "int", nullable: false),
                    StoreAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IslandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
