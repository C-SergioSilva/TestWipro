using Solucao.Servicos.Servicos_Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solucao.Servicos.Interfaces_Servicos
{
    public interface ILocadorServico
    {
        Task<bool> AdicionarSalvar(ClienteDto locador); 
        Task<IEnumerable<LocadorDto>> ObterTodos();
        Task<LocadorDto> ObterPorId(Guid id);
        Task<LocadorDto> Atualizar(LocadorDto locador);  
        Task<bool> MarcarDeletado(Guid id); 
    }
}
