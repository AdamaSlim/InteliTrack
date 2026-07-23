using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteliTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreCityAndPendingModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "stockmovements",
                newName: "movementdate");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "products",
                newName: "unitprice");

            migrationBuilder.AddColumn<DateTime>(
                name: "deliveredat",
                table: "transfers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "requestedbyemployeeid",
                table: "transfers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "stores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdat",
                table: "stores",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "stores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdat",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "employees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deliveredat",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "requestedbyemployeeid",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "address",
                table: "stores");

            migrationBuilder.DropColumn(
                name: "createdat",
                table: "stores");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "stores");

            migrationBuilder.DropColumn(
                name: "createdat",
                table: "products");

            migrationBuilder.DropColumn(
                name: "email",
                table: "employees");

            migrationBuilder.RenameColumn(
                name: "movementdate",
                table: "stockmovements",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "unitprice",
                table: "products",
                newName: "price");
        }
    }
}
