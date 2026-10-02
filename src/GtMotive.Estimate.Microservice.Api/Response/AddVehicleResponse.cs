using System;

namespace GtMotive.Estimate.Microservice.Api.Response
{
    public class AddVehicleResponse
    {
        public Guid VehicleId { get; set; }

        public string ModelName { get; set; }

        public DateTime ManufacturedDate { get; set; }
    }
}
