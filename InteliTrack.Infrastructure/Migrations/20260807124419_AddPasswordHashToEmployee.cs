using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteliTrack.Infrastructure.Migrations
{
    public partial class AddPasswordHashToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "passwordhash",
                table: "employees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "passwordhash",
                table: "employees");
        }
    }
}
