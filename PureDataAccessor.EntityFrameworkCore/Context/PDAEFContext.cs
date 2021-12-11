using Microsoft.EntityFrameworkCore;
using PureDataAccessor.Core;
using PureDataAccessor.EntityFrameworkCore.Infrastructure;
using System;
using System.Linq;

namespace PureDataAccessor.EntityFrameworkCore.Context
{
    public class PDAEFContext : DbContext
    {
        private readonly PDAEFContextOptions _dbContextOptions;
        public PDAEFContext(PDAEFContextOptions dbContextOptions) : base()
        {
            ValidateDbContextOptions(dbContextOptions);
            _dbContextOptions = dbContextOptions;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(_dbContextOptions.EnableLazyLoading);
            _dbContextOptions.DBType.UseDbType(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var baseEntityType = typeof(PDAEFBaseEntity);
            var entitiesAssembly = _dbContextOptions.EntityAssembly;
            var entities = entitiesAssembly.GetTypes().Where(q => q.BaseType == baseEntityType).ToList();
            foreach (var entityType in entities)
            {
                UseAsEntity(modelBuilder, entityType);
            }
        }

        private static void UseAsEntity(ModelBuilder modelBuilder, Type type)
        {
            modelBuilder.Entity(type);
        }

        private void ValidateDbContextOptions(PDAEFContextOptions dbContextOptions)
        {
            Exception exception = null;
            if (dbContextOptions == null)
            {
                exception = new Exception("DBContextOptions is not provided!");
            }
            else if (dbContextOptions.EntityAssembly == null)
            {
                exception = new Exception("EntityAssembly is not provided!");
            }

            if (exception != null)
            {
                throw exception;
            }
        }
    }
}