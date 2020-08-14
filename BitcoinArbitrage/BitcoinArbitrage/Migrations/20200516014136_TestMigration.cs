using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitcoinArbitrage.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCaptured",
                table: "arbitrageData",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "EURZAR",
                table: "arbitrageData",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "KrakenXBTEUR",
                table: "arbitrageData",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LunoXBTZAR",
                table: "arbitrageData",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PercentageProfitBeforeCost",
                table: "arbitrageData",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCaptured",
                table: "arbitrageData");

            migrationBuilder.DropColumn(
                name: "EURZAR",
                table: "arbitrageData");

            migrationBuilder.DropColumn(
                name: "KrakenXBTEUR",
                table: "arbitrageData");

            migrationBuilder.DropColumn(
                name: "LunoXBTZAR",
                table: "arbitrageData");

            migrationBuilder.DropColumn(
                name: "PercentageProfitBeforeCost",
                table: "arbitrageData");
        }
    }
}
