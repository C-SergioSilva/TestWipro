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
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeServico _servico;
        public FilmeController(IFilmeServico servico)
        {
            _servico = servico;
        }
        // GET: api/<FilmeController>
        [HttpGet]
        public async Task<IActionResult> ObterTodosFilmes()
        {
            try
            {
                var filmes = await _servico.ObterTodos();

                foreach (var item in filmes)
                {
                    if (item.Locado)
                    {
                        item.Status = "Alugado";
                    }
                }

                if(filmes != null)
                {
                    return Ok(filmes);
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

        // GET api/<FilmeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterFilmePorId(Guid id)
        {
            try
            {
                var filme = await _servico.obterPorId(id);
                if (filme.Locado)
                {
                    filme.Status = "Alugado";
                }
                if (filme != null)
                {
                    return Ok(filme);
                }
                else
                {
                    return BadRequest(new ErrorsDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Filme Inexistente Verfique os dados e tente novamente!"
                    });
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
           
        }

        // POST api/<FilmeController>
        [HttpPost]
        public async Task<IActionResult> Adicionarfilme([FromBody] LocarFilmeDto filme) 
        {
            try
            {
                var adicionarFilme = await _servico.AdicionarSalvar(filme);
                if (!adicionarFilme)
                {
                    return BadRequest(new ErrorsDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Já existe um Filme cadastrado com este titulo, Verfique e tente novamente!"
                    });
                }
                else
                {
                    return Ok(new SucessoDto()
                    {
                        Status = StatusCodes.Status200OK,
                        Sucesso = "Filme Cadastrado com Sucesso !"
                    });
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }

        }


        // PUT api/<LocadorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaFilme(Guid id, [FromBody]LocarFilmeDto filme)
        {
            try
            {
                var obterModificacoes = await _servico.obterPorId(id);

                obterModificacoes.Titulo = filme.Titulo;

                var filmeAtualiza = await _servico.Atualizar(obterModificacoes);

                if (filmeAtualiza != null)
                {
                    return Ok(new SucessoDto()
                    {
                        Status = StatusCodes.Status200OK,
                        Sucesso = "Filme Atualizado com Sucesso !"
                    });
                }

                return BadRequest(new ErrorsDto()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Falha ao Atualizar o Filme, Verfique os dados e tente novamente!"
                });
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

        // DELETE api/<FilmeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> MarcaComoDeletado(Guid id) 
        {
            var deletado = await _servico.MarcarDeletado(id);
            if (!deletado)
            {
                return BadRequest(new ErrorsDto()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Falha ao Deletar o filme, Verfique se o mesmo está alugado e tente novamente!"
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
