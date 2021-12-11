using MongoDB.Driver;
using PureDataAccessor.Mongo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PureDataAccessor.Mongo.Context
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _db;
        private readonly List<Func<Task>> FunctionList;

        public MongoDBContext(PDAMongoConfig config)
        {
            var mongoClient = new MongoClient(config.MongoClientSettings);
            _db = mongoClient.GetDatabase(config.DBName);
            FunctionList = new List<Func<Task>>();
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            Type type = typeof(TEntity);
            var attributes = Attribute.GetCustomAttributes(type);
            var tableNameAttribute = (MongoTableAttribute)attributes.Where(q => ((Type)q.TypeId).Name == "MongoTableAttribute").First();
            var entityName = tableNameAttribute._tableName;
            return _db.GetCollection<TEntity>(entityName);
        }
        public Task AddCommand(Func<Task> func)
        {
            FunctionList.Add(func);
            return Task.CompletedTask;
        }

        public void RunCommands()
        {
            foreach (var func in FunctionList)
            {
                func();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
