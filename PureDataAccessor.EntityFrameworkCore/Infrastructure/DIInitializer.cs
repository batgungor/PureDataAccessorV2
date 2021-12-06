using Microsoft.Extensions.DependencyInjection;
using PureDataAccessor.Core.UnitOfWork;
using PureDataAccessor.EntityFrameworkCore.Context;
using PureDataAccessor.EntityFrameworkCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure
{
    public static class DIInitializer
    {
        public static void AddPDA(this IServiceCollection services, PDAEFContextOptions options)
        {
            services.AddSingleton(options);
            services.AddDbContext<PDAEFContext>();
            services.AddScoped<IPDAUnitOfWork, PDAEFUnitOfWork>();
        }
    }
}
