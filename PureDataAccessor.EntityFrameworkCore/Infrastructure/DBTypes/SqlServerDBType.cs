using Microsoft.EntityFrameworkCore;
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
    }
}
