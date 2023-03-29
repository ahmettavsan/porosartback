using Core;
using Core.AbstractRepository;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T :BaseEntity, new()
    {
        protected readonly AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;   
        }
        public async Task Add(T entity)
        {
           await _appDbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
           _appDbContext.Set<T>().Remove(entity);
        }

        public  async Task<T> GetById(int id)
        {
           return  await _appDbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
           return _appDbContext.Set<T>().Where(predicate);
        }
        public IEnumerable<T>GetAll()
        {
            return _appDbContext.Set<T>().AsEnumerable();
        }

        public bool Contains(int id)
        {
            return (_appDbContext.Set<T>().Where(x=>x.Id==id).Count()>0);

        }
    }
}
