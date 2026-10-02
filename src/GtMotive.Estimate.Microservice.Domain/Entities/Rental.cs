using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    public class Rental
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public Guid PersonId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
