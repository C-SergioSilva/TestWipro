using Solucao.Domain.Entidade_Guid;
using System;

namespace Solucao.Domain.Entidades
{
    public class Locacao : EntidadeDominio
    {
        public Guid FilmeId { get; set; }
        public Filme Filme { get; set; } 

        public string NomeLocador { get; set; }
        public string CpfLocador { get; set; }
        public string Titulofilme { get; set; }
  
        public DateTime DataLocacao { get; set; }
        public DateTime PrevisaoEntrega { get; set; }
        public DateTime? DataDevolucao { get; set; }

    }
}
