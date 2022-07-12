using Microsoft.EntityFrameworkCore;
using Solucao.Domain.Entidades;
using Solucao.Domain.Interfaces;
using Solucao.InfraEstrutura.Contexto;
using System.Threading.Tasks;

namespace Solucao.InfraEstrutura.Repositorios
{
    public class FilmeRepositorio : RepositorioBase<Filme>, IFilmeRepositorio
    {
        protected readonly DbSet<Filme> dbSet;
        public FilmeRepositorio(ContextoDB contexto) : base(contexto)
        {
            this.dbSet = contexto.Set<Filme>();
        }
        public async Task<Filme> ObterFilme(string filme)
        {
            var titulofilme = await dbSet.SingleOrDefaultAsync(f => f.Titulo.Equals(filme));
            return titulofilme;
        }

    }
}
