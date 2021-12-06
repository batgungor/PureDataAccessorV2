using Microsoft.EntityFrameworkCore;
using PureDataAccessor.Core;
using PureDataAccessor.Core.Repository;
using PureDataAccessor.Core.UnitOfWork;
using PureDataAccessor.EntityFrameworkCore.Context;
using PureDataAccessor.EntityFrameworkCore.Infrastructure;
using PureDataAccessor.EntityFrameworkCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PureDataAccessor.EntityFrameworkCore.UnitOfWork
{
    public class PDAEFUnitOfWork : IPDAUnitOfWork
    {
        private bool _isDisposed = false;
        private readonly PDAEFContext _context;
        private readonly PDAEFContextOptions _contextOptions;
        private Dictionary<Type, object> _repositories;
        public PDAEFUnitOfWork(PDAEFContext context, PDAEFContextOptions contextOptions)
        {
            _context = context;
            _contextOptions = contextOptions;
            _repositories = new Dictionary<Type, object>();
        }

        public IPDARepository<TEntity> GetRepository<TEntity>() where TEntity : PDABaseEntity
        {
            IPDARepository<TEntity> repository;
            var repositoryAlreadyCreated = _repositories.ContainsKey(typeof(TEntity));
            if (repositoryAlreadyCreated)
            {
                repository = (IPDARepository<TEntity>)_repositories.Where(q => q.Key == typeof(TEntity)).FirstOrDefault().Value;
            }
            else
            {
                repository = _contextOptions.DBType.GetRepository<TEntity>(_context);
                _repositories.Add(typeof(TEntity), repository);
            }
            return repository;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Attention! This method will delete your DB completelly and re-create!!!! You will lost your all data!!!!
        /// </summary>
        public void ReCreateDB()
        {
            if (_contextOptions.EnableAdminDeveloperMode)
            {
                _context.Database.EnsureDeleted(); //delete DB
                _context.Database.Migrate(); //auto migration
            }
        }

        /// <summary>
        /// Attention! This method will delete your DB completelly!!!! You will lost your all data!!!!
        /// </summary>
        public void DeleteDB()
        {
            if (_contextOptions.EnableAdminDeveloperMode)
            {
                _context.Database.EnsureDeleted(); //delete DB
            }
        }

        public void Migrate()
        {
            if (_contextOptions.EnableAdminDeveloperMode)
            {
                _context.Database.Migrate(); //auto migration
            }
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