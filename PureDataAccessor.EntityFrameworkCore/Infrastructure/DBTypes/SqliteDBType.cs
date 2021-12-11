using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes
{
    public class SqliteDBType : DBType
    {
        private readonly string _connectionString;
        private readonly Assembly _migrationAssembly;
        public SqliteDBType(string connectionString, Assembly migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }
        public override void UseDbType(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString, b => b.MigrationsAssembly(_migrationAssembly.FullName));
        }
    }
}
