using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs.Rentals
{
    public class RentVehicleUseCaseFunctionalTests : FunctionalTestBase
    {
        public RentVehicleUseCaseFunctionalTests(CompositionRootTestFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task RentVehicleWithValidVehicleAndPersonCreatesRentalSuccessfully()
        {
            // Arrange
            var vehicleId = Guid.NewGuid();
            var personId = Guid.NewGuid();
            var input = new RentVehicleInput(vehicleId, personId);
            var testOutputPort = new TestRentVehicleOutputPort();

            // Act - Execute use case with test output port
            var useCase = new RentVehicleUseCase(
                new TestRentalRepository(),
                new TestVehicleRepository(vehicleId),
                testOutputPort);

            await useCase.Execute(input);

            // Assert
            Assert.NotNull(testOutputPort.StandardHandleOutput);
            Assert.Equal(vehicleId, testOutputPort.StandardHandleOutput.VehicleId);
            Assert.Equal(personId, testOutputPort.StandardHandleOutput.PersonId);
            Assert.NotEqual(Guid.Empty, testOutputPort.StandardHandleOutput.RentalId);
        }

        [Fact]
        public async Task RentVehicleWithNonExistentVehicleReturnsNotFound()
        {
            // Arrange
            var vehicleId = Guid.NewGuid();
            var personId = Guid.NewGuid();
            var input = new RentVehicleInput(vehicleId, personId);
            var testOutputPort = new TestRentVehicleOutputPort();

            // Act - Execute use case with test output port
            var useCase = new RentVehicleUseCase(
                new TestRentalRepository(),
                new TestVehicleRepository(null),  // No vehicle
                testOutputPort);

            await useCase.Execute(input);

            // Assert
            Assert.True(testOutputPort.NotFoundHandleCalled);
            Assert.Null(testOutputPort.StandardHandleOutput);
        }

        private sealed class TestRentVehicleOutputPort : IRentVehicleOutputPort
        {
            public RentVehicleOutput StandardHandleOutput { get; private set; }
            public bool NotFoundHandleCalled { get; private set; }
            public bool PersonAlreadyHasActiveRentalCalled { get; private set; }

            public void StandardHandle(RentVehicleOutput response)
            {
                StandardHandleOutput = response;
            }

            public void NotFoundHandle(string message)
            {
                NotFoundHandleCalled = true;
            }

            public void PersonAlreadyHasActiveRental()
            {
                PersonAlreadyHasActiveRentalCalled = true;
            }
        }

        private sealed class TestVehicleRepository : IVehicleRepository
        {
            private readonly Guid? _vehicleId;

            public TestVehicleRepository(Guid? vehicleId = null)
            {
                _vehicleId = vehicleId;
            }

            public async Task<Vehicle> GetByIdAsync(Guid vehicleId)
            {
                return _vehicleId.HasValue && vehicleId == _vehicleId.Value
                    ? await Task.FromResult(new Vehicle { VehicleId = vehicleId })
                    : await Task.FromResult<Vehicle>(null);
            }

            public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
            {
                return await Task.FromResult<IEnumerable<Vehicle>>([]);
            }

            public async Task<Vehicle> GetByModelNameAsync(string modelName)
            {
                return await Task.FromResult<Vehicle>(null);
            }

            public async Task<Vehicle> CreateVehicleAsync(string modelName, DateTime manufacturiedDate)
            {
                return await Task.FromResult<Vehicle>(null);
            }
        }

        private sealed class TestRentalRepository : IRentalRepository
        {
            public async Task AddRental(Rental rental)
            {
                await Task.CompletedTask;
            }

            public async Task<Rental> CreateRentalAsync(Guid vehicleId, Guid personId)
            {
                return await Task.FromResult(new Rental
                {
                    Id = Guid.NewGuid(),
                    VehicleId = vehicleId,
                    PersonId = personId,
                    RentalDate = DateTime.UtcNow
                });
            }

            public async Task<Rental> GetRentalByPersonIdAsync(Guid personId)
            {
                return await Task.FromResult<Rental>(null);
            }

            public async Task<Rental> GetRentalByIdAsync(Guid rentalId)
            {
                return await Task.FromResult<Rental>(null);
            }

            public async Task<bool> SetReturnedDateAsync(Guid rentalId, DateTime returnedDate)
            {
                return await Task.FromResult(true);
            }
        }
    }
}
