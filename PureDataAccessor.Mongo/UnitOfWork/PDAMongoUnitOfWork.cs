using MongoDB.Driver;
using PureDataAccessor.EntityFrameworkCore.Repository;
using PureDataAccessor.Mongo.Context;
using PureDataAccessor.Mongo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PureDataAccessor.Mongo.UnitOfWork
{
    public class PDAMongoUnitOfWork : IPDAMongoUnitOfWork
    {
        private bool _isDisposed = false;
        private readonly MongoDBContext _context;
        private Dictionary<Type, object> _repositories;
        public PDAMongoUnitOfWork(MongoDBContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IPDAMongoRepository<TEntity> GetRepository<TEntity>() where TEntity : PDABaseMongoEntity
        {
            IPDAMongoRepository<TEntity> repository;
            var repositoryAlreadyCreated = _repositories.ContainsKey(typeof(TEntity));
            if (repositoryAlreadyCreated)
            {
                repository = (IPDAMongoRepository<TEntity>)_repositories.Where(q => q.Key == typeof(TEntity)).FirstOrDefault().Value;
            }
            else
            {
                repository = new PDAMongoRepository<TEntity>(_context);
                _repositories.Add(typeof(TEntity), repository);
            }
            return repository;
        }

        public int SaveChanges()
        {
            try
            {
                _context.RunCommands();
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public void ReCreateDB()
        {
        }

        public void DeleteDB()
        {
        }

        public void Migrate()
        {
        }

        public virtual void Dispose(bool disposing)
        {
            if (this._isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}