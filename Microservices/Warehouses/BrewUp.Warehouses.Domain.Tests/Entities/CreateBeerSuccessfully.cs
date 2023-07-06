using BrewUp.Warehouses.Messages.Commands;
using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.SharedKernel.DomainIds;
using BrewUp.Warehouses.Domain.CommandHandlers;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace BrewUp.Warehouses.Domain.Tests.Entities;

public sealed class CreateBeerSuccessfully : CommandSpecification<CreateBeer>
{
	public readonly BeerId _beerId = new(Guid.NewGuid());
	public readonly BeerName _beerName = new("Muflone IPA");

	public readonly Guid _correlationId = Guid.NewGuid();

	protected override IEnumerable<DomainEvent> Given()
	{
		yield break;
	}

	protected override CreateBeer When()
	{
		return new CreateBeer(_beerId, _correlationId, _beerName);
	}

	protected override ICommandHandlerAsync<CreateBeer> OnHandler()
	{
		return new CreateBeerCommandHandler(Repository, new NullLoggerFactory());
	}

	protected override IEnumerable<DomainEvent> Expect()
	{
		yield return new BeerCreated(_beerId, _correlationId, _beerName);
	}
}