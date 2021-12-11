using System;

namespace PureDataAccessor.Mongo.Infrastructure
{
    public class MongoTableAttribute : Attribute
    {
        public readonly string _tableName;
        public MongoTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }
}
