using System;
using System.Linq;
using System.Linq.Expressions;

namespace PureDataAccessor.EntityFrameworkCore.Repository
{
    public interface IPDAMongoRepository<TEntity>
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
        TEntity GetById(object Id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(object Id);
        void Delete(TEntity entity);
    }
}