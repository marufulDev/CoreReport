using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreReport.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reportings",
                columns: table => new
                {
                    SlNo = table.Column<string>(nullable: false),
                    ReportName = table.Column<string>(nullable: true),
                    ReportPath = table.Column<string>(nullable: true),
                    QryType = table.Column<string>(nullable: true),
                    Qryname = table.Column<string>(nullable: true),
                    xmlTableName = table.Column<string>(nullable: true),
                    Para1 = table.Column<string>(nullable: true),
                    Para2 = table.Column<string>(nullable: true),
                    Para3 = table.Column<string>(nullable: true),
                    Para4 = table.Column<string>(nullable: true),
                    MultipleReport = table.Column<bool>(nullable: false),
                    ReportLevel = table.Column<string>(nullable: true),
                    FirstLevel = table.Column<string>(nullable: true),
                    SecondLevel = table.Column<string>(nullable: true),
                    ThirdLevel = table.Column<string>(nullable: true),
                    IsEventLog = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportings", x => x.SlNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reportings");
        }
    }
}
