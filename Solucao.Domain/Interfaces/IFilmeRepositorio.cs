using Solucao.Domain.Entidades;
using System.Threading.Tasks;

namespace Solucao.Domain.Interfaces
{
    public interface IFilmeRepositorio : IRepositorioBase<Filme> 
    {
        Task<Filme> ObterFilme(string filme);
    }
    
}
