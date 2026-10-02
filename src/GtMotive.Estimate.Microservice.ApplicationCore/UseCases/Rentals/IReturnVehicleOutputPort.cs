namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Return Vehicle Output Port.
    /// </summary>
    public interface IReturnVehicleOutputPort : IOutputPortNotFound, IOutputPortStandard<ReturnVehicleOutput>
    {
        /// <summary>
        /// Method to inform that the rental has already been returned.
        /// </summary>
        void RentalAlreadyReturned();
    }
}
