using Microsoft.AspNetCore.Http;

namespace BrewUp.Warehouses.ApplicationServices.Endpoints;

public static class WarehouseEndpoints
{
	public static async Task<IResult> HandleGetAvailability(IWarehouseFacade warehouseFacade,
		CancellationToken cancellationToken)
	{
		var availability = await warehouseFacade.GetBeerAvailabilityAsync(cancellationToken);

		return Results.Ok(availability);
	}
}