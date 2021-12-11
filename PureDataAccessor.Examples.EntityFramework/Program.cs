using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PureDataAccessor.EntityFrameworkCore.UnitOfWork;
using PureDataAccessor.Examples.EntityFrameworkCore.Infrastructure;

namespace PureDataAccessor.Examples.EntityFrameworkCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var unitOfWork = services.GetRequiredService<IPDAEFUnitOfWork>();
                unitOfWork.ReCreateDB();
                //unitOfWork.DeleteDB();
                //unitOfWork.Migrate();
                ServiceInitializer.SeedData(unitOfWork);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}