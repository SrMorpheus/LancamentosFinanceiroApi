using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.Repository.Contract
{
    public interface IUsuarioRepository
    {

        public void SalvarUsuario(Usuario usuario);

        public Usuario ObterUsuario(int id);


    }
}
