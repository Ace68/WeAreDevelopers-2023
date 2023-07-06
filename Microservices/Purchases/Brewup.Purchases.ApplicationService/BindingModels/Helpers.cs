using Brewup.Purchases.SharedKernel.DTOs;

namespace Brewup.Purchases.ApplicationService.BindingModels;

public static class Helpers
{
	public static SharedKernel.DTOs.OrderLine ToDto(this OrderLine orderLine)
	{
		return new SharedKernel.DTOs.OrderLine
		{
			BeerId = new SharedKernel.DomainIds.BeerId(orderLine.ProductId),
			BeerName = new BeerName(orderLine.Title),
			Quantity = new SharedKernel.DTOs.Quantity
			{
				Value = orderLine.Quantity.Value,
				UnitOfMeasure = orderLine.Quantity.UnitOfMeasure
			},
			Price = new SharedKernel.DTOs.Price
			{
				Value = orderLine.Price.Value,
				Currency = orderLine.Price.Currency
			}
		};
	}

	public static IEnumerable<SharedKernel.DTOs.OrderLine> ToDto(this IEnumerable<OrderLine> orderLines) => orderLines.Select(ToDto);
}