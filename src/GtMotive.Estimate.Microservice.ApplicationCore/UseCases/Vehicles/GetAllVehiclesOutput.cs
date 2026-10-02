using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// This is a get all vehicles response output.
    /// </summary>
    public class GetAllVehiclesOutput(IEnumerable<VehicleInfo> vehicles) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the collection of vehicles.
        /// </summary>
        public IEnumerable<VehicleInfo> Vehicles { get; } = vehicles;
    }
}
