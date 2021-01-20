using Microsoft.EntityFrameworkCore.Migrations;

namespace LogApp.Infrastructure.Migrations
{
    public partial class RouteFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Route",
                table: "Imports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Route",
                table: "Exports",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Route",
                table: "Imports");

            migrationBuilder.DropColumn(
                name: "Route",
                table: "Exports");
        }
    }
}
