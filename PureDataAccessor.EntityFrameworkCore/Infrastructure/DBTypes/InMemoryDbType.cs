using Microsoft.EntityFrameworkCore;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes
{
    public class InMemoryDbType : DBType
    {
        private readonly string _dbName;
        public InMemoryDbType(string dbName)
        {
            _dbName = dbName;
        }
        public override void UseDbType(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_dbName);
        }
    }
}
