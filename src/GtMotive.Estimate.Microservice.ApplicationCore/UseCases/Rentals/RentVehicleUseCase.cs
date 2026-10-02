using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    public class RentVehicleUseCase(IRentalRepository rentalRepository, IVehicleRepository vehicleRepository, IRentVehicleOutputPort outputPort) : IUseCase<RentVehicleInput>
    {
        public async Task Execute(RentVehicleInput input)
        {
            var vehicle = await vehicleRepository.GetByIdAsync(input.VehicleId);
            if (vehicle == null)
            {
                outputPort.NotFoundHandle("Vehicle not found");
                return;
            }

            var existingRental = await rentalRepository.GetRentalByPersonIdAsync(input.PersonId);
            if (existingRental != null)
            {
                outputPort.PersonAlreadyHasActiveRental();
                return;
            }

            var rental = await rentalRepository.CreateRentalAsync(input.VehicleId, input.PersonId);
            var rentalOutPut = new RentVehicleOutput(rental.Id, rental.VehicleId, rental.PersonId, rental.RentalDate);
            outputPort.StandardHandle(rentalOutPut);
        }
    }
}
