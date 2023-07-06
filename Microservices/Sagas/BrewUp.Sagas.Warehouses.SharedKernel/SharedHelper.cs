using BrewUp.Sagas.Warehouses.SharedKernel.DomainIds;
using BrewUp.Sagas.Warehouses.SharedKernel.Dtos;

namespace BrewUp.Sagas.Warehouses.SharedKernel;

public static class SharedExtensions
{
	public static IEnumerable<OrderLine> ToEntity(this IEnumerable<OrderLineJson> json)
	{
		return json.Select(x => new OrderLine(new BeerId(new Guid(x.BeerId)), new BeerName(x.BeerName), x.Quantity, x.Price));
	}
}