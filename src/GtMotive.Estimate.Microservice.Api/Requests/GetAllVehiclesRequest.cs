using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public sealed class GetAllVehiclesRequest : IRequest<IWebApiPresenter>
    {
    }

    public sealed class GetAllVehiclesRequestHandler(GetAllVehiclesUseCase useCase, GetAllVehiclesPresenter presenter) : IRequestHandler<GetAllVehiclesRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(GetAllVehiclesRequest request, CancellationToken cancellationToken)
        {
            var input = new GetAllVehiclesInput();
            await useCase.Execute(input);
            return presenter;
        }
    }
}
