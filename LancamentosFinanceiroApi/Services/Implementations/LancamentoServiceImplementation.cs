using LancamentosFinanceiroApi.DataObjects.Converter.Implementation;
using LancamentosFinanceiroApi.DataObjects.VO;
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

        public LancamentosPorTipoVO ListasLancamentosTipos(string username, int IdTipoLancamento)
        {

           var lancamentos =  _repositoryLancamento.ListasLancamentosTiposUsuario(username, IdTipoLancamento);

           if (lancamentos == null) return null;

            var LancamentosVO = _converter.Parse(lancamentos);

            LancamentosVO.ForEach(L => L.SetDescricaoLancamento());

           LancamentosPorTipoVO lancamentosPorTipo = new LancamentosPorTipoVO(lancamentos.Count(), LancamentosVO);

            return lancamentosPorTipo;


        }

        public LancamentosPorTipoVO ListasLancamentosUsuario( string username)
        {
            var lancamentos = _repositoryLancamento.ListasLancamentosUsuario(username);

            if (lancamentos == null) return null;

            var LancamentosVO = _converter.Parse(lancamentos);

            LancamentosVO.ForEach(L => L.SetDescricaoLancamento());

            LancamentosPorTipoVO lancamentosPorTipo = new LancamentosPorTipoVO(lancamentos.Count(), LancamentosVO);

            return lancamentosPorTipo;
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
