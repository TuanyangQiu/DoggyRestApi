using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoggyRestApi.Migrations
{
    public partial class Add_MoreFields_LineItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartureCity",
                table: "LineItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "LineItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LineItem",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "LineItem",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "LineItem",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TravelDays",
                table: "LineItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripType",
                table: "LineItem",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureCity",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "TravelDays",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "TripType",
                table: "LineItem");
        }
    }
}
