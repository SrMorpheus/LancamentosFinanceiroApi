using LancamentosFinanceiroApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LancamentosFinanceiroApi.Services.Validadores
{
    public class ValidadorCadUsuario
    {

        private readonly Erro _error;

        private readonly EmailAddressAttribute _emailAddress;

        



        public ValidadorCadUsuario ()
        {

            _error = new Erro();

            _emailAddress = new EmailAddressAttribute();

        }


     

        public bool ValidaEntradaCad (UsuarioDTO usuarioDTO)
        {

            if (!ValidaNome(usuarioDTO.nome))
            {
                _error.Codigo = "Status code 422";

                _error.Mensagem = "Nome inválido";

                return false;
            }
            if(!ValidaEmail(usuarioDTO.email))
            {
                _error.Codigo = "Status code 422";

                _error.Mensagem = "Email inválido";

                return false;

            }

            if (!ValidaCPF(usuarioDTO.cpf))
            {
                _error.Codigo = "Status code 422";

                _error.Mensagem = "CPF inválido";

                return false;

            }

            if (!ValidaData(usuarioDTO.nascimento))
            {
                _error.Codigo = "Status code 422";

                _error.Mensagem = "Data de Nascimento inválido";

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
