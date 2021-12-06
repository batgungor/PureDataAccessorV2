using PureDataAccessor.Core.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PureDataAccessor.Core.UnitOfWork
{
    public interface IPDAUnitOfWork : IDisposable
    {
        IPDARepository<TEntity> GetRepository<TEntity>() where TEntity : PDABaseEntity;

        /// <summary>
        /// Attention! This method will delete your DB completelly and re-create!!!! You will lost your all data!!!!
        /// Only available for EF/SQL server
        /// </summary>
        void ReCreateDB();

        /// <summary>
        /// Attention! This method will delete your DB completelly!!!! You will lost your all data!!!!
        /// Only available for EF/SQL server
        /// </summary>
        void DeleteDB();

        void Migrate();
        int SaveChanges();
    }
}