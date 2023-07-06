using BrewUp.Warehouses.ApplicationServices;
using BrewUp.Warehouses.ApplicationServices.Endpoints;

namespace BrewUp.Warehouses.Rest.Modules;

public class WharehouseModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 100;
	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddWarehouseServices();

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		var mapGroup = endpoints.MapGroup("/api/v1/")
			.WithTags("Warehouses");

		mapGroup.MapGet("/", WarehouseEndpoints.HandleGetAvailability)
			.Produces(StatusCodes.Status400BadRequest)
			.Produces(StatusCodes.Status200OK)
			.WithName("GetAvailability");

		return endpoints;
	}
}