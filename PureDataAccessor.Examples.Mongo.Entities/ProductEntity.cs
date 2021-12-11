using MongoDB.Bson.Serialization.Attributes;
using PureDataAccessor.Mongo;
using PureDataAccessor.Mongo.Infrastructure;

namespace PureDataAccessor.Examples.Mongo.Entities
{
    [MongoTable("Products")]
    public class ProductEntity : PDABaseMongoEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
