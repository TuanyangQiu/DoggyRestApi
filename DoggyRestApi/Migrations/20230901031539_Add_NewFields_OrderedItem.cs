using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoggyRestApi.Migrations
{
    public partial class Add_NewFields_OrderedItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartureCity",
                table: "OrderedItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "OrderedItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderedItem",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "OrderedItem",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "OrderedItem",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TravelDays",
                table: "OrderedItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripType",
                table: "OrderedItem",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureCity",
                table: "OrderedItem");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "OrderedItem");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderedItem");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "OrderedItem");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "OrderedItem");

            migrationBuilder.DropColumn(
                name: "TravelDays",
                table: "OrderedItem");

            migrationBuilder.DropColumn(
                name: "TripType",
                table: "OrderedItem");
        }
    }
}
