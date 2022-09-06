using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.Services.Validadores
{
    public class ValidadorLancamento
    {

        private Erro _erro;


        public ValidadorLancamento()
        {

            _erro = new Erro();

        }


        public bool  ValidarLancamento (LancamentoDTO lancamento)
        {

            if(!ValidarValor(lancamento.Valor))
            {

                _erro.Codigo = "Status code 422";
                _erro.Mensagem = "Valor precisa ser maior que 0.";


                return false;


            }
            if(!ValidarTipoLancamento(lancamento.LancamentoTipo))
            {

                _erro.Codigo = "Status code 422";
                _erro.Mensagem = "Tipo de lancamento inválido.";

                return false;

            }

            return true;

        }


        private bool ValidarValor( double valor)
        {

            return valor > 0;


        }


        private bool ValidarTipoLancamento(string tipoLancamento)
        {

            return tipoLancamento == "Entrada" || tipoLancamento == "Saída";


         }

        public Erro Error()

        {
            return _erro;

        }


    }
}
