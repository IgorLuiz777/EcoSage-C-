using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOSAGE.DATA.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ECOSAGE_USER",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECOSAGE_USER", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ECOSAGE_CARBONFOOTPRINT",
                columns: table => new
                {
                    CarbonFootprintId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TotalEmission = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECOSAGE_CARBONFOOTPRINT", x => x.CarbonFootprintId);
                    table.ForeignKey(
                        name: "FK_ECOSAGE_CARBONFOOTPRINT_ECOSAGE_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "ECOSAGE_USER",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ECOSAGE_ACTIVITY",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Emission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarbonFootprintId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECOSAGE_ACTIVITY", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_ECOSAGE_ACTIVITY_ECOSAGE_CARBONFOOTPRINT_CarbonFootprintId",
                        column: x => x.CarbonFootprintId,
                        principalTable: "ECOSAGE_CARBONFOOTPRINT",
                        principalColumn: "CarbonFootprintId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ECOSAGE_ACTIVITY_ECOSAGE_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "ECOSAGE_USER",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ECOSAGE_ACTIVITY_CarbonFootprintId",
                table: "ECOSAGE_ACTIVITY",
                column: "CarbonFootprintId");

            migrationBuilder.CreateIndex(
                name: "IX_ECOSAGE_ACTIVITY_UserId",
                table: "ECOSAGE_ACTIVITY",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ECOSAGE_CARBONFOOTPRINT_UserId",
                table: "ECOSAGE_CARBONFOOTPRINT",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ECOSAGE_ACTIVITY");

            migrationBuilder.DropTable(
                name: "ECOSAGE_CARBONFOOTPRINT");

            migrationBuilder.DropTable(
                name: "ECOSAGE_USER");
        }
    }
}
