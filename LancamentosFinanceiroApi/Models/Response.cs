namespace LancamentosFinanceiroApi.Models
{
    public class Response
    {

        public Guid Id { get; set; }

        public string Codigo { get; set; }


        public string Mensagem { get; set; }


        public Response()
        {

            Id = Guid.NewGuid();

        }

        public Response ( string codigo , string mensagem)
        {

            Id = Guid.NewGuid ();

            Mensagem = mensagem;    

            Codigo = codigo;



        }



    }
}
