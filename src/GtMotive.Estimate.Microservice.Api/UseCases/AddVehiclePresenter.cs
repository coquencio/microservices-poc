using GtMotive.Estimate.Microservice.Api.Response;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public class AddVehiclePresenter : IWebApiPresenter, IAddVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void ModelNameAlreadyExists()
        {
            ActionResult = new ConflictObjectResult("A vehicle with this model name already exists.");
        }

        public void ManufactureDateTooOld()
        {
            ActionResult = new BadRequestObjectResult("The manufacture date cannot be more than 5 years old.");
        }

        public void StandardHandle(AddVehicleOutput response)
        {
            ActionResult = new CreatedAtActionResult("GetVehicles", "Vehicles", null, new AddVehicleResponse
            {
                VehicleId = response.VehicleId,
                ModelName = response.ModelName,
                ManufacturedDate = response.ManufacturedDate
            });
        }
    }
}
