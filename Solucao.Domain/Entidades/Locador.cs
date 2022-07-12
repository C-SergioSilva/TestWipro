using Solucao.Domain.Entidade_Guid;
using System;

namespace Solucao.Domain.Entidades
{
    public class Locador : EntidadeDominio
    {
        //public Guid LocacaoId { get; set; } 
        //public Locacao Locacao { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
    }
}
