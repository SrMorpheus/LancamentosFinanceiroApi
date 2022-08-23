using LancamentosFinanceiroApi.DataObjects.Converter.Implementation;
using LancamentosFinanceiroApi.DataObjects.VO;
using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LancamentosFinanceiroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {

            _loginService = loginService;

        }

        [HttpPost]

        [Route("signin")]
        [ProducesResponseType((404), Type = typeof(Erro))]
        [ProducesResponseType((401), Type = typeof(Erro))]
        [ProducesResponseType((200), Type = typeof(TokenVO))]
        public IActionResult Signin([FromBody] LoginDTO login)
        {

            if (login == null)
            {

                Erro erro = new Erro("Status Code 404", "Ivalid client request");

                return BadRequest(erro);
            }

            var token = _loginService.ValidateCredentials(login);

            if (token == null) 
            {
                Erro erro = new Erro("Status Code 401", "Autenticação inválida!");

                return Unauthorized(erro);

            } 

            return Ok(token);


        }

        [HttpPost]
        [Route("refresh")]
        [ProducesResponseType((200), Type = typeof(TokenVO))]
        [ProducesResponseType((404), Type = typeof(Erro))]
        public IActionResult Refresh([FromBody] TokenDTO tokenDto)
        {

            if (tokenDto is null) 
            {

                Erro erro = new Erro("Status Code 404", "Ivalid client request");

                return BadRequest(erro);

            }

            TokenConverter converter = new TokenConverter();

            var token = _loginService.ValidateCredentials(converter.Parse( tokenDto));

            if (token == null)
            {

                Erro erro = new Erro("Status Code 404", "Ivalid client request");

                return BadRequest(erro);

            } 

            return Ok(token);


        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        [ProducesResponseType((404), Type = typeof(Erro))]
        public IActionResult Revoke()
        {

            var username = User.Identity.Name;

            var result = _loginService.RevokeToken(username);

            if (!result) 
            {

                Erro erro = new Erro("Status Code 404", "Ivalid client request");

                return BadRequest(erro);


            } 

            return NoContent();

        }

    }
}
