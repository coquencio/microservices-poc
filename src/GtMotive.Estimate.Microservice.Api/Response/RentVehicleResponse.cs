using System;

namespace GtMotive.Estimate.Microservice.Api.Response
{
    public class RentVehicleResponse
    {
        public Guid RentalId { get; set; }

        public DateTime RentalDate { get; set; }
    }
}
