using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LancamentosFinanceiroApi.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_TipoLancamentos_TipoLancamentoId",
                table: "Lancamentos");

            migrationBuilder.DropColumn(
                name: "LancamentoId",
                table: "Lancamentos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoLancamentoId",
                table: "Lancamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_TipoLancamentos_TipoLancamentoId",
                table: "Lancamentos",
                column: "TipoLancamentoId",
                principalTable: "TipoLancamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_TipoLancamentos_TipoLancamentoId",
                table: "Lancamentos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoLancamentoId",
                table: "Lancamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LancamentoId",
                table: "Lancamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_TipoLancamentos_TipoLancamentoId",
                table: "Lancamentos",
                column: "TipoLancamentoId",
                principalTable: "TipoLancamentos",
                principalColumn: "Id");
        }
    }
}
