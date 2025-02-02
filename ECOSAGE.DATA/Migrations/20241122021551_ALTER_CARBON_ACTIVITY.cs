﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOSAGE.DATA.Migrations
{
    /// <inheritdoc />
    public partial class ALTER_CARBON_ACTIVITY : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CarbonFootprintId",
                table: "ECOSAGE_ACTIVITY",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CarbonFootprintId",
                table: "ECOSAGE_ACTIVITY",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);
        }
    }
}
