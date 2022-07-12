using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucao.Domain.Entidades;

namespace Solucao.InfraEstrutura.Mappings
{
    public class LocadorMap : IEntityTypeConfiguration<Locador>
    {
        public void Configure(EntityTypeBuilder<Locador> builder)
        {
            builder.ToTable("Locador");
            builder.HasQueryFilter(l => !l.Deletado);
        }
    }
}
