using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService
    {
        public MongoService(IOptions<MongoDbSettings> options)
        {
            RegisterBsonClasses();
            MongoClient = new MongoClient(options.Value.ConnectionString);
        }

        public MongoClient MongoClient { get; }

        private static void RegisterBsonClasses()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(RentalEntity)))
            {
                BsonClassMap.RegisterClassMap<RentalEntity>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(VehicleEntity)))
            {
                BsonClassMap.RegisterClassMap<VehicleEntity>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
