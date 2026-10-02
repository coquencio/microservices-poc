using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// This is an add vehicle response output.
    /// </summary>
    public class AddVehicleOutput(Guid vehicleId, string modelName, DateTime manufacturiedDate) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the model name.
        /// </summary>
        public string ModelName { get; } = modelName;

        /// <summary>
        /// Gets the manufactured date.
        /// </summary>
        public DateTime ManufacturedDate { get; } = manufacturiedDate;
    }
}
