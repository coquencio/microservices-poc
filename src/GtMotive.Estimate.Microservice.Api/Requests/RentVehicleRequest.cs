using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public sealed class RentVehicleRequest(Guid vehicleId, Guid personId) : IRequest<IWebApiPresenter>
    {
        [Required]
        public Guid VehicleId { get; } = vehicleId;

        [Required]
        public Guid PersonId { get; } = personId;
    }

    public sealed class RentVehicleRequestHandler(RentVehicleUseCase useCase, RentVehiclePresenter presenter) : IRequestHandler<RentVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(RentVehicleRequest request, CancellationToken cancellationToken)
        {
            var input = new RentVehicleInput(request.VehicleId, request.PersonId);
            await useCase.Execute(input);
            return presenter;
        }
    }
}
