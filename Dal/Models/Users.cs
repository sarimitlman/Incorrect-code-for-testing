using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }
    }
}

