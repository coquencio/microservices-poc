using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Entities
{
    [BsonIgnoreExtraElements]
    public class VehicleEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid VehicleId { get; set; }

        [BsonElement("manufacturerDate")]
        public DateTime ManufacturedDate { get; set; }

        [BsonElement("modelName")]
        public string ModelName { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
