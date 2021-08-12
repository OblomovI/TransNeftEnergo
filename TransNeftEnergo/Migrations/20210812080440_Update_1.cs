using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransNeftEnergo.Migrations
{
    public partial class Update_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "InspectionPeriod",
                table: "VoltageTransformers",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "InspectionPeriod",
                table: "CurrentTransformers",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "InspectionPeriod",
                table: "CurrentMeters",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InspectionPeriod",
                table: "VoltageTransformers");

            migrationBuilder.DropColumn(
                name: "InspectionPeriod",
                table: "CurrentTransformers");

            migrationBuilder.DropColumn(
                name: "InspectionPeriod",
                table: "CurrentMeters");
        }
    }
}
