using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.Api.Response
{
    public class GetAllVehiclesResponse
    {
        public IEnumerable<VehicleDto> Vehicles { get; set; }
    }
}
