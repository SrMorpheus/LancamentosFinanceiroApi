using LancamentosFinanceiroApi.Models.Enum;
using System.Text.Json.Serialization;

namespace LancamentosFinanceiroApi.Models
{
    public class LancamentoDTO
    {

        [JsonIgnore]
        public int Id { get; set; }
        public double Valor { get; set;}

        public  string LancamentoTipo { get; set; }

        [JsonIgnore]
        public DateTime DataLancamento { get; set; }

        [JsonIgnore]
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

            switch(LancamentoTipo)
            {

                case "Entrada":

                    TipoLancamentoId = 1;
                    break;

                case "Saída":

                    TipoLancamentoId = 2;
                    break;



            }

        }

    }
}
