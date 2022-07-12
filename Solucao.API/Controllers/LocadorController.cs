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
    public class LocadorController : ControllerBase
    {
        private readonly ILocadorServico _servico;
        public LocadorController(ILocadorServico servico)
        {
            _servico = servico;
        }
        // GET: api/<LocadorController>
        [HttpGet]
        public async Task<IActionResult> ObterLocadores()
        {
            try
            {
                var locadores = await _servico.ObterTodos();
                if (locadores != null)
                {
                    return Ok(locadores);
                }
                else
                {
                    return Ok(new SucessoDto()
                    {
                        Status = StatusCodes.Status200OK,
                        Sucesso = "Não há Locadores Cadastrados !"
                    });
                }

            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }

        }

        // GET api/<LocadorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterLocadorPorId(Guid id)
        {
            try
            {
                var locador = await _servico.ObterPorId(id);
                if (locador != null)
                {
                    return Ok(locador);
                }
                else
                {
                    return BadRequest(new ErrorsDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Locador Inexistente Verfique os dados e tente novamente!"
                    });
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }


        }

        // POST api/<LocadorController>
        [HttpPost]
        public async Task<IActionResult> AdicionarLocador([FromBody] ClienteDto locador)
        {

            try
            {
                var locadorAdicionado = await _servico.AdicionarSalvar(locador);
                if (!locadorAdicionado)
                {
                    return BadRequest(new ErrorsDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Locador já Cadastrado !"
                    });
                }
                return Ok(new SucessoDto()
                {
                    Status = StatusCodes.Status200OK,
                    Sucesso = "Locador Cadastrado com Sucesso !"
                });

            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

        // PUT api/<LocadorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLocador(Guid id, [FromBody] ClienteDto locacao)  
        {
            try
            {
                var locadorAdicionado = await _servico.ObterPorId(id);

                locadorAdicionado.Nome = locacao.Nome;
                locadorAdicionado.Cpf = locacao.Cpf;
                locadorAdicionado.Endereco = locacao.Endereco;

                var atualizaLocador = _servico.Atualizar(locadorAdicionado);
                if (locadorAdicionado != null)
                {
                    return Ok(new SucessoDto()
                    {
                        Status = StatusCodes.Status200OK,
                        Sucesso = "Locador Atualizado com Sucesso !"
                    });
                }

                return BadRequest(new ErrorsDto()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Falha ao Atualizar Locador, Verfique os dados e tente novamente!"
                });
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
           
        }

        // DELETE api/<LocadorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult>  MarcarComoDeletado(Guid id)
        {
            var deletado = await _servico.MarcarDeletado(id);
            if (!deletado)
            {
                return BadRequest(new ErrorsDto()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Falha ao Deletar o Locador, Verfique os dados e tente novamente!"
                });
            }
            else
            {
                return Ok(new SucessoDto()
                {
                    Status = StatusCodes.Status200OK,
                    Sucesso = "Locador Deletado com Sucesso !"
                });
            }
        }
    }
}
