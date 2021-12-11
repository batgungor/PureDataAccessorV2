using PureDataAccessor.Core;
using PureDataAccessor.EntityFrameworkCore.Repository;

namespace PureDataAccessor.EntityFrameworkCore.UnitOfWork
{
    public interface IPDAEFUnitOfWork
    {

        /// <summary>
        /// Attention! This method will delete your DB completelly!!!! You will lost your all data!!!!
        /// </summary>
        void DeleteDB();

        /// <summary>
        /// Attention! This method will delete your DB completelly and re-create!!!! You will lost your all data!!!!
        /// </summary>
        void ReCreateDB();

        void Migrate();
        int SaveChanges();
        IPDARepository<TEntity> GetRepository<TEntity>() where TEntity : PDAEFBaseEntity;
    }
}