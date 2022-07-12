using Solucao.Domain.Entidades;
using System.Threading.Tasks;

namespace Solucao.Domain.Interfaces
{
    public interface ILocacaoRepositorio : IRepositorioBase<Locacao>
    {
        Task<Locacao> ObterTodosDisponiveis();
        Task<Locacao> ObterFilme(Locacao filme);

    }
    
}
