using Microsoft.EntityFrameworkCore;
using Solucao.Domain.Entidades;
using Solucao.Domain.Interfaces;
using Solucao.InfraEstrutura.Contexto;
using System.Threading.Tasks;

namespace Solucao.InfraEstrutura.Repositorios
{
    public class LocadorRepositorio : RepositorioBase<Locador>, ILocadorRepositorio
    {
        protected readonly DbSet<Locador> dbSet;
        public LocadorRepositorio(ContextoDB contexto) : base(contexto) {
            this.dbSet = contexto.Set<Locador>();
        }

        public async Task<Locador> ObterPorCpf(string cpf)
        {

            var locCpf = await dbSet.SingleOrDefaultAsync(l => l.Cpf.Equals(cpf));
            return locCpf;


        }

    }
}
