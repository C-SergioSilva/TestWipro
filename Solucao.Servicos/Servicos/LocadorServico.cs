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
    public class LocadorServico : ILocadorServico
    {
        private readonly ILocadorRepositorio _repositorio;
        private readonly IMapper _mapper; 

        public LocadorServico(ILocadorRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        public async Task<bool> AdicionarSalvar(ClienteDto locador)
        {            
            try
            {
                var dadosLocador = _mapper.Map<Locador>(locador);
                var locCpf = await _repositorio.ObterPorCpf(dadosLocador.Cpf);

                if(locCpf == null)
                {
                    await _repositorio.AdicionarSalvar(dadosLocador);
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
           
        }
        public async Task<LocadorDto> Atualizar(LocadorDto locador)
        {
            try
            {
                var atualizaLocador = _mapper.Map<Locador>(locador);
                var locadorAtualizado = await _repositorio.Atualizar(atualizaLocador);
                var retonaLocadoAtualizado = _mapper.Map<LocadorDto>(locadorAtualizado);
                return retonaLocadoAtualizado;
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
                var locadorMarcadoDeletado = await _repositorio.ObterPorId(id);
                if (locadorMarcadoDeletado != null)
                {
                    locadorMarcadoDeletado.Deletado = true;
                    await _repositorio.Atualizar(locadorMarcadoDeletado);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            
            
        }
        public async Task<LocadorDto> ObterPorId(Guid id)
        {
            try
            {
                var locador = await _repositorio.ObterPorId(id);
                var locadorObtido = _mapper.Map<LocadorDto>(locador);
                return locadorObtido;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            
         }
        public async Task<IEnumerable<LocadorDto>> ObterTodos()
        {
            try
            {
                var listaLocadores = await _repositorio.ObterTodos();
                var retornaTodosLocadores = _mapper.Map<IEnumerable<LocadorDto>>(listaLocadores);
                return retornaTodosLocadores;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            
        }
    }
}
