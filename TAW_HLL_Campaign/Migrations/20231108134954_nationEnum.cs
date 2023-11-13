using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAW_HLL_Campaign.Migrations
{
    public partial class nationEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingID",
                table: "Maneuver");

            migrationBuilder.DropColumn(
                name: "RoadID",
                table: "Maneuver");

            migrationBuilder.AddColumn<int>(
                name: "Nation",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nation",
                table: "Team");

            migrationBuilder.AddColumn<int>(
                name: "BuildingID",
                table: "Maneuver",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoadID",
                table: "Maneuver",
                type: "int",
                nullable: true);
        }
    }
}
