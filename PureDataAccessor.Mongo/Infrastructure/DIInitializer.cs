using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PureDataAccessor.Mongo.Context;
using PureDataAccessor.Mongo.UnitOfWork;

namespace PureDataAccessor.Mongo.Infrastructure
{
    public static class DIInitializer
    {
        public static void AddPDA(this IServiceCollection services, PDAMongoConfig config)
        {
            services.AddSingleton(config);
            InitContext(services);
            services.AddScoped<IPDAMongoUnitOfWork, PDAMongoUnitOfWork>();
        }


        public static void InitContext(IServiceCollection services)
        {
            services.AddSingleton<MongoDBContext>();
        }
    }
}
