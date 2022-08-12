using System;

namespace LancamentosFinanceiroApi.Models
{
    public class Usuario
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public List<Lancamento> Lancamentos { get; set; }



    }
}
