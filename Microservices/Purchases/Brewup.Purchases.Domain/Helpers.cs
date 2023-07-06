using Brewup.Purchases.SharedKernel.DTOs;

namespace Brewup.Purchases.Domain;

public static class Helpers
{
	public static IEnumerable<OrderLine> ToDtos(this IEnumerable<Entities.OrderLine> lines)
	{
		return lines.Select(x => new OrderLine
		{
			BeerId = x.BeerId,
			BeerName = new BeerName(x.Title),
			Price = new Price { Currency = x.Price.Currency, Value = x.Price.Value },
			Quantity = new Quantity { UnitOfMeasure = x.Quantity.UnitOfMeasure, Value = x.Quantity.Value }
		}).ToList();
	}

	public static IEnumerable<Entities.OrderLine> ToEntities(this IEnumerable<OrderLine> lines)
	{
		return lines.Select(x => new Entities.OrderLine(
			x.BeerId,
			x.BeerName.Value,
			new Entities.Quantity(x.Quantity.Value, x.Quantity.UnitOfMeasure),
			new Entities.Price(x.Price.Value, x.Price.Currency))).ToList();
	}
}