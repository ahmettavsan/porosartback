using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractRepository
{
    public interface IGenericRepository<T> where T : IEntity
    {
        IQueryable<T> Where(Expression<Func<T,bool>>predicate);
        Task<T> GetById(int id);
        void Update(T entity);
        void Delete(T entity);
        Task Add(T entity);

        IEnumerable<T> GetAll();

        bool Contains(int id);

    }
}
