using System;

namespace GtMotive.Estimate.Microservice.Api.Response
{
    public class ReturnVehicleResponse
    {
        public Guid RentalId { get; set; }

        public DateTime ReturnedDate { get; set; }
    }
}
