using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes
{
    public class OracleDBType : DBType
    {
        private readonly string _connectionString;
        private readonly Assembly _migrationAssembly;
        public OracleDBType(string connectionString, Assembly migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }
        public override void UseDbType(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(_connectionString, b => b.MigrationsAssembly(_migrationAssembly.FullName));
        }
    }
}
