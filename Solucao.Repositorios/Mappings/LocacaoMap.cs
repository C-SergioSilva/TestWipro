using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucao.Domain.Entidades;

namespace Solucao.InfraEstrutura.Mappings
{
    public class LocacaoMap : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("Locacao");
            builder.HasQueryFilter(l => !l.Deletado);
        }
    }
}
