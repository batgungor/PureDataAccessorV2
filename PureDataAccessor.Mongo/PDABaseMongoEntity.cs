using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PureDataAccessor.Mongo
{
    public class PDABaseMongoEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; } = ObjectId.GenerateNewId().ToString();
    }
}
