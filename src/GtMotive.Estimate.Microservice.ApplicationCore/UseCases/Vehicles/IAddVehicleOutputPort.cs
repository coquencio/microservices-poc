namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Add Vehicle Output Port.
    /// </summary>
    public interface IAddVehicleOutputPort : IOutputPortStandard<AddVehicleOutput>
    {
        /// <summary>
        /// Method to inform that a vehicle with the same model name already exists.
        /// </summary>
        void ModelNameAlreadyExists();

        /// <summary>
        /// Method to inform that the manufacture date is older than 5 years.
        /// </summary>
        void ManufactureDateTooOld();
    }
}
