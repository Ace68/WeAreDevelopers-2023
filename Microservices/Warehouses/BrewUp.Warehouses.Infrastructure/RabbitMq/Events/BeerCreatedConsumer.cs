using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.EventHandlers;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructure.RabbitMq.Events;

public sealed class BeerCreatedConsumer : DomainEventsConsumerBase<BeerCreated>
{
	protected override IEnumerable<IDomainEventHandlerAsync<BeerCreated>> HandlersAsync { get; }

	public BeerCreatedConsumer(IBeerService beerService, IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory)
		: base(connectionFactory, loggerFactory)
	{
		HandlersAsync = new List<IDomainEventHandlerAsync<BeerCreated>>
		{
			new BeerCreatedEventHandler(loggerFactory, beerService)
		};
	}
}