using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Services.Contract;
using LancamentosFinanceiroApi.Services.Validadores;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LancamentosFinanceiroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        
        private readonly IUsuarioServices _usuarioServices ;

        private readonly ValidadoCadUsuario _validadoCadUsuario;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;

            _validadoCadUsuario = new ValidadoCadUsuario();
        }



        // POST api/<UsuarioController>
        [HttpPost]
        [ProducesResponseType((422), Type = typeof(Erro))]
        public ActionResult  CadrastrarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest();

            bool validaEntrada = _validadoCadUsuario.ValidaEntradaCad(usuarioDTO);

            if(validaEntrada)
            {

                bool valida = _usuarioServices.SalvarUsuario(usuarioDTO);

                if (valida)
                {

                    return Ok("Salvo Com sucesso");

                }

                return BadRequest("Já existe esse cpf ou email na base de dados");

            }

            return  UnprocessableEntity(_validadoCadUsuario.Error());



        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(UsuarioVO))]
        

        public IActionResult GetUsuario(int id)
        {

            var usuario = _usuarioServices.ObterUsuario(id);


            if (usuario == null)
            {
                return NotFound();
            }


            return Ok(usuario);

        }


    }
}
