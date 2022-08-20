using LancamentosFinanceiroApi.Models.Enum;
using System.Text.Json.Serialization;

namespace LancamentosFinanceiroApi.Models
{
    public class LancamentoDTO
    {

        [JsonIgnore]
        public int Id { get; set; }
        public double Valor { get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumDescricaoLancamento Lancamento { get; set; }

        [JsonIgnore]
        public TipoLancamentoDTO? TipoLancamento { get; set; }

        [JsonIgnore]
        public UsuarioDTO? UsuarioLacamento { get; set; }

        [JsonIgnore]
        public int TipoLancamentoId { get; set; }

        [JsonIgnore]
        public int UsuarioId { get; set; }  



        public void SetTipoLancamento()
        {

            switch(Lancamento)
            {

                case EnumDescricaoLancamento.Entrada:

                    TipoLancamentoId = 1;
                    break;

                case EnumDescricaoLancamento.Saída:

                    TipoLancamentoId = 2;
                    break;



            }

        }

    }
}
