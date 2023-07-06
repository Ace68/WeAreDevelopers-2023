using BrewUp.Warehouses.ApplicationServices.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Warehouses.ApplicationServices;

public static class WarehouseHelper
{
	public static IServiceCollection AddWarehouseServices(this IServiceCollection services)
	{
		services.AddSingleton<ValidationHandler>();

		services.AddFluentValidationAutoValidation();
		services.AddValidatorsFromAssemblyContaining<BeersReceivedValidator>();

		services.AddScoped<IWarehouseOrchestrator, WarehouseOrchestrator>();
	
		return services;
	}
}