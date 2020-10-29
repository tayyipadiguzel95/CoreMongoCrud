using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoCRUD.Models
{
    public abstract class MongoBaseModel
    {
        public ObjectId Id { get; set; }

        [BsonElement]
        public bool IsDeleted { get; set; }

        [BsonElement]
        public int CreatedBy { get; set; }

        [BsonElement]
        public DateTime CreatedOn { get; set; }

        [BsonElement]
        public int? UpdatedBy { get; set; }

        [BsonElement]
        public DateTime? UpdatedOn { get; set; }
    }
}
