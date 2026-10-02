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
    public class VehiclesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var response = await mediator.Send(new GetAllVehiclesRequest());
            return response.ActionResult;
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody][Required] AddVehicleRequest request)
        {
            var response = await mediator.Send(request);
            return response.ActionResult;
        }
    }
}
