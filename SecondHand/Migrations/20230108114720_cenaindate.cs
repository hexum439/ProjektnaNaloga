using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecondHand.Migrations
{
    public partial class cenaindate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "cena",
                table: "Obutevs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Oblacilas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "cena",
                table: "Oblacilas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cena",
                table: "Obutevs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Oblacilas");

            migrationBuilder.DropColumn(
                name: "cena",
                table: "Oblacilas");
        }
    }
}
