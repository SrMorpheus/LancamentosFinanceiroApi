using System;
using System.Text.Json.Serialization;

namespace LancamentosFinanceiroApi.Models
{
    public class UsuarioDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string nome { get; set; }

        public string cpf { get; set; }

        public DateTime nascimento { get; set; }

        public string email { get; set; }

        public string senha { get; set; }


        [JsonIgnore]
        public List<LancamentoDTO>? Lancamentos { get; set; }



    }
}
