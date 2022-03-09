using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeamlineX.Repositories.Migrations
{
    public partial class AddMeasureSetValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AnglePosition",
                table: "MeasureSet",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Intensity",
                table: "MeasureSet",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "MeasureSet",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "MeasureTime",
                table: "MeasureSet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "MonochromatorPos",
                table: "MeasureSet",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Temperature",
                table: "MeasureSet",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnglePosition",
                table: "MeasureSet");

            migrationBuilder.DropColumn(
                name: "Intensity",
                table: "MeasureSet");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "MeasureSet");

            migrationBuilder.DropColumn(
                name: "MeasureTime",
                table: "MeasureSet");

            migrationBuilder.DropColumn(
                name: "MonochromatorPos",
                table: "MeasureSet");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "MeasureSet");
        }
    }
}
