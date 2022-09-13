using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Services.Contract;
using LancamentosFinanceiroApi.Services.Validadores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LancamentosFinanceiroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        
        private readonly IUsuarioServices _usuarioServices ;

        private readonly ValidadorCadUsuario _validadoCadUsuario;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;

            _validadoCadUsuario = new ValidadorCadUsuario();
        }



        // POST api/<UsuarioController>
        [HttpPost]
        [ProducesResponseType((422), Type = typeof(Erro))]
        [ProducesResponseType((200), Type = typeof(Response))]
        [ProducesResponseType((404), Type = typeof(Response))]
        public async Task <ActionResult>  CadrastrarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            

            if (usuarioDTO == null)
            {

                Erro erro1 = new("Status Code 404", "Nenhum campo preenchido!");

                return BadRequest(erro1);
            
            } 

            bool validaEntrada = _validadoCadUsuario.ValidaEntradaCad(usuarioDTO);

            if(validaEntrada)
            {

                bool valida = await _usuarioServices.SalvarUsuario(usuarioDTO);

                if (valida)
                {

                    Response resposta = new Response("Status Code 200", "Usuário cadastrado!");

                    return Ok(resposta);

                }

                Erro erro = new Erro("Status Code 404", "Já existe esse cpf ou email na base de dados");

                return BadRequest(erro);

            }

            return  UnprocessableEntity(_validadoCadUsuario.Error());



        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(UsuarioVO))]
        [ProducesResponseType((404), Type = typeof(Erro))]


        public  IActionResult GetUsuario(int id)
        {

            var usuario =  _usuarioServices.ObterUsuario(id);


            if (usuario == null)
            {
                Erro erro = new Erro("Status Code 404", "Usuário não existe!");

                return NotFound(erro);
            }


            return Ok(usuario);

        }



        [Authorize("Bearer")]
        [HttpGet()]
        [ProducesResponseType((200), Type = typeof(UsuarioVO))]
        [ProducesResponseType((404), Type = typeof(Erro))]
        public IActionResult InformacaoUsuario()
        {

           var username = User.Identity.Name;

           var usuario = _usuarioServices.ObterUsuario(username);

            if (usuario == null)
            {
                Erro erro = new Erro("Status Code 404", "Usuário não existe!");

                return NotFound(erro);
            }

            return Ok(usuario);

        }


    }
}
