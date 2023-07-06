using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.EventHandlers;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructure.RabbitMq.Events;

public sealed class BeerLoadedInStockConsumer : DomainEventsConsumerBase<BeerLoadedInStock>
{
	protected override IEnumerable<IDomainEventHandlerAsync<BeerLoadedInStock>> HandlersAsync { get; }

	public BeerLoadedInStockConsumer(IBeerService beerService, IMufloneConnectionFactory connectionFactory,
		ILoggerFactory loggerFactory) : base(connectionFactory, loggerFactory)
	{
		HandlersAsync = new List<IDomainEventHandlerAsync<BeerLoadedInStock>>
		{
			new BeerLoadedInStockEventHandler(loggerFactory, beerService)
		};
	}
}