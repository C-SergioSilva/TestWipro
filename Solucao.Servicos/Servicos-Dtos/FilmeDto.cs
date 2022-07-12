using System;

namespace Solucao.Servicos.Servicos_Dtos
{
    public class FilmeDto
    {
        public Guid Id { get; set; }
        public DateTime Datacriacao { get; set; } = DateTime.Now;
        public bool Deletado { get; set; } = false;
        public string Titulo { get; set; }
        public bool Locado { get; set; } = false;
        public string Status { get; set; } = "Disponivél";
    }

 
}
