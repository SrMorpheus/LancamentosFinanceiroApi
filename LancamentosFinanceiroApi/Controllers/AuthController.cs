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



        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>

        [HttpPost]

        [Route("signin")]
        [ProducesResponseType((200), Type = typeof(TokenVO))]
        public IActionResult Signin([FromBody] LoginDTO login)
        {

            if (login == null) return BadRequest("Ivalid client request");

            var token = _loginService.ValidateCredentials(login);

            if (token == null) return Unauthorized();

            return Ok(token);


        }

        [HttpPost]
        [Route("refresh")]
        [ProducesResponseType((200), Type = typeof(TokenVO))]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {

            if (tokenVo is null) return BadRequest("Ivalid client request");

            var token = _loginService.ValidateCredentials(tokenVo);

            if (token == null) return BadRequest("Ivalid client request");

            return Ok(token);


        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]

        public IActionResult Revoke()
        {

            var username = User.Identity.Name;

            var result = _loginService.RevokeToken(username);

            if (!result) return BadRequest("Ivalid client request");

            return NoContent();

        }

    }
}
