using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// This is just a rental request output.
    /// </summary>
    public class RentVehicleOutput(Guid rentalId, Guid vehicleId, Guid personId, DateTime rentedAt) : IUseCaseOutput
    {
        /// <summary>
        /// Gets rental Identifier.
        /// </summary>
        public Guid RentalId { get; } = rentalId;

        /// <summary>
        /// Gets vehicle Identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets person Identifier.
        /// </summary>
        public Guid PersonId { get; } = personId;

        /// <summary>
        /// Gets rented date.
        /// </summary>
        public DateTime RentedAt { get; } = rentedAt;
    }
}
