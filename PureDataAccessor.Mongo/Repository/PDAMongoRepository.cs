using MongoDB.Driver;
using PureDataAccessor.Mongo;
using PureDataAccessor.Mongo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PureDataAccessor.EntityFrameworkCore.Repository
{
    public class PDAMongoRepository<TEntity> : IPDAMongoRepository<TEntity> where TEntity : PDABaseMongoEntity
    {
        private readonly IMongoCollection<TEntity> _collection;
        private readonly MongoDBContext _context;
        public PDAMongoRepository(MongoDBContext context)
        {
            _collection = context.GetCollection<TEntity>();
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.AddCommand(async () => await _collection.InsertOneAsync(entity));
        }

        public void Delete(object id)
        {
            _context.AddCommand(async () => await _collection.FindOneAndDeleteAsync(q => q.Id == id.ToString()));
        }

        public void Delete(TEntity entity)
        {
            _context.AddCommand(async () => await _collection.FindOneAndDeleteAsync(q => q.Id == entity.Id));
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate);
        }

        public List<TEntity> GetAll()
        {
            return Get().ToList();
        }

        public TEntity GetById(object id)
        {
            return _collection.Find(q => q.Id == id.ToString()).FirstOrDefault();
        }

        public void Update(TEntity entity)
        {
            _context.AddCommand(async () => await _collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity));
        }
    }
}