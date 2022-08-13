using System;

namespace LancamentosFinanceiroApi.Models
{
    public class UsuarioVO
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public List<LancamentoVO> Lancamentos { get; set; }



    }
}
