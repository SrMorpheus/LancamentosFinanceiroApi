using LancamentosFinanceiroApi.DataObjects.Converter.Implementation;
using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Repository.Contract;
using LancamentosFinanceiroApi.Services.Contract;
using LancamentosFinanceiroApi.ServicesAPI.DogAPI.Service;

namespace LancamentosFinanceiroApi.Services.Implementations
{
    public class UsuarioServicesImplementations : IUsuarioServices
    {

        private readonly IUsuarioRepository _usuarioRepository;

        private readonly UsuarioConverter _conveter;


        private readonly GetDog _getDog;

        public UsuarioServicesImplementations(IUsuarioRepository usuarioRepository, GetDog getDog)
        {

            _usuarioRepository = usuarioRepository;
            _getDog = getDog;
            _conveter = new UsuarioConverter();
        }   

        public   UsuarioVO ObterUsuario(int id)
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

        public async Task<bool> SalvarUsuario(UsuarioDTO usuarioDTO)
        {
            var  result = _usuarioRepository.ObterUsuarioCPF(usuarioDTO.cpf);

            var resultaEmail = _usuarioRepository.ObterUsuarioEmail(usuarioDTO.email);

            if (result == null && resultaEmail == null)
            {

                var foto = await _getDog.ProcessDog();

                var usuario = _conveter.Parse(usuarioDTO);

                usuario.FotoPerfil = foto.message;

                _usuarioRepository.SalvarUsuario(usuario);

                return true;
                    
            }

            return false;
           


        }

        public UsuarioVO UpdateUsuario(Usuario usuario)
        {

            var usuariovO = _usuarioRepository.UpdateUsuario(usuario);

            return _conveter.Parse(usuariovO);
            

        }
    }
}
