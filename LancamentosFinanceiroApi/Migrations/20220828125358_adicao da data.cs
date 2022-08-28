using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LancamentosFinanceiroApi.Migrations
{
    public partial class adicaodadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataLancamento",
                table: "Lancamentos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataLancamento",
                table: "Lancamentos");
        }
    }
}
