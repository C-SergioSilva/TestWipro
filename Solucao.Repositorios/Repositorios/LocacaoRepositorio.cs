using Microsoft.EntityFrameworkCore;
using Solucao.Domain.Entidades;
using Solucao.Domain.Interfaces;
using Solucao.InfraEstrutura.Contexto;
using System.Threading.Tasks;

namespace Solucao.InfraEstrutura.Repositorios
{
    public class LocacaoRepositorio : RepositorioBase<Locacao>, ILocacaoRepositorio
    {
        protected readonly DbSet<Locacao> dbSet;
        public LocacaoRepositorio(ContextoDB contexto) : base(contexto) 
        {
            this.dbSet = contexto.Set<Locacao>();
        }
        public async Task<Locacao> ObterFilme(Locacao locacao) 
        {
            var titulofilme = await dbSet.SingleOrDefaultAsync(f => f.Titulofilme.Equals(locacao.Titulofilme));
            return titulofilme;
        }
        public async Task<Locacao> ObterTodosDisponiveis() 
        {
            var listaFilmesdisponiveis = await dbSet.SingleOrDefaultAsync(f => f.Filme.Locado == false);
            return listaFilmesdisponiveis;
        }

    }
}
