namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Rental Output Port.
    /// </summary>
    public interface IRentVehicleOutputPort : IOutputPortNotFound, IOutputPortStandard<RentVehicleOutput>
    {
        /// <summary>
        /// Method to inform that the person already has an active rental.
        /// </summary>
        void PersonAlreadyHasActiveRental();
    }
}
