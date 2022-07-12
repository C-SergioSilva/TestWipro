using Solucao.Domain.Entidades;
using System.Threading.Tasks;

namespace Solucao.Domain.Interfaces
{
    public interface ILocadorRepositorio : IRepositorioBase<Locador> 
    {
        Task<Locador> ObterPorCpf(string cpf); 
    }
    
}
