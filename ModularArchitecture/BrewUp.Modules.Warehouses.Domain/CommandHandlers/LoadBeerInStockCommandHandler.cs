using BrewUp.Shared.Abstracts;
using BrewUp.Shared.Commands;
using BrewUp.Shared.Events;
using MediatR;

namespace BrewUp.Modules.Warehouses.Domain.CommandHandlers;

public class LoadBeerInStockCommandHandler : CommandHandlerBase<LoadBeerInStock>
{
	private readonly IMediator _serviceBus;

	public LoadBeerInStockCommandHandler(IMediator serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public override async Task Handle(LoadBeerInStock request, CancellationToken cancellationToken)
	{
		var beerLoadedInStock = new BeerLoadedInStock(request.BeerId, request.Stock, request.Price, request.PurchaseOrderId);
		await _serviceBus.Publish(beerLoadedInStock, cancellationToken);
	}
}