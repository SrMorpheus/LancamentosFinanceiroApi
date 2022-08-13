using LancamentosFinanceiroApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LancamentosFinanceiroApi.Services.Validadores
{
    public class ValidadoCadUsuario
    {

        private readonly Erro _error;

        private readonly EmailAddressAttribute _emailAddress;

        



        public ValidadoCadUsuario ()
        {

            _error = new Erro();

            _emailAddress = new EmailAddressAttribute();

        }


     

        public bool ValidaEntradaCad (UsuarioDTO usuarioDTO)
        {

            if (!ValidaNome(usuarioDTO.nome))
            {
                _error.Codigo = "Status code 422";

                _error.mensagem = "Nome inválido";

                return false;
            }
            if(!ValidaEmail(usuarioDTO.email))
            {
                _error.Codigo = "Status code 422";

                _error.mensagem = "Email inválido";

                return false;

            }

            if (!ValidaCPF(usuarioDTO.cpf))
            {
                _error.Codigo = "Status code 422";

                _error.mensagem = "CPF inválido";

                return false;

            }

            if (!ValidaData(usuarioDTO.nascimento))
            {
                _error.Codigo = "Status code 422";

                _error.mensagem = "Data de Nascimento inválido";

                return false;

            }

            return true;
        }


        private bool ValidaNome(string nome)
        {

            return String.IsNullOrEmpty(nome) || nome.Length >= 5;

        }




        private bool ValidaEmail (string email)
        {

            return String.IsNullOrEmpty(email) || _emailAddress.IsValid(email);



        }


        private bool ValidaCPF(string cpf)
        {


            return String.IsNullOrEmpty(cpf) || cpf.Length == 11;

        }


        private bool ValidaData(DateTime data)
        {

            return data < DateTime.Now; 

        }


        public Erro Error ()

        {
            return _error;

        }


    }
}
