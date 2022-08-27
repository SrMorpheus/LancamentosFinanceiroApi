using LancamentosFinanceiroApi.Models.Enum;
using System.Text.Json.Serialization;

namespace LancamentosFinanceiroApi.Models
{
    public class LancamentoVO
    {
        public int Id { get; set; }
        public double Valor { get; set; }

        public EnumDescricaoLancamento DescricaoLancamento { get; set; }

        [JsonIgnore]
        public TipoLancamentoVO? TipoLancamento { get; set; }


        [JsonIgnore]
        public UsuarioVO? UsuarioLacamento { get; set; }

        [JsonIgnore]
        public int TipoLancamentoId { get; set; }

        [JsonIgnore]
        public int UsuarioId { get; set; }



        public void SetDescricaoLancamento()
        {

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