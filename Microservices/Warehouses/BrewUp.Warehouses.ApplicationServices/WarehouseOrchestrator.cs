using BrewUp.Warehouses.ReadModel.Entities;
using BrewUp.Warehouses.ReadModel.Services;
using BrewUp.Warehouses.SharedKernel.Dtos;

namespace BrewUp.Warehouses.ApplicationServices;

internal class WarehouseOrchestrator : IWarehouseOrchestrator
{
	private readonly IWarehouseAvailabilityService _warehouseAvailabilityService;

	public WarehouseOrchestrator(IWarehouseAvailabilityService warehouseAvailabilityService)
	{
		_warehouseAvailabilityService = warehouseAvailabilityService;
	}

	public Task<PagedResult<BeerJson>> GetBeerAvailabilityAsync(CancellationToken cancellationToken) =>
		_warehouseAvailabilityService.GetBeerAvailabilityAsync(default);
}