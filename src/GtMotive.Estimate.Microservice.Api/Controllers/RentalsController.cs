using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [ExcludeFromCodeCoverage]
    public class RentalsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RentVehicle([FromBody][Required] RentVehicleRequest request)
        {
            var response = await mediator.Send(request);
            return response.ActionResult;
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnVehicle([FromBody][Required] ReturnVehicleRequest request)
        {
            var response = await mediator.Send(request);
            return response.ActionResult;
        }
    }
}
