using Microsoft.Extensions.DependencyInjection;
using PureDataAccessor.EntityFrameworkCore.Context;
using PureDataAccessor.EntityFrameworkCore.UnitOfWork;

namespace PureDataAccessor.EntityFrameworkCore.Infrastructure
{
    public static class DIInitializer
    {
        public static void AddPDA(this IServiceCollection services, PDAEFContextOptions options)
        {
            services.AddSingleton(options);
            services.AddDbContext<PDAEFContext>();
            services.AddScoped<IPDAEFUnitOfWork, PDAEFUnitOfWork>();
        }
    }
}
