using GtMotive.Estimate.Microservice.Api.Response;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public class RentVehiclePresenter : IWebApiPresenter, IRentVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void PersonAlreadyHasActiveRental()
        {
            ActionResult = new BadRequestObjectResult("The person already has an active rental.");
        }

        public void StandardHandle(RentVehicleOutput response)
        {
            ActionResult = new OkObjectResult(new RentVehicleResponse
            {
                RentalId = response.RentalId,
                RentalDate = response.RentedAt
            });
        }
    }
}
