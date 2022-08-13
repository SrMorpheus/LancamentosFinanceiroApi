namespace LancamentosFinanceiroApi.Models
{
    public class Erro
    {

        public Guid id { get; set; }

        public string Codigo { get; set; }


        public string mensagem { get; set; }

        
        public Erro ()
        {

            id = Guid.NewGuid();

        }



    }
}
