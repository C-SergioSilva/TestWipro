using Solucao.Servicos.Servicos_Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solucao.Servicos.Interfaces_Servicos
{
    public interface IFilmeServico
    {
        Task<bool> AdicionarSalvar(LocarFilmeDto filme);
        Task<IEnumerable<FilmeDto>> ObterTodos();
        Task<FilmeDto> obterPorId(Guid id);
        Task<FilmeDto> Atualizar(FilmeDto filme);
        Task<bool> MarcarDeletado(Guid id);
    }
}
