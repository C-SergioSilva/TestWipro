using Solucao.Domain.Entidade_Guid;

namespace Solucao.Domain.Entidades
{
    public class Filme : EntidadeDominio
    {
        public string Titulo { get; set; }
        public bool Locado { get; set; } = false;

    }
}
