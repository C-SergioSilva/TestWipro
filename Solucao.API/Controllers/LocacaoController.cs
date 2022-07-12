using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucao.Servicos.Interfaces_Servicos;
using Solucao.Servicos.Servicos_Dtos;
using System;
using System.Threading.Tasks;

namespace Solucao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoServico _servico;
        public LocacaoController(ILocacaoServico servico)
        {
            _servico = servico;
        }
        // GET: api/<LocacaoController>
        [HttpGet]
        public async Task<IActionResult> ObterLocacoes()
        {
            try
            {
                var locacoes = await _servico.ObterTodos();
                return Ok(locacoes);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            
        }

        // GET api/<LocacaoController>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterLocacaoPorId(Guid id)
        {
            try
            {
                var locacao = await _servico.ObterLocacaoPorId(id);
                return Ok(locacao);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

        // POST api/<LocacaoController>
        [HttpPost]
        public async Task<IActionResult> LocarFilme([FromBody] LocarDto locacao)
        {
            try
            {
                var locarFilme = await _servico.LocarFilme(locacao);
                if (locarFilme)
                {
                    return Ok(new SucessoDto()
                    {
                        Status = StatusCodes.Status200OK,
                        Sucesso = "Filme Locado com Sucesso !"
                    });
                }
                else
                {
                    return BadRequest(new ErrorsDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "O Filme com este titulo já está Locado , Verfique e tente outro !"
                    });
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
           
        }

        // PUT api/<LocacaoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> DevolverFilme(Guid id, [FromBody] DevolucaoDto locacao)
        {
            try
            {
                var devolucao = await _servico.ObterLocacaoPorId(id);
                devolucao.DataDevolucao = locacao.DataDevolucao;

                var encerrarLocacao =  await _servico.DevolverFilme(devolucao);

                if (encerrarLocacao == null)
                {
                    return BadRequest(new ErrorsDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Falha no processo de devolução, Verfique o se o Titulo do Filme está Correto e tente Novamente !"
                    });
                }
                else
                {
                    if (encerrarLocacao.DataDevolucao > encerrarLocacao.PrevisaoEntrega)
                    {
                        return Ok(new SucessoDto()
                        {
                            Status = StatusCodes.Status200OK,
                            Sucesso = "Filme devolvido com Atraso !"
                        });
                    }
                    else
                    {
                        return Ok(new SucessoDto()
                        {
                            Status = StatusCodes.Status200OK,
                            Sucesso = "Filme devolvido Sem Atraso !"
                        });
                    }
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

    }
}
