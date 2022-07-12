using System;

namespace Solucao.Domain.Entidade_Guid
{
    public class EntidadeDominio
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Deletado { get; set; } = false;
    } 
}
