using Microsoft.EntityFrameworkCore;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes
{
    public class InMemoryDbType : IDBType
    {
        public string DbName { get; set; }
        public void UseDbType(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(DbName);
        }
    }
}
