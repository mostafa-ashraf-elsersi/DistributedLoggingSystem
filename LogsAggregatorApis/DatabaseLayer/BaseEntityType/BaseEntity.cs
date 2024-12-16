using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LogsAggregatorApis.DatabaseLayer.BaseEntityType
{
    public class BaseEntity<T>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public T? Id { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; }
    }
}
