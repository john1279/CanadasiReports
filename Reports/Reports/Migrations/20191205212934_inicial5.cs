using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reports.Migrations
{
    public partial class inicial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractsSent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractsSent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesPersonsPendingTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPersonsPendingTasks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractsSent");

            migrationBuilder.DropTable(
                name: "SalesPersonsPendingTasks");
        }
    }
}
