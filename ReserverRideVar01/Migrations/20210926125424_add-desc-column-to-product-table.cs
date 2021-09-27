using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserverRideVar01.Migrations
{
    public partial class adddesccolumntoproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "Products",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "Products");
        }
    }
}
