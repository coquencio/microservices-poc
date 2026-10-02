using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    /// <summary>
    /// Extensions to register rental-related dependencies.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class RentalsExtensions
    {
        /// <summary>
        /// Adds rental presenter and interface mappings to the service collection.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddRentalDependencies(this IServiceCollection services)
        {
            // Register the presenter with scoped lifetime
            services.AddScoped<RentVehiclePresenter>();

            // Register the interface implementations
            services.AddScoped<IRentVehicleOutputPort>(sp => sp.GetRequiredService<RentVehiclePresenter>());
            services.AddScoped<IWebApiPresenter>(sp => sp.GetRequiredService<RentVehiclePresenter>());

            // Register the MediatR request handler
            services.AddScoped<IRequestHandler<RentVehicleRequest, IWebApiPresenter>, RentVehicleRequestHandler>();

            return services;
        }
    }
}
