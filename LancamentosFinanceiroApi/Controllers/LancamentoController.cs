﻿using LancamentosFinanceiroApi.DataObjects.VO;
using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Models.Enum;
using LancamentosFinanceiroApi.Services.Contract;
using LancamentosFinanceiroApi.Services.Validadores;
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

        private ValidadorLancamento _validador;



        public LancamentoController(ILancamentoServices lancamentoServies)
        {

            _lancamentoServies = lancamentoServies;
        }



        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Response))]
        [ProducesResponseType((422), Type = typeof(Erro))]

        public ActionResult NovoLancamento(LancamentoDTO lancamento)
        {
            bool boolReposta = _validador.ValidarLancamento(lancamento);

            if(boolReposta)
            {
                lancamento.DataLancamento = DateTime.Now;
                lancamento.SetTipoLancamento();

                var username = User.Identity.Name;
                _lancamentoServies.NovoLancamento(lancamento, username);

                Response response = new Response("Status code 200", "Lançamento realizado com sucesso!");

                return Ok(response);

            }

            return UnprocessableEntity(_validador.Error());


        }


        [HttpGet("single/{IdLancamento}")]
       
        [ProducesResponseType((200), Type = typeof(LancamentoVO))]
        [ProducesResponseType((404), Type = typeof(Erro))]

        public ActionResult ObterLancamento(int IdLancamento)
        {
            var lancamento = _lancamentoServies.ObterLancamento(IdLancamento);


            if(lancamento == null)
            {

                Erro erro = new Erro("Statuc code 404","Não Existe esse Lancamento");

                return BadRequest(erro);

            }

            return Ok(lancamento); 

        }


      

        [HttpGet("{TipoLancamento}")]
        [ProducesResponseType((200), Type = typeof(LancamentosPorTipoVO))]
        [ProducesResponseType((404), Type = typeof(Erro))]
        public ActionResult ListarLancamentosPorTipo(EnumDescricaoLancamento tipoLancamento)
        {
            var username = User.Identity.Name;

            var lancamentos = _lancamentoServies.ListasLancamentosTipos(username, (int)tipoLancamento);


            if (lancamentos == null)
            {

                Erro erro = new Erro("Status Code 404", "Sem lancamentos para esse parâmetros");


                return BadRequest(erro);

            }


            return Ok(lancamentos);

        }


        [HttpGet]
        [ProducesResponseType((200), Type = typeof(LancamentosPorTipoVO))]
        [ProducesResponseType((404), Type = typeof(Erro))]
        public ActionResult ListarLancamentos()
        {
            var username = User.Identity.Name;

            var lancamentos = _lancamentoServies.ListasLancamentosUsuario(username);


            if (lancamentos == null)
            {

                Erro erro = new Erro("Status Code 404", "Sem lancamentos");


                return BadRequest(erro);

            }


            return Ok(lancamentos);

        }


    }
}
