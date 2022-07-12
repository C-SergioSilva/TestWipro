using Microsoft.EntityFrameworkCore;
using Solucao.Domain.Entidade_Guid;
using Solucao.Domain.Interfaces;
using Solucao.InfraEstrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucao.InfraEstrutura.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadeDominio
    {
        private readonly ContextoDB _contexto;
        private readonly DbSet<T> _dbSet;
        public RepositorioBase(ContextoDB contexto)
        {         
                _contexto = contexto;
                _dbSet = contexto.Set<T>(); 
        }
        public async Task AdicionarSalvar(T item)
        {
            try
            {
                _dbSet.Add(item);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
        public async Task<T> Atualizar(T item)
        {
            try
            {
                var atualiza = await _dbSet.SingleOrDefaultAsync(a => a.Id.Equals(item.Id));

                if (atualiza == null)
                {
                    return null;
                }

                _contexto.Entry(atualiza).CurrentValues.SetValues(item);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }

            return item;

        }
        public async Task MarcarComoDeletado(T item)
        {
            try
            {
                _dbSet.Add(item);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
        public async Task<T> ObterPorId(Guid id)
        {
            try
            {
                return await _dbSet.SingleOrDefaultAsync(o => o.Id.Equals(id));
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
        public async Task<IEnumerable<T>> ObterTodos()
        {
            try
            {
               return await _dbSet.ToListAsync();
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
        public IQueryable<T> Queryable()
        {
            return _dbSet as IQueryable<T>;
        }
    }
}
