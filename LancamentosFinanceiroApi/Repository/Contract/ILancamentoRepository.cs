using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Models.Enum;

namespace LancamentosFinanceiroApi.Repository.Contract
{
    public interface ILancamentoRepository
    {

        void NovoLancamento(Lancamento lancamento, string username);
        Lancamento UpdateLancamento(Lancamento lancamento);

        void DeletarLancamento(int id);

        List<Lancamento> ListasLancamentosUsuario(string username);

        List<Lancamento> ListasLancamentosTiposUsuario(int IdUsuarios, int IdTipoLancamento);

        List<Lancamento> ListasLancamentosTiposUsuario(string username, int IdTipoLancamento);

        Lancamento ObterLancamento(int id);

     




    }
}
