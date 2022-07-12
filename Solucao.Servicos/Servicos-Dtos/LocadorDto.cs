using System;

namespace Solucao.Servicos.Servicos_Dtos
{
    public class LocadorDto
    {
        public Guid Id { get; set;}
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Deletado { get; set; } = false;
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

    }
}
