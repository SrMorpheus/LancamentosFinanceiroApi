using LancamentosFinanceiroApi.Models.Enum;

namespace LancamentosFinanceiroApi.Models
{
    public class TipoLancamentoDTO
    {
        public int Id { get; set; }

        public EnumDescricaoLancamento DescricaoLancamento { get; set; }

        public List<LancamentoDTO>? Lancamentos { get; set; }

    }
}
