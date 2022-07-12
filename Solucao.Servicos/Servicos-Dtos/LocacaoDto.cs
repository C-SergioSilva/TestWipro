using System;

namespace Solucao.Servicos.Servicos_Dtos
{
    public class LocacaoDto
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Deletado { get; set; } = false;

        public string NomeLocador { get; set; }
        public string CpfLocador { get; set; }
        public string Titulofilme { get; set; }

        public Guid LocadorDtoId { get; set; } 
        public LocadorDto Locador { get; set; }
       
       public Guid FilmeId { get; set; }
        public FilmeDto Filme { get; set; }

        public DateTime DataLocacao { get; set; }
        public DateTime PrevisaoEntrega { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
