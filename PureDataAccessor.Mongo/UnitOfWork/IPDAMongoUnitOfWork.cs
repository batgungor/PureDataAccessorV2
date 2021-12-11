using PureDataAccessor.EntityFrameworkCore.Repository;

namespace PureDataAccessor.Mongo.UnitOfWork
{
    public interface IPDAMongoUnitOfWork
    {
        IPDAMongoRepository<TEntity> GetRepository<TEntity>() where TEntity : PDABaseMongoEntity;

        int SaveChanges();
    }
}