using System;
using System.Text.Json.Serialization;

namespace LancamentosFinanceiroApi.Models
{
    public class UsuarioVO
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Nascimento { get; set; }

        [JsonIgnore]
        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Senha { get; set; }

        [JsonIgnore]
        public List<LancamentoVO>? Lancamentos { get; set; }



      

        public  void FormatarData()
        {
            Nascimento = DataNascimento.ToString("yyyy-MM-dd");

            

        }


    }
}
