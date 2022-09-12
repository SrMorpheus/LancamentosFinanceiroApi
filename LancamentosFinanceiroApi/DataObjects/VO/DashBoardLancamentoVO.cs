using System.Globalization;

namespace LancamentosFinanceiroApi.DataObjects.VO
{
    public class DashBoardLancamentoVO
    {


        private double _saldoLancamentoTotal;

        private double _saldoLancamentoEntrada;

        private double _saldoLancamentoSaida;

        public ulong QuantidadeTotal { get; set; }  
        public ulong QuantidadeEntrada {get ; set ;}
        public ulong QuantidadeSaida { get; set; }

        public string SaldoLancamentoTotal 
        { 
            get
            {

                var br = new CultureInfo("pt-br");

                return _saldoLancamentoTotal.ToString("C2", br);

            } 
            set
            
            {

                _saldoLancamentoTotal = double.Parse(value);
            
            } 
        
        }
        
        public string SaldoLancamentoEntrada { 
            get
            {

                var br = new CultureInfo("pt-br");

                return _saldoLancamentoEntrada.ToString("C2", br);


            } set 
            
            {

                _saldoLancamentoEntrada = double.Parse(value);

            }
        }
    
        public string SaldoLancamentoSaida { 
            
            get 
            {

                var br = new CultureInfo("pt-br");

                return _saldoLancamentoSaida.ToString("C2", br);


            } set 
            
            {

                _saldoLancamentoSaida = double.Parse(value);


            }


        }


        public DashBoardLancamentoVO(ulong quantidadeTotal, ulong quantidadeEntrada, ulong quantidadeSaida, string saldoLancamentoTotal, string saldoLancamentoEntrada, string saldoLancamentoSaida)
        {
            QuantidadeTotal = quantidadeTotal;
            QuantidadeEntrada = quantidadeEntrada;
            QuantidadeSaida = quantidadeSaida;
            SaldoLancamentoTotal = saldoLancamentoTotal;
            SaldoLancamentoEntrada = saldoLancamentoEntrada;
            SaldoLancamentoSaida = saldoLancamentoSaida;
        }
    }
}
