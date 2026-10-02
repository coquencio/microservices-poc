using GtMotive.Estimate.Microservice.Api.Response;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public class ReturnVehiclePresenter : IWebApiPresenter, IReturnVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void RentalAlreadyReturned()
        {
            ActionResult = new BadRequestObjectResult("The rental has already been returned.");
        }

        public void StandardHandle(ReturnVehicleOutput response)
        {
            ActionResult = new OkObjectResult(new ReturnVehicleResponse
            {
                RentalId = response.RentalId,
                ReturnedDate = response.ReturnedDate
            });
        }
    }
}
