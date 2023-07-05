﻿// <auto-generated />
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AboutMe.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecast",
                columns: table => new
                {
                    ForecastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemperatureC = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecast", x => x.ForecastId);
                    table.CheckConstraint("CK_Forecast_Description_AtLeastThreeChars", "LEN([Description]) >= 3");
                    table.CheckConstraint("CK_Forecast_Description_Trimmed", "LTRIM(RTRIM([Description])) = [Description]");
                    table.CheckConstraint("CK_Forecast_TemperatureC_GreaterThanAbsoluteZero", "ISNULL([TemperatureC], 1) >= -273.15");
                });

            migrationBuilder.InsertData(
                table: "Forecast",
                columns: new[] { "ForecastId", "Description", "TemperatureC" },
                values: new object[] { 1, "Balmy", 28.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forecast");
        }
    }
}
