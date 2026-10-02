using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetByIdAsync(Guid vehicleId);
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetByModelNameAsync(string modelName);
        Task<Vehicle> CreateVehicleAsync(string modelName, DateTime manufacturiedDate);
    }
}
