namespace LancamentosFinanceiroApi.Models
{
    public class Erro
    {

        public Guid Id { get; set; }

        public string Codigo { get; set; }


        public string Mensagem { get; set; }

        
        public Erro ()
        {

            Id = Guid.NewGuid();

        }

        public Erro(string codigo , string mensagem)
        {

            Id = Guid.NewGuid();

            Codigo = codigo;    

            Mensagem = mensagem;




        }

    }
}
