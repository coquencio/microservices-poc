using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    public class GetVehiclesEndpointTests : InfrastructureTestBase
    {
        public GetVehiclesEndpointTests(GenericInfrastructureTestServerFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task GetVehiclesWithAuthorizationReturnsOkStatusCode()
        {
            // Arrange
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "TestUser")
            };

            // Act
            var response = await Fixture.Server
                .CreateRequest("/api/vehicles")
                .WithIdentity(claims)
                .GetAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
