namespace LancamentosFinanceiroApi.Models
{
    public class LancamentoVO
    {
        public int Id { get; set; }
        public double Valor { get; set;}

        public TipoLancamentoVO? TipoLancamento { get; set; }

        public UsuarioVO? UsuarioLacamento { get; set; }

        public int TipoLancamentoId { get; set; }

        public int UsuarioId { get; set; }  


    }
}
