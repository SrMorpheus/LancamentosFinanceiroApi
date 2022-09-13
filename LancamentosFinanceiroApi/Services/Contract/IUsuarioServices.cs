using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.Services.Contract
{
    public interface IUsuarioServices

    {

        public  Task<bool> SalvarUsuario(UsuarioDTO usuarioDTO);

        public UsuarioVO ObterUsuario(int id);

        public UsuarioVO ObterUsuario(string userName);

        public UsuarioVO UpdateUsuario(Usuario usuario);


    }
}
