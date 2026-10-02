using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Vehicle information data transfer object.
    /// </summary>
    public class VehicleInfo(Guid vehicleId, DateTime manufacturiedDate, string modelName)
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the manufactured date.
        /// </summary>
        public DateTime ManufacturedDate { get; } = manufacturiedDate;

        /// <summary>
        /// Gets the model name.
        /// </summary>
        public string ModelName { get; } = modelName;
    }
}
