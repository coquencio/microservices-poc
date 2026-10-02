using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// This is just a rental request input.
    /// </summary>
    public class RentVehicleInput(Guid vehicleId, Guid personId) : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the person renting identifier.
        /// </summary>
        public Guid PersonId { get; } = personId;
    }
}
