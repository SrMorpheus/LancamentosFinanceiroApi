using LancamentosFinanceiroApi.DataObjects.Converter.Implementation;
using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Repository.Contract;
using LancamentosFinanceiroApi.Services.Contract;

namespace LancamentosFinanceiroApi.Services.Implementations
{
    public class LancamentoServiceImplementation : ILancamentoServices
    {

        private ILancamentoRepository _repositoryLancamento;

        private LancamentoConverter _converter;


        public LancamentoServiceImplementation( ILancamentoRepository lancamento)
        {

            _repositoryLancamento = lancamento;

            _converter = new LancamentoConverter();

        }


        public void DeletarLancamento(int id)
        {
            throw new NotImplementedException();
        }

        public List<LancamentoVO> ListasLancamentosTiposUsuario(int IdUsuarios, int IdTipoLancamento)
        {
            throw new NotImplementedException();
        }

        public List<LancamentoVO> ListasLancamentosUsuario(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public void NovoLancamento(LancamentoDTO lancamento, string username)
        {

            var lancamentoBd = _converter.Parse(lancamento);

            _repositoryLancamento.NovoLancamento(lancamentoBd, username);


        }

        public LancamentoVO ObterLancamento(int id)
        {
            throw new NotImplementedException();
        }

        public LancamentoVO UpdateLancamento(LancamentoDTO lancamento)
        {
            throw new NotImplementedException();
        }
    }
}
