using LancamentosFinanceiroApi.DataObjects.Converter.Implementation;
using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Repository.Contract;
using LancamentosFinanceiroApi.Services.Contract;

namespace LancamentosFinanceiroApi.Services.Implementations
{
    public class UsuarioServicesImplementations : IUsuarioServices
    {

        private readonly IUsuarioRepository _usuarioRepository;

        private readonly UsuarioConverter _conveter;
        

        public UsuarioServicesImplementations(IUsuarioRepository usuarioRepository)
        {


            _usuarioRepository = usuarioRepository;
            _conveter = new UsuarioConverter();
        }   

        public UsuarioVO ObterUsuario(int id)
        {
            var usuario = _conveter.Parse(_usuarioRepository.ObterUsuario(id));
            usuario.FormatarData();

            return usuario;


        }

        public UsuarioVO ObterUsuario(string userName)
        {
            
            var usuario = _conveter.Parse(_usuarioRepository.ObterUsuarioEmail(userName));

            if(usuario == null) return null;

            usuario.FormatarData();
            return usuario;

        }

        public bool SalvarUsuario(UsuarioDTO usuarioDTO)
        {
           var  result = _usuarioRepository.ObterUsuarioCPF(usuarioDTO.cpf);

            var resultaEmail = _usuarioRepository.ObterUsuarioEmail(usuarioDTO.email);

            if (result == null && resultaEmail == null)
            {

                var usuario = _conveter.Parse(usuarioDTO);

                _usuarioRepository.SalvarUsuario(usuario);

                return true;
                    
            }

            return false;
           


        }
    }
}
