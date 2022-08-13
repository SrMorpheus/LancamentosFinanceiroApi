namespace LancamentosFinanceiroApi.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        public double Valor { get; set;}

        public TipoLancamento? TipoLancamento { get; set; }

        public Usuario? UsuarioLacamento { get; set; }

        public int TipoLancamentoId { get; set; }

        public int UsuarioId { get; set; }  


    }
}
