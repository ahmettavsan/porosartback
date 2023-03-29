using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractManager
{
    public interface IGenericManager<T,TDTO> where T : IEntity where TDTO : IEntity
    {
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        IEnumerable<TDTO> GetAll();
        Task<TDTO> GetById(int id);
        Task Update(TDTO entity);
        Task Delete(TDTO entity);
        Task Add(TDTO entity);
        bool Contains(int id);
    }
}
