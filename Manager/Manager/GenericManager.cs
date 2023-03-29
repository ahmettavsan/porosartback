using AutoMapper;
using Core;
using Core.AbstractManager;
using Core.AbstractRepository;
using Core.DTOs;
using Core.Entities;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Manager
{
    public class GenericManager<T, TDTO> : IGenericManager<T, TDTO> where T : IEntity
        where TDTO
        : IEntity
    {
        private readonly IGenericRepository<T> _genericRepository;
        private readonly IUoW _uOW;
        private readonly IMapper _mapper;
        public GenericManager(IGenericRepository<T> genericRepository, IUoW uOW, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _uOW = uOW;
            _mapper = mapper;
        }
        //public async Task Add(T entity)
        //{
        //    await _genericRepository.Add(entity);
        //    await _uOW.CommitAsync();
        //}

        public async Task Add(TDTO entity)
        {
            var entityDB = _mapper.Map<T>(entity);
            await _genericRepository.Add(entityDB);
            await _uOW.CommitAsync();
        }

        //public async Task Delete(T entity)
        //{
        //    _genericRepository.Delete(entity);
        //    await _uOW.CommitAsync();


        //}

        public async Task Delete(TDTO entity)
        {
            var entityDB = _mapper.Map<T>(entity);
            _genericRepository.Delete(entityDB);
            await _uOW.CommitAsync();

        }

        //public IEnumerable<T> GetAll()
        //{
        //    return _genericRepository.GetAll();
        //}

        //public async Task<T> GetById(int id)
        //{
        //    return (await _genericRepository.GetById(id));
        //}

        //public async Task Update(T entity)
        //{

        //    _genericRepository.Update(entity);
        //    await _uOW.CommitAsync();

        //}

        public async Task Update(TDTO entity)//buraya yanlış geliyor
        {
            var entityDB = _mapper.Map<T>(entity);
            _genericRepository.Update(entityDB);
            await _uOW.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _genericRepository.Where(predicate);
        }



        IEnumerable<TDTO> IGenericManager<T, TDTO>.GetAll()
        {
            var entitiesDB = _genericRepository.GetAll();
            return _mapper.Map<IEnumerable<TDTO>>(entitiesDB);
        }

         async Task<TDTO> IGenericManager<T, TDTO>.GetById(int id)
        {
            var entityDB = await _genericRepository.GetById(id);
            return (_mapper.Map<TDTO>(entityDB));
        }

        public bool Contains(int id)
        {
            return _genericRepository.Contains(id);
        }
    }
}
