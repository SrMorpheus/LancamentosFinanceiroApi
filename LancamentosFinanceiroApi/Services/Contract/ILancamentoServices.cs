using LancamentosFinanceiroApi.DataObjects.VO;
using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.Services.Contract
{
    public interface ILancamentoServices
    {

        void NovoLancamento(LancamentoDTO lancamento, string username);
        LancamentoVO UpdateLancamento(LancamentoDTO lancamento);

        bool DeletarLancamento(int id);

        LancamentosPorTipoVO ListasLancamentosUsuario(string username);

        List<LancamentoVO> ListasLancamentosTiposUsuario(int IdUsuarios, int IdTipoLancamento);

         LancamentosPorTipoVO ListasLancamentosTipos(string username, int IdTipoLancamento);

        LancamentoVO ObterLancamento(int id);


    }
}
