using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;
using Muflone.Core;

namespace BrewUp.Warehouses.Domain.Entities;

public sealed class Beer : AggregateRoot
{
	//private BeerName _beerName;

	private IEnumerable<StockMovement> _movements;

	private Stock _stock;
	private Price _price;

	internal Beer()
	{
	}

	internal static Beer CreateBeer(BeerId beerId, BeerName beerName, Guid correlationId)
	{
		return new Beer(beerId, beerName, correlationId);
	}

	private Beer(BeerId beerId, BeerName beerName, Guid correlationId)
	{
		RaiseEvent(new BeerCreated(beerId, correlationId, beerName));
	}

	private void Apply(BeerCreated @event)
	{
		Id = @event.BeerId;
		//_beerName = @event.BeerName;
		_movements = Enumerable.Empty<StockMovement>();
		_stock = new Stock(0);
		_price = new Price(0, "EUR");
	}

	#region LoadInStock
	internal void LoadBeerInStock(BeerId beerId, Stock stock, Price price, PurchaseOrderId purchaseOrderId,
		Guid correlationId)
	{
		var movement = _movements.FirstOrDefault(m => m.PurchaseOrderId == purchaseOrderId);
		if (movement is not null)
			return;

		RaiseEvent(new BeerLoadedInStock(
			beerId,
			correlationId,
			new Stock(_stock.Value + stock.Value),
			new Price(price.Value, price.Currency),
			purchaseOrderId)
		);
	}

	private void Apply(BeerLoadedInStock @event)
	{
		//_movements = _movements.Append(new StockMovement(@event.PurchaseOrderId, @event.BeerId,	new Stock(@event.Stock.Value - _stock.Value)));
		//_stock = @event.Stock;
		//_price = @event.Price;
	}
	#endregion
}