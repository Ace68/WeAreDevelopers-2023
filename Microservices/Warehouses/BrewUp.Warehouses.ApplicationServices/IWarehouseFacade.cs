using BrewUp.Warehouses.ReadModel.Entities;
using BrewUp.Warehouses.SharedKernel.Dtos;

namespace BrewUp.Warehouses.ApplicationServices;

public interface IWarehouseFacade
{
	Task<PagedResult<BeerJson>> GetBeerAvailabilityAsync(CancellationToken cancellationToken);
}