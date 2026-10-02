using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public sealed class ReturnVehicleRequest(Guid rentalId) : IRequest<IWebApiPresenter>
    {
        [Required]
        public Guid RentalId { get; } = rentalId;
    }

    public sealed class ReturnVehicleRequestHandler(ReturnVehicleUseCase useCase, ReturnVehiclePresenter presenter) : IRequestHandler<ReturnVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(ReturnVehicleRequest request, CancellationToken cancellationToken)
        {
            var input = new ReturnVehicleInput(request.RentalId);
            await useCase.Execute(input);
            return presenter;
        }
    }
}
