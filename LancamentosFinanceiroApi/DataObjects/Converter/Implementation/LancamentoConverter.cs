using LancamentosFinanceiroApi.DataObjects.Converter.Contract;
using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.DataObjects.Converter.Implementation
{
    public class LancamentoConverter : ILancamento<LancamentoDTO, Lancamento>, ILancamento<Lancamento, LancamentoVO>, ILancamento<LancamentoVO, LancamentoDTO>
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
               
               DataLancamento = origin.DataLancamento,

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

                Valor = origin.Valor.ToString(),

                DataLancamento = origin.DataLancamento,

                TipoLancamento = _converter.Parse(origin.TipoLancamento),

                TipoLancamentoId = origin.TipoLancamentoId


            };

        }

        public List<LancamentoVO> Parse(List<Lancamento> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public LancamentoDTO Parse(LancamentoVO origin)
        {


            return new LancamentoDTO
            {
                Valor = double.Parse(origin.Valor),

                DataLancamento = origin.DataLancamento,

                TipoLancamentoId = origin.TipoLancamentoId


            };


        }

        public List<LancamentoDTO> Parse(List<LancamentoVO> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }
    }
}
