using LancamentosFinanceiroApi.Models.Enum;

namespace LancamentosFinanceiroApi.Models
{
    public class TipoLancamento
    {
        public int Id { get; set; }

        public EnumDescricaoLancamento DescricaoLancamento { get; set; }

        public List<Lancamento>? Lancamentos { get; set; }

    }
}
