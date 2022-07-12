using Solucao.Domain.Entidade_Guid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao.Domain.Interfaces
{
    public interface IRepositorioBase<T> where T : EntidadeDominio 
    {
        Task AdicionarSalvar(T item);
        Task<T> Atualizar(T item);
        Task<T> ObterPorId(Guid id);
        Task<IEnumerable<T>> ObterTodos();
        Task MarcarComoDeletado(T item);
        IQueryable<T> Queryable();

    }
}
