using BrewUp.Warehouses.ReadModel.Entities;
using BrewUp.Warehouses.ReadModel.Services;
using BrewUp.Warehouses.SharedKernel.Dtos;

namespace BrewUp.Warehouses.ApplicationServices;

internal class WarehouseFacade : IWarehouseFacade
{
	private readonly IWarehouseAvailabilityService _warehouseAvailabilityService;

	public WarehouseFacade(IWarehouseAvailabilityService warehouseAvailabilityService)
	{
		_warehouseAvailabilityService = warehouseAvailabilityService;
	}

	public Task<PagedResult<BeerJson>> GetBeerAvailabilityAsync(CancellationToken cancellationToken) =>
		_warehouseAvailabilityService.GetBeerAvailabilityAsync(default);
}