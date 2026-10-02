using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Use case to add a new vehicle.
    /// </summary>
    public class AddVehicleUseCase(IVehicleRepository vehicleRepository, IAddVehicleOutputPort outputPort) : IUseCase<AddVehicleInput>
    {
        /// <summary>
        /// Executes the add vehicle use case.
        /// </summary>
        /// <param name="input">The input for the use case.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Execute(AddVehicleInput input)
        {
            // Check if model name already exists
            var existingVehicle = await vehicleRepository.GetByModelNameAsync(input.ModelName);
            if (existingVehicle != null)
            {
                outputPort.ModelNameAlreadyExists();
                return;
            }

            // Check if manufacture date is not more than 5 years old
            var fiveYearsAgo = DateTime.UtcNow.AddYears(-5);
            if (input.ManufacturedDate < fiveYearsAgo)
            {
                outputPort.ManufactureDateTooOld();
                return;
            }

            // Create the vehicle
            var vehicle = await vehicleRepository.CreateVehicleAsync(input.ModelName, input.ManufacturedDate);

            var output = new AddVehicleOutput(vehicle.VehicleId, vehicle.ModelName, vehicle.ManufacturedDate);
            outputPort.StandardHandle(output);
        }
    }
}
