using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// This is an add vehicle request input.
    /// </summary>
    public class AddVehicleInput(string modelName, DateTime manufacturiedDate) : IUseCaseInput
    {
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
