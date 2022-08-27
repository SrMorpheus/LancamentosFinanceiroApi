using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.DataObjects.VO
{
    public class LancamentosPorTipoVO
    {

        public long? Quantidade { get; set; }

        public List<LancamentoVO>? Lancamentos { get; set; }



        public LancamentosPorTipoVO() { }

        public LancamentosPorTipoVO(long? quantidade, List<LancamentoVO>? lancamentos)
        {
            Quantidade = quantidade;
            Lancamentos = lancamentos;
        }
    }
}
