using Microsoft.EntityFrameworkCore;
using PureDataAccessor.Core;
using PureDataAccessor.Core.Repository;
using PureDataAccessor.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes
{
    public interface IDBType
    {
        void UseDbType(DbContextOptionsBuilder optionsBuilder);
        public IPDARepository<TEntity> GetRepository<TEntity>(PDAEFContext context) where TEntity : PDABaseEntity;
    }
}
