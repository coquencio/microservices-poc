using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    /// <summary>
    /// Extensions to register vehicle-related dependencies.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class VehiclesExtensions
    {
        /// <summary>
        /// Adds vehicle use case dependencies to the service collection.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddVehicleDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
