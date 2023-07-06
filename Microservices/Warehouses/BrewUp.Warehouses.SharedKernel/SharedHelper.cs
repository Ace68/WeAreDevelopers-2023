using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;

namespace BrewUp.Warehouses.SharedKernel;

public static class SharedExtensions
{
	public static IEnumerable<OrderLine> ToEntity(this IEnumerable<OrderLineJson> json)
	{
		return json.Select(x => new OrderLine(new BeerId(new Guid(x.BeerId)), new BeerName(x.BeerName), x.Quantity, x.Price));
	}
}