using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// This is a rental return request input.
    /// </summary>
    public class ReturnVehicleInput(Guid rentalId) : IUseCaseInput
    {
        /// <summary>
        /// Gets the rental identifier.
        /// </summary>
        public Guid RentalId { get; } = rentalId;
    }
}
