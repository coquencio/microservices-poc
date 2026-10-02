using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using MediatR;
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
            // Register AddVehicle presenter and handlers
            services.AddScoped<AddVehiclePresenter>();
            services.AddScoped<IAddVehicleOutputPort>(sp => sp.GetRequiredService<AddVehiclePresenter>());
            services.AddScoped<IRequestHandler<AddVehicleRequest, IWebApiPresenter>, AddVehicleRequestHandler>();

            // Register GetAllVehicles presenter and handlers
            services.AddScoped<GetAllVehiclesPresenter>();
            services.AddScoped<IGetAllVehiclesOutputPort>(sp => sp.GetRequiredService<GetAllVehiclesPresenter>());
            services.AddScoped<IRequestHandler<GetAllVehiclesRequest, IWebApiPresenter>, GetAllVehiclesRequestHandler>();

            // Register ReturnVehicle presenter and handlers
            services.AddScoped<ReturnVehiclePresenter>();
            services.AddScoped<IReturnVehicleOutputPort>(sp => sp.GetRequiredService<ReturnVehiclePresenter>());
            services.AddScoped<IRequestHandler<ReturnVehicleRequest, IWebApiPresenter>, ReturnVehicleRequestHandler>();

            return services;
        }
    }
}
