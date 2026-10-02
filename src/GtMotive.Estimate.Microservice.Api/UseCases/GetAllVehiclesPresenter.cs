using System.Linq;
using GtMotive.Estimate.Microservice.Api.Response;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public class GetAllVehiclesPresenter : IWebApiPresenter, IGetAllVehiclesOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(GetAllVehiclesOutput response)
        {
            var vehicleDtos = response.Vehicles.Select(v => new VehicleDto
            {
                VehicleId = v.VehicleId,
                ManufacturedDate = v.ManufacturedDate,
                ModelName = v.ModelName
            }).ToList();

            ActionResult = new OkObjectResult(new GetAllVehiclesResponse
            {
                Vehicles = vehicleDtos
            });
        }
    }
}
