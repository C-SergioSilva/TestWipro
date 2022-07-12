using Solucao.Servicos.Servicos_Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solucao.Servicos.Interfaces_Servicos
{
    public interface ILocacaoServico
    {
        Task<bool> LocarFilme(LocarDto locacao);
        Task<IEnumerable<LocacaoDto>> ObterTodos();
        Task<LocacaoDto> DevolverFilme(LocacaoDto locacao);   
///*        Task<bool> MarcarDeletado(LocacaoDto locado)*/;
        Task<LocacaoDto> ObterLocacaoPorId(Guid id);
    }
}
