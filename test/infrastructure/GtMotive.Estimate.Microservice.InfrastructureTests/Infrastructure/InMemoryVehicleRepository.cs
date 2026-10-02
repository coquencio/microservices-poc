using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    internal sealed class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles = [];
        public Task<Vehicle> GetByIdAsync(Guid vehicleId)
        {
            return Task.FromResult(_vehicles.Find(v => v.VehicleId == vehicleId));
        }

        public Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
#pragma warning disable SA1010
            return Task.FromResult<IEnumerable<Vehicle>>([.. _vehicles]);
#pragma warning restore SA1010
        }

        public Task<Vehicle> GetByModelNameAsync(string modelName)
        {
            return Task.FromResult(_vehicles.Find(v => v.ModelName == modelName));
        }

        public Task<Vehicle> CreateVehicleAsync(string modelName, DateTime manufacturiedDate)
        {
            var vehicle = new Vehicle
            {
                VehicleId = Guid.NewGuid(),
                ModelName = modelName,
                ManufacturedDate = manufacturiedDate
            };
            _vehicles.Add(vehicle);
            return Task.FromResult(vehicle);
        }
    }
}
