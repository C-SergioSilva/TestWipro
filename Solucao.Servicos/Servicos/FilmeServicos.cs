using AutoMapper;
using Solucao.Domain.Entidades;
using Solucao.Domain.Interfaces;
using Solucao.Servicos.Interfaces_Servicos;
using Solucao.Servicos.Servicos_Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solucao.Servicos.Servicos
{
    public class FilmeServicos : IFilmeServico
    {
        private readonly IFilmeRepositorio _repositorio;
        private readonly IMapper _mapper;
        public FilmeServicos(IFilmeRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        public async Task<bool> AdicionarSalvar(LocarFilmeDto filme)
        {
            try
            {
                var analisafilme = _mapper.Map<Filme>(filme);
                var adicionaFilme = await _repositorio.ObterFilme(analisafilme.Titulo); 

                if (adicionaFilme != null)
                {
                    return false;
                }
                else
                {
                    await _repositorio.AdicionarSalvar(analisafilme);
                    return true;
                }
                
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            
        }
        public async Task<FilmeDto> Atualizar(FilmeDto filme)
        {
            try
            {
                var atualizafilme = _mapper.Map<Filme>(filme);
                var retonaFilme  =  await _repositorio.Atualizar(atualizafilme);
                var filmeAtualizado = _mapper.Map<FilmeDto>(retonaFilme);
                return filmeAtualizado;
            } 
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
        public async Task<bool> MarcarDeletado(Guid id)
        {

            try
            {
                var filme = await _repositorio.ObterPorId(id);
                if(filme.Locado)
                {
                    return false;
                }
                else
                {
                    filme.Deletado = true;
                    await _repositorio.Atualizar(filme);
                    return true;
                }   
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public async Task<FilmeDto> obterPorId(Guid id)
        {
            try
            {
                var filme = await _repositorio.ObterPorId(id);
                var filmeObtido = _mapper.Map<FilmeDto>(filme);
                return filmeObtido;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            
        }
        public async Task<IEnumerable<FilmeDto>> ObterTodos()
        {
            var listaFilmes = await _repositorio.ObterTodos();
            var retornaListaFilmes = _mapper.Map<IEnumerable<FilmeDto>>(listaFilmes);
            return retornaListaFilmes;
        } 
    }
}
