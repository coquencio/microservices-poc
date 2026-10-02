using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Use case to retrieve all vehicles.
    /// </summary>
    public class GetAllVehiclesUseCase(IVehicleRepository vehicleRepository, IGetAllVehiclesOutputPort outputPort) : IUseCase<GetAllVehiclesInput>
    {
        /// <summary>
        /// Executes the get all vehicles use case.
        /// </summary>
        /// <param name="input">The input for the use case.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Execute(GetAllVehiclesInput input)
        {
            var vehicles = await vehicleRepository.GetAllVehiclesAsync();

            var vehicleInfos = vehicles.Select(v => new VehicleInfo(v.VehicleId, v.ManufacturedDate, v.ModelName)).ToList();

            var output = new GetAllVehiclesOutput(vehicleInfos);
            outputPort.StandardHandle(output);
        }
    }
}
