using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LancamentosFinanceiroApi.Controllers
{

    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {

        private ILancamentoServices _lancamentoServies;



        public LancamentoController(ILancamentoServices lancamentoServies)
        {


            _lancamentoServies = lancamentoServies;
        }



        [HttpPost]

        public ActionResult NovoLancamento( LancamentoDTO lancamento)
        {
            lancamento.SetTipoLancamento();

            var username = User.Identity.Name;

            _lancamentoServies.NovoLancamento(lancamento, username);

            return Ok();

        }


    }
}
