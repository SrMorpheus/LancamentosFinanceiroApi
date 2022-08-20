using LancamentosFinanceiroApi.Models.Enum;
using System.Text.Json.Serialization;

namespace LancamentosFinanceiroApi.Models
{
    public class TipoLancamentoDTO
    {

        [JsonIgnore]
        public int Id { get; set; }

        public EnumDescricaoLancamento DescricaoLancamento { get; set; }

        [JsonIgnore]
        public List<LancamentoDTO>? Lancamentos { get; set; }

    }
}
