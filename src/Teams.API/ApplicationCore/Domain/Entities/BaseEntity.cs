using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Teams.API.ApplicationCore.Domain.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
