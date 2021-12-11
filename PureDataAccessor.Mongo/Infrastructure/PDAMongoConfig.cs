using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureDataAccessor.Mongo.Infrastructure
{
    public class PDAMongoConfig
    {
        public MongoClientSettings MongoClientSettings { get; set; }
        public string DBName { get; set; }
    }
}
