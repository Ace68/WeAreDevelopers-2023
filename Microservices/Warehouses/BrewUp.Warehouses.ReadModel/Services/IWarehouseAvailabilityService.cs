using BrewUp.Warehouses.ReadModel.Entities;
using BrewUp.Warehouses.SharedKernel.Dtos;

namespace BrewUp.Warehouses.ReadModel.Services;

public interface IWarehouseAvailabilityService
{
	Task<PagedResult<BeerJson>> GetBeerAvailabilityAsync(CancellationToken cancellationToken);
}