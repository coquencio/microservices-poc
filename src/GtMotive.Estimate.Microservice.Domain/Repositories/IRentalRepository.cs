using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    public interface IRentalRepository
    {
        Task AddRental(Rental rental);
        Task<Rental> GetRentalByPersonIdAsync(Guid personId);
        Task<Rental> CreateRentalAsync(Guid vehicleId, Guid personId);
        Task<Rental> GetRentalByIdAsync(Guid rentalId);
        Task<bool> SetReturnedDateAsync(Guid rentalId, DateTime returnedDate);
    }
}
