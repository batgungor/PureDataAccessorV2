using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PureDataAccessor.EntityFrameworkCore.Infrastructure;
using PureDataAccessor.EntityFrameworkCore.Infrastructure.DBTypes;
using PureDataAccessor.Examples.EntityFrameworkCore.Entities;

namespace PureDataAccessor.Examples.EntityFrameworkCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //var contextOptions = GetInMemoryPDA();
            var contextOptions = GetSqlServerPDA();
            //var contextOptions = GetPostgreSQLPDA();
            //var contextOptions = GetMySQLPDA();
            //var contextOptions = GetSqlitePDA();
            services.AddPDA(contextOptions);
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private PDAEFContextOptions GetSqlServerPDA()
        {
            var connectionString = Configuration.GetConnectionString("ConnStrSqlServer");
            var contextOptions = new PDAEFContextOptions()
            {
                DBType = new SqlServerDBType(connectionString, typeof(Startup).Assembly),
                EntityAssembly = typeof(ProductEntity).Assembly,
                EnableAdminDeveloperMode = true,
                EnableLazyLoading = true
            };
            return contextOptions;
        }

        private PDAEFContextOptions GetInMemoryPDA()
        {
            var contextOptions = new PDAEFContextOptions()
            {
                DBType = new InMemoryDbType("PDAExampleTestDB"),
                EntityAssembly = typeof(ProductEntity).Assembly,
                EnableLazyLoading = true
            };
            return contextOptions;
        }

        private PDAEFContextOptions GetPostgreSQLPDA()
        {
            var connectionString = Configuration.GetConnectionString("ConnStrPostgres");
            var contextOptions = new PDAEFContextOptions()
            {
                DBType = new PostgreSQLDBType(connectionString, typeof(Startup).Assembly),
                EntityAssembly = typeof(ProductEntity).Assembly,
                EnableAdminDeveloperMode = true,
                EnableLazyLoading = true
            };
            return contextOptions;
        }

        private PDAEFContextOptions GetMySQLPDA()
        {
            var connectionString = Configuration.GetConnectionString("ConnStrMysql");
            var contextOptions = new PDAEFContextOptions()
            {
                DBType = new MySQLDBType(connectionString, typeof(Startup).Assembly),
                EntityAssembly = typeof(ProductEntity).Assembly,
                EnableAdminDeveloperMode = true,
                EnableLazyLoading = true
            };
            return contextOptions;
        }

        private PDAEFContextOptions GetSqlitePDA()
        {
            var connectionString = Configuration.GetConnectionString("ConnStrSqlite");
            var contextOptions = new PDAEFContextOptions()
            {
                DBType = new SqliteDBType(connectionString, typeof(Startup).Assembly),
                EntityAssembly = typeof(ProductEntity).Assembly,
                EnableAdminDeveloperMode = true,
                EnableLazyLoading = true
            };
            return contextOptions;
        }
    }
}
