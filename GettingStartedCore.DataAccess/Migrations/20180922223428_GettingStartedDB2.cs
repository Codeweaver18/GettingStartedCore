using Microsoft.EntityFrameworkCore.Migrations;

namespace GettingStartedCore.DataAccess.Migrations
{
    public partial class GettingStartedDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Tasks",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Tasks");
        }
    }
}
