using Microsoft.EntityFrameworkCore;
using PureDataAccessor.Core;
using PureDataAccessor.Core.Repository;
using PureDataAccessor.EntityFrameworkCore.Context;
using PureDataAccessor.EntityFrameworkCore.Repository;
using System.Reflection;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes
{
    public class SqlServerDBType : IDBType
    {
        public string ConnectionString { get; set; }
        public Assembly MigrationAssembly { get; set; }
        public void UseDbType(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly(MigrationAssembly.FullName));
        }
        public IPDARepository<TEntity> GetRepository<TEntity>(PDAEFContext context) where TEntity : PDABaseEntity
        {
            var repository = new PDAEFRepository<TEntity>(context);
            return repository;
        }
    }
}
