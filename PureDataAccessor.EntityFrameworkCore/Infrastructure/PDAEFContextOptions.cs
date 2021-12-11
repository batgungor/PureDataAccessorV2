using PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes;
using System.Reflection;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure
{
    public class PDAEFContextOptions
    {
        public PDAEFContextOptions()
        {
            DBType = new InMemoryDbType("PDAInMemoryDb");
            EnableAdminDeveloperMode = false;
            EnableLazyLoading = false;
        }
        public DBType DBType { get; set; }
        public Assembly EntityAssembly { get; set; }
        public bool EnableLazyLoading { get; set; }
        public bool EnableAdminDeveloperMode { get; set; }
    }
}
