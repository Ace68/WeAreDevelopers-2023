using BrewUp.Warehouses.Messages.Commands;
using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.SharedKernel.Dtos;
using BrewUp.Warehouses.Domain.CommandHandlers;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace BrewUp.Warehouses.Domain.Tests.Entities;

public sealed class LoadBeerInStockSuccessfully : CommandSpecification<LoadBeerInStock>
{
	private readonly BeerId _beerId = new(Guid.NewGuid());
	private readonly BeerName _beerName = new("Muflone IPA");
	private readonly Stock _stock = new(10);
	private readonly Price _price = new(10, "EUR");
	private readonly PurchaseOrderId _purchaseOrderId = new(Guid.NewGuid());

	private readonly Guid _correlationId = Guid.NewGuid();

	protected override IEnumerable<DomainEvent> Given()
	{
		yield return new BeerCreated(_beerId, _correlationId, _beerName);
	}

	protected override LoadBeerInStock When()
	{
		return new LoadBeerInStock(_beerId, _correlationId, _stock, _price, _purchaseOrderId);
	}

	protected override ICommandHandlerAsync<LoadBeerInStock> OnHandler()
	{
		return new LoadBeerInStockCommandHandler(Repository, new NullLoggerFactory());
	}

	protected override IEnumerable<DomainEvent> Expect()
	{
		yield return new BeerLoadedInStock(_beerId, _correlationId, _stock, _price, _purchaseOrderId);
	}
}