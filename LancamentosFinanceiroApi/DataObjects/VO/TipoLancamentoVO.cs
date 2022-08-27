using LancamentosFinanceiroApi.Models.Enum;
using System.Text.Json.Serialization;

namespace LancamentosFinanceiroApi.Models
{
    public class TipoLancamentoVO
    {
        public int Id { get; set; }

        public EnumDescricaoLancamento DescricaoLancamento { get; set; }

        [JsonIgnore]
        public List<LancamentoVO>? Lancamentos { get; set; }

    }
}
