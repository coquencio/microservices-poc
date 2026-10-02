using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public sealed class AddVehicleRequest(string modelName, DateTime manufacturiedDate) : IRequest<IWebApiPresenter>
    {
        [Required]
        public string ModelName { get; } = modelName;

        [Required]
        public DateTime ManufacturedDate { get; } = manufacturiedDate;
    }

    public sealed class AddVehicleRequestHandler(AddVehicleUseCase useCase, AddVehiclePresenter presenter) : IRequestHandler<AddVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(AddVehicleRequest request, CancellationToken cancellationToken)
        {
            var input = new AddVehicleInput(request.ModelName, request.ManufacturedDate);
            await useCase.Execute(input);
            return presenter;
        }
    }
}
