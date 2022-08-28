using LancamentosFinanceiroApi.Models.Enum;
using System.Text.Json.Serialization;

namespace LancamentosFinanceiroApi.Models
{
    public class LancamentoVO
    {
        public int Id { get; set; }
        public double Valor { get; set; }

        public EnumDescricaoLancamento DescricaoLancamento { get; set; }

        public string Data { get; set; }


        [JsonIgnore]
        public DateTime DataLancamento { get; set; }

        [JsonIgnore]
        public TipoLancamentoVO? TipoLancamento { get; set; }


        [JsonIgnore]
        public UsuarioVO? UsuarioLacamento { get; set; }

        [JsonIgnore]
        public int TipoLancamentoId { get; set; }

        [JsonIgnore]
        public int UsuarioId { get; set; }



        public void SetDescricaoEDataLancamento()
        {
            

            Data = DataLancamento.ToString("yyyy-MM-dd");


            switch (TipoLancamento.DescricaoLancamento)
            {

                case EnumDescricaoLancamento.Entrada:

                    DescricaoLancamento = EnumDescricaoLancamento.Entrada;
                    break;

                case EnumDescricaoLancamento.Saída:

                    DescricaoLancamento = EnumDescricaoLancamento.Saída;
                    break;


            }



        }
    }
}