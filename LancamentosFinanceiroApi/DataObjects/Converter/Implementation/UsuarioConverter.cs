using LancamentosFinanceiroApi.DataObjects.Converter.Contract;
using LancamentosFinanceiroApi.Models;

namespace LancamentosFinanceiroApi.DataObjects.Converter.Implementation
{
    public class UsuarioConverter : IUsuario<UsuarioDTO, Usuario>, IUsuario<Usuario, UsuarioVO>
    {
        public Usuario Parse(UsuarioDTO origin)
        {
            if (origin == null) return null;

            return new Usuario
            {

                Nome = origin.nome,

                CPF = origin.cpf,

                DataNascimento = origin.nascimento,

                Email = origin.email,

                Senha = origin.senha



            };

        }

        public List<Usuario> Parse(List<UsuarioDTO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public UsuarioVO Parse(Usuario origin)
        {
            if (origin == null) return null;

            return new UsuarioVO
            {

                Id = origin.Id,

                Nome = origin.Nome,

                CPF = origin.CPF,

                DataNascimento = origin.DataNascimento,

                Email = origin.Email,

                Senha = origin.Senha



            };
        }

        public List<UsuarioVO> Parse(List<Usuario> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
