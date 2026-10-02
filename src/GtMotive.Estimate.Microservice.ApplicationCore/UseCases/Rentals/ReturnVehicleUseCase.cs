using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    public class ReturnVehicleUseCase(IRentalRepository rentalRepository, IReturnVehicleOutputPort outputPort) : IUseCase<ReturnVehicleInput>
    {
        public async Task Execute(ReturnVehicleInput input)
        {
            var rental = await rentalRepository.GetRentalByIdAsync(input.RentalId);
            if (rental == null)
            {
                outputPort.NotFoundHandle("Rental not found");
                return;
            }

            if (rental.ReturnedDate.HasValue)
            {
                outputPort.RentalAlreadyReturned();
                return;
            }

            var returnedDate = DateTime.UtcNow;
            await rentalRepository.SetReturnedDateAsync(input.RentalId, returnedDate);

            var returnOutput = new ReturnVehicleOutput(rental.Id, returnedDate);
            outputPort.StandardHandle(returnOutput);
        }
    }
}
