using Microsoft.EntityFrameworkCore;
using PureDataAccessor.Core;
using PureDataAccessor.Core.Repository;
using PureDataAccessor.EntityFrameworkCore.Context;
using PureDataAccessor.EntityFrameworkCore.Repository;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes
{
    public class InMemoryDbType : IDBType
    {
        public string DbName { get; set; }
        public void UseDbType(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(DbName);
        }
        public IPDARepository<TEntity> GetRepository<TEntity>(PDAEFContext context) where TEntity : PDABaseEntity
        {
            var repository = new PDAEFRepository<TEntity>(context);
            return repository;
        }
    }
}
