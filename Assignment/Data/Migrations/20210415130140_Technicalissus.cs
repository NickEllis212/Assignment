using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment.Data.Migrations
{
    public partial class Technicalissus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TechnicalIssue",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assetseffected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalIssue", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnicalIssue");
        }
    }
}
