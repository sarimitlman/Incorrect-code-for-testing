using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Dal.Models
{
    public class Prompts
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("userId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId UserId { get; set; }

        [BsonElement("prompt")]
        public string Prompt { get; set; }

        [BindNever]
        [BsonElement("response")]
        public string Response { get; set; }

        [BsonElement("createdAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("subCategoryId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SubCategoryId { get; set; }
    }
}
