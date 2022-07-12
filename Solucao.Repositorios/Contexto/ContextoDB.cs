using Microsoft.EntityFrameworkCore;
using Solucao.Domain.Entidades;
using System.Reflection;

namespace Solucao.InfraEstrutura.Contexto
{
    public class ContextoDB : DbContext
    {
        public DbSet<Locador> Locadores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        public ContextoDB(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
