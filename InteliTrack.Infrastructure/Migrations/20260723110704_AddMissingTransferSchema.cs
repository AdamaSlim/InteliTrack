using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteliTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingTransferSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isactive",
                table: "stocks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isactive",
                table: "stocks",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
