using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.Services.Contract
{
    public interface ILancamentoServices
    {

        void NovoLancamento(LancamentoDTO lancamento, string username);
        LancamentoVO UpdateLancamento(LancamentoDTO lancamento);

        void DeletarLancamento(int id);

        List<LancamentoVO> ListasLancamentosUsuario(int IdUsuario);

        List<LancamentoVO> ListasLancamentosTiposUsuario(int IdUsuarios, int IdTipoLancamento);

        LancamentoVO ObterLancamento(int id);


    }
}
