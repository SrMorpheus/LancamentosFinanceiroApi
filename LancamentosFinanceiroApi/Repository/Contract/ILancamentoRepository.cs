using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Models.Enum;

namespace LancamentosFinanceiroApi.Repository.Contract
{
    public interface ILancamentoRepository
    {

        void NovoLancamento(Lancamento lancamento, string username);
        Lancamento UpdateLancamento(Lancamento lancamento);

        void DeletarLancamento(int id);

        List<Lancamento> ListasLancamentosUsuario( int IdUsuario);

        List<Lancamento> ListasLancamentosTiposUsuario(int IdUsuarios, int IdTipoLancamento);

        Lancamento ObterLancamento(int id);

     




    }
}
