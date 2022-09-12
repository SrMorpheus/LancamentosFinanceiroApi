using LancamentosFinanceiroApi.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace LancamentosFinanceiroApi.Models
{
    public class LancamentoVO
    {
        public int Id { get; set; }

        private double _valor;

        public string Valor
        {
            get
            {
                var br = new CultureInfo("pt-br");

                return _valor.ToString("C2",br);


            }
            set
            {

                _valor = double.Parse(value);


            }
        }
       

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

        public void SetTipoLancamento()
        {

            switch (DescricaoLancamento)
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