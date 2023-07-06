using Microsoft.AspNetCore.Http;

namespace BrewUp.Warehouses.ApplicationServices.Endpoints;

public static class WarehouseEndpoints
{
	public static async Task<IResult> HandleGetAvailability(IWarehouseOrchestrator warehouseOrchestrator, CancellationToken cancellationToken)
	{
		var availability = await warehouseOrchestrator.GetBeerAvailabilityAsync(default);

		return Results.Ok(availability);
	}
}