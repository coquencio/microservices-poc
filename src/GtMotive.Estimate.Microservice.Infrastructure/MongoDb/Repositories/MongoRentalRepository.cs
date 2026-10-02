using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories
{
    public class MongoRentalRepository : IRentalRepository
    {
        private readonly IMongoCollection<RentalEntity> _rentalCollection;

        public MongoRentalRepository(MongoService mongoService, IOptions<MongoDbSettings> options)
        {
            var database = mongoService.MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);
            _rentalCollection = database.GetCollection<RentalEntity>("rentals");
        }

        public async Task AddRental(Rental rental)
        {
            var rentalEntity = MapDomainToEntity(rental);
            await _rentalCollection.InsertOneAsync(rentalEntity);
        }

        public async Task<Rental> GetRentalByPersonIdAsync(Guid personId)
        {
            var filter = Builders<RentalEntity>.Filter.Eq(r => r.PersonId, personId);
            var rentalEntity = await _rentalCollection.Find(filter).FirstOrDefaultAsync();

            return rentalEntity != null ? MapEntityToDomain(rentalEntity) : null;
        }

        public async Task<Rental> CreateRentalAsync(Guid vehicleId, Guid personId)
        {
            var rentalEntity = new RentalEntity
            {
                Id = Guid.NewGuid(),
                VehicleId = vehicleId,
                PersonId = personId,
                RentalDate = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _rentalCollection.InsertOneAsync(rentalEntity);

            return MapEntityToDomain(rentalEntity);
        }

        public async Task<Rental> GetRentalByIdAsync(Guid rentalId)
        {
            var filter = Builders<RentalEntity>.Filter.Eq(r => r.Id, rentalId);
            var rentalEntity = await _rentalCollection.Find(filter).FirstOrDefaultAsync();

            return rentalEntity != null ? MapEntityToDomain(rentalEntity) : null;
        }

        public async Task<bool> SetReturnedDateAsync(Guid rentalId, DateTime returnedDate)
        {
            var filter = Builders<RentalEntity>.Filter.Eq(r => r.Id, rentalId);
            var update = Builders<RentalEntity>.Update
                .Set(r => r.ReturnedDate, returnedDate)
                .Set(r => r.UpdatedAt, DateTime.UtcNow);

            var result = await _rentalCollection.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }

        private static Rental MapEntityToDomain(RentalEntity entity)
        {
            return new Rental
            {
                Id = entity.Id,
                VehicleId = entity.VehicleId,
                PersonId = entity.PersonId,
                RentalDate = entity.RentalDate,
                ReturnedDate = entity.ReturnedDate
            };
        }

        private static RentalEntity MapDomainToEntity(Rental domain)
        {
            return new RentalEntity
            {
                Id = domain.Id,
                VehicleId = domain.VehicleId,
                PersonId = domain.PersonId,
                RentalDate = domain.RentalDate,
                ReturnedDate = domain.ReturnedDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
