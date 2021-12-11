using Microsoft.EntityFrameworkCore;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes
{
    public abstract class DBType
    {
        public abstract void UseDbType(DbContextOptionsBuilder optionsBuilder);
    }
}
