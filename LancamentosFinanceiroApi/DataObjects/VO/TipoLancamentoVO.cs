using LancamentosFinanceiroApi.Models.Enum;

namespace LancamentosFinanceiroApi.Models
{
    public class TipoLancamentoVO
    {
        public int Id { get; set; }

        public EnumDescricaoLancamento DescricaoLancamento { get; set; }

        public List<LancamentoVO>? Lancamentos { get; set; }

    }
}
