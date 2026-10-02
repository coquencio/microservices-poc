using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.UseCases.Rentals
{
    public class RentVehicleUseCaseTests
    {
        private readonly Mock<IRentalRepository> _rentalRepositoryMock;
        private readonly Mock<IVehicleRepository> _vehicleRepositoryMock;
        private readonly Mock<IRentVehicleOutputPort> _outputPortMock;
        private readonly RentVehicleUseCase _useCase;

        public RentVehicleUseCaseTests()
        {
            _rentalRepositoryMock = new Mock<IRentalRepository>();
            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _outputPortMock = new Mock<IRentVehicleOutputPort>();

            _useCase = new RentVehicleUseCase(
                _rentalRepositoryMock.Object,
                _vehicleRepositoryMock.Object,
                _outputPortMock.Object);
        }

        [Fact]
        public async Task ExecuteVehicleNotFoundCallsNotFoundHandle()
        {
            // Arrange
            var vehicleId = Guid.NewGuid();
            var personId = Guid.NewGuid();
            var input = new RentVehicleInput(vehicleId, personId);

            _vehicleRepositoryMock
                .Setup(x => x.GetByIdAsync(vehicleId))
                .ReturnsAsync((Vehicle)null);

            // Act
            await _useCase.Execute(input);

            // Assert
            _outputPortMock.Verify(x => x.NotFoundHandle("Vehicle not found"), Times.Once);
            _outputPortMock.Verify(x => x.StandardHandle(It.IsAny<RentVehicleOutput>()), Times.Never);
            _outputPortMock.Verify(x => x.PersonAlreadyHasActiveRental(), Times.Never);
        }

        [Fact]
        public async Task ExecutePersonAlreadyHasActiveRentalCallsPersonAlreadyHasActiveRental()
        {
            // Arrange
            var vehicleId = Guid.NewGuid();
            var personId = Guid.NewGuid();
            var input = new RentVehicleInput(vehicleId, personId);

            var vehicle = new Vehicle { VehicleId = vehicleId };
            var existingRental = new Rental { Id = Guid.NewGuid(), PersonId = personId, VehicleId = vehicleId };

            _vehicleRepositoryMock
                .Setup(x => x.GetByIdAsync(vehicleId))
                .ReturnsAsync(vehicle);

            _rentalRepositoryMock
                .Setup(x => x.GetRentalByPersonIdAsync(personId))
                .ReturnsAsync(existingRental);

            // Act
            await _useCase.Execute(input);

            // Assert
            _outputPortMock.Verify(x => x.PersonAlreadyHasActiveRental(), Times.Once);
            _outputPortMock.Verify(x => x.StandardHandle(It.IsAny<RentVehicleOutput>()), Times.Never);
            _outputPortMock.Verify(x => x.NotFoundHandle(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task ExecuteSuccessfulRentalCallsStandardHandleWithCorrectOutput()
        {
            // Arrange
            var vehicleId = Guid.NewGuid();
            var personId = Guid.NewGuid();
            var rentalId = Guid.NewGuid();
            var rentalDate = DateTime.UtcNow;
            var input = new RentVehicleInput(vehicleId, personId);

            var vehicle = new Vehicle { VehicleId = vehicleId };
            var createdRental = new Rental
            {
                Id = rentalId,
                VehicleId = vehicleId,
                PersonId = personId,
                RentalDate = rentalDate
            };

            _vehicleRepositoryMock
                .Setup(x => x.GetByIdAsync(vehicleId))
                .ReturnsAsync(vehicle);

            _rentalRepositoryMock
                .Setup(x => x.GetRentalByPersonIdAsync(personId))
                .ReturnsAsync((Rental)null);

            _rentalRepositoryMock
                .Setup(x => x.CreateRentalAsync(vehicleId, personId))
                .ReturnsAsync(createdRental);

            // Act
            await _useCase.Execute(input);

            // Assert
            _outputPortMock.Verify(
                x => x.StandardHandle(It.Is<RentVehicleOutput>(o =>
                    o.RentalId == rentalId &&
                    o.VehicleId == vehicleId &&
                    o.PersonId == personId &&
                    o.RentedAt == rentalDate)),
                Times.Once);

            _outputPortMock.Verify(x => x.NotFoundHandle(It.IsAny<string>()), Times.Never);
            _outputPortMock.Verify(x => x.PersonAlreadyHasActiveRental(), Times.Never);
        }
    }
}
