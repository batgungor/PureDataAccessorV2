using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes
{
    public class MySQLDBType : DBType
    {
        private readonly string _connectionString;
        private readonly Assembly _migrationAssembly;
        public MySQLDBType(string connectionString, Assembly migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }
        public override void UseDbType(DbContextOptionsBuilder optionsBuilder)
        {
            var version = ServerVersion.AutoDetect(_connectionString);
            optionsBuilder.UseMySql(_connectionString, version, b => b.MigrationsAssembly(_migrationAssembly.FullName));
        }
    }
}
