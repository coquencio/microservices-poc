using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Entities
{
    [BsonIgnoreExtraElements]
    public class RentalEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("vehicleId")]
        [BsonRepresentation(BsonType.String)]
        public Guid VehicleId { get; set; }

        [BsonElement("personId")]
        [BsonRepresentation(BsonType.String)]
        public Guid PersonId { get; set; }

        [BsonElement("rentalDate")]
        public DateTime RentalDate { get; set; }

        [BsonElement("returnedDate")]
        [BsonIgnoreIfNull]
        public DateTime? ReturnedDate { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
