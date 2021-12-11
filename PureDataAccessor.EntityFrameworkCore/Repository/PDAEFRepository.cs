using Microsoft.EntityFrameworkCore;
using PureDataAccessor.Core;
using PureDataAccessor.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PureDataAccessor.EntityFrameworkCore.Repository
{
    public class PDAEFRepository<TEntity> : IPDARepository<TEntity> where TEntity : PDAEFBaseEntity
    {
        private readonly PDAEFContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public PDAEFRepository(PDAEFContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(object Id)
        {
            var entity = GetById(Id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            _dbSet.Remove(entity);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }
            return _dbSet;
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(object Id)
        {
            return _dbSet.Find(Id);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}