using System;

namespace GtMotive.Estimate.Microservice.Api.Response
{
    public class VehicleDto
    {
        public Guid VehicleId { get; set; }

        public DateTime ManufacturedDate { get; set; }

        public string ModelName { get; set; }
    }
}
