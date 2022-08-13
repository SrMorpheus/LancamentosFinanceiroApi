using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.Services.Contract
{
    public interface IUsuarioServices

    {

        public bool SalvarUsuario(UsuarioDTO usuarioDTO);

        public UsuarioVO ObterUsuario(int id);

        public UsuarioVO ObterUsuario(string cpf);


    }
}
