namespace LancamentosFinanceiroApi.Models
{
    public class LancamentoDTO
    {
        public int Id { get; set; }
        public double Valor { get; set;}

        public TipoLancamentoDTO? TipoLancamento { get; set; }

        public UsuarioDTO? UsuarioLacamento { get; set; }

        public int TipoLancamentoId { get; set; }

        public int UsuarioId { get; set; }  


    }
}
