using LancamentosFinanceiroApi.DataObjects.Converter.Contract;
using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.DataObjects.Converter.Implementation
{
    public class LancamentoConverter : ILancamento<LancamentoDTO, Lancamento>, ILancamento<Lancamento, LancamentoVO>
    {

        private readonly TipoLancamentoConverter _converter;

        public LancamentoConverter()
        {

            _converter = new TipoLancamentoConverter();

        }


        public Lancamento Parse(LancamentoDTO origin)
        {
            if (origin == null) return null;


            return new Lancamento
            {
               Valor = origin.Valor,

               TipoLancamento = _converter.Parse(origin.TipoLancamento),

               TipoLancamentoId = origin.TipoLancamentoId


            };

        }

        public List<Lancamento> Parse(List<LancamentoDTO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public LancamentoVO Parse(Lancamento origin)
        {

            if (origin == null) return null;


            return new LancamentoVO
            {
                Id = origin.Id, 

                Valor = origin.Valor,

                TipoLancamento = _converter.Parse(origin.TipoLancamento),

                TipoLancamentoId = origin.TipoLancamentoId


            };

        }

        public List<LancamentoVO> Parse(List<Lancamento> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
