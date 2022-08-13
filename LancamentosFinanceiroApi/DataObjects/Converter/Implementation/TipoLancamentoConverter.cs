using LancamentosFinanceiroApi.DataObjects.Converter.Contract;
using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.DataObjects.Converter.Implementation
{
    public class TipoLancamentoConverter : ITipoLancamento<TipoLancamentoDTO, TipoLancamento>, ITipoLancamento<TipoLancamento, TipoLancamentoVO>
    {
        public TipoLancamento Parse(TipoLancamentoDTO origin)
        {
             if (origin == null) return null;

            return new TipoLancamento
            {

                Id = origin.Id,

                DescricaoLancamento = origin.DescricaoLancamento


            };
        }

        public List<TipoLancamento> Parse(List<TipoLancamentoDTO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public TipoLancamentoVO Parse(TipoLancamento origin)
        {
            if (origin == null) return null;

            return new TipoLancamentoVO
            {

                Id = origin.Id,

                DescricaoLancamento = origin.DescricaoLancamento


            };
        }

        public List<TipoLancamentoVO> Parse(List<TipoLancamento> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

