using PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes;
using System.Reflection;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure
{
    public class PDAEFContextOptions
    {
        public PDAEFContextOptions()
        {
            DBType = new InMemoryDbType()
            {
                DbName = "PDAInMemoryDb"
            };
            EnableAdminDeveloperMode = false;
            EnableLazyLoading = false;
        }
        public IDBType DBType { get; set; }
        public Assembly EntityAssembly { get; set; }
        public bool EnableLazyLoading { get; set; }
        public bool EnableAdminDeveloperMode { get; set; }
    }
}
