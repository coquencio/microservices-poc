using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories
{
    public class MongoVehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<VehicleEntity> _vehicleCollection;

        public MongoVehicleRepository(MongoService mongoService, IOptions<MongoDbSettings> options)
        {
            var database = mongoService.MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);
            _vehicleCollection = database.GetCollection<VehicleEntity>("vehicles");
        }

        public async Task<Vehicle> GetByIdAsync(Guid vehicleId)
        {
            var filter = Builders<VehicleEntity>.Filter.Eq(v => v.VehicleId, vehicleId);
            var vehicleEntity = await _vehicleCollection.Find(filter).FirstOrDefaultAsync();

            return vehicleEntity != null ? MapEntityToDomain(vehicleEntity) : null;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            var vehicleEntities = await _vehicleCollection.Find(Builders<VehicleEntity>.Filter.Empty).ToListAsync();

            return vehicleEntities.Select(MapEntityToDomain);
        }

        public async Task<Vehicle> GetByModelNameAsync(string modelName)
        {
            var filter = Builders<VehicleEntity>.Filter.Eq(v => v.ModelName, modelName);
            var vehicleEntity = await _vehicleCollection.Find(filter).FirstOrDefaultAsync();

            return vehicleEntity != null ? MapEntityToDomain(vehicleEntity) : null;
        }

        public async Task<Vehicle> CreateVehicleAsync(string modelName, DateTime manufacturiedDate)
        {
            var vehicleEntity = new VehicleEntity
            {
                VehicleId = Guid.NewGuid(),
                ModelName = modelName,
                ManufacturedDate = manufacturiedDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _vehicleCollection.InsertOneAsync(vehicleEntity);

            return MapEntityToDomain(vehicleEntity);
        }

        private static Vehicle MapEntityToDomain(VehicleEntity entity)
        {
            return new Vehicle
            {
                VehicleId = entity.VehicleId,
                ManufacturedDate = entity.ManufacturedDate,
                ModelName = entity.ModelName
            };
        }
    }
}
