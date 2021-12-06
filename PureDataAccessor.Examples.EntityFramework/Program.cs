using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PureDataAccessor.Core.UnitOfWork;
using PureDataAccessor.EntityFrameworkCore.Context;
using PureDataAccessor.Examples.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                var unitOfWork = services.GetRequiredService<IPDAUnitOfWork>();
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