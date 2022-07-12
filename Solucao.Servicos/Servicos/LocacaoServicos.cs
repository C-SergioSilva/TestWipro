using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solucao.Domain.Entidades;
using Solucao.Domain.Interfaces;
using Solucao.Servicos.Interfaces_Servicos;
using Solucao.Servicos.Servicos_Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solucao.Servicos.Servicos
{
    public class LocacaoServicos : ILocacaoServico
    {
        private readonly ILocacaoRepositorio _repositorio;
        private readonly ILocadorRepositorio _locadorRepositorio;
        private readonly IFilmeRepositorio _filmeRepositorio;
        private readonly IMapper _mapper;

        public LocacaoServicos(ILocacaoRepositorio repositorio, IMapper mapper, ILocadorRepositorio locador, IFilmeRepositorio filmeRepositorio)
        {
            _repositorio = repositorio;
            _locadorRepositorio = locador;
            _filmeRepositorio = filmeRepositorio;
            _mapper = mapper;
        }
        public async Task<bool> LocarFilme(LocarDto locacao) 
        {
           
            var locar = _mapper.Map<Locacao>(locacao);
            var analisaLocador = await _locadorRepositorio.ObterPorCpf(locar.CpfLocador);
            var analisaFilme = await _filmeRepositorio.ObterFilme(locar.Titulofilme);
   
            
            if (analisaLocador.Cpf != null && analisaFilme.Titulo != null && analisaFilme.Locado == false)
            {
                analisaFilme.Locado = true;
                await _filmeRepositorio.Atualizar(analisaFilme);

                locar.FilmeId = analisaFilme.Id;
                locar.NomeLocador = analisaLocador.Nome;
                locar.CpfLocador = analisaLocador.Cpf;
                locar.Titulofilme = analisaFilme.Titulo;
                

                await _repositorio.AdicionarSalvar(locar);
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public async Task<LocacaoDto> DevolverFilme(LocacaoDto locacao)   
        {

            var devolver = _mapper.Map<Locacao>(locacao);

            var devolverLocacaoFilme = await _filmeRepositorio.ObterPorId(devolver.FilmeId);
          
            if(devolver == null)
            {
                return null;
            }
            else
            {
                devolverLocacaoFilme.Locado = false;
                devolver.Filme = devolverLocacaoFilme;
                devolver.Deletado = true;
                await _repositorio.Atualizar(devolver);

                var retornoLocacao = _mapper.Map<LocacaoDto>(devolver);
                return retornoLocacao;
            }
           
        }
        public async Task<IEnumerable<LocacaoDto>> ObterTodos()
        {
            try
            {
                var listaLocacao = await _repositorio.ObterTodos();
                var locacoes = _mapper.Map<IEnumerable<LocacaoDto>>(listaLocacao);
                return locacoes;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
        public async Task<LocacaoDto> ObterLocacaoPorId(Guid id)
        {
            var obterlocacao = await _repositorio.ObterPorId(id); 
            var locacao = _mapper.Map<LocacaoDto>(obterlocacao);
            return locacao;
        }
    }
}
