using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    public class Vehicle
    {
        public Guid VehicleId { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public string ModelName { get; set; }
    }
}
