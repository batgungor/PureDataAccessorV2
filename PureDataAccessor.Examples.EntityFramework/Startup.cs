using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            var connectionString = Configuration.GetConnectionString("ConnStr");
            var contextOptions = new PDAEFContextOptions()
            {
                DBType = new SqlServerDBType()
                {
                    ConnectionString = connectionString,
                    MigrationAssembly = typeof(Startup).Assembly
                },
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
                DBType = new InMemoryDbType()
                {
                    DbName = "PDAExampleTestDB"
                },
                EntityAssembly = typeof(ProductEntity).Assembly,
                EnableLazyLoading = true
            };
            return contextOptions;
        }
    }
}
