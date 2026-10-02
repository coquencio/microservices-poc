using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// This is a rental return response output.
    /// </summary>
    public class ReturnVehicleOutput(Guid rentalId, DateTime returnedDate) : IUseCaseOutput
    {
        /// <summary>
        /// Gets rental identifier.
        /// </summary>
        public Guid RentalId { get; } = rentalId;

        /// <summary>
        /// Gets returned date.
        /// </summary>
        public DateTime ReturnedDate { get; } = returnedDate;
    }
}
