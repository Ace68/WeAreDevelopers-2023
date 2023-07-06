using BrewUp.Sagas.Warehouses.Messages.Events;
using BrewUp.Sagas.Warehouses.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Saga;
using Muflone.Saga.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Saga.Consumers;

namespace BrewUp.Sagas.Infrastructures.RabbitMq.Events;

public sealed class BeerCreatedSagaConsumer : SagaEventConsumerBase<BeerCreated>
{
	public BeerCreatedSagaConsumer(IServiceBus serviceBus, ISagaRepository sagaRepository, IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory)
		: base(connectionFactory, loggerFactory)
	{
		HandlerAsync = new BeersReceivedSaga(serviceBus, sagaRepository, loggerFactory);
	}

	protected override ISagaEventHandlerAsync<BeerCreated> HandlerAsync { get; }
}