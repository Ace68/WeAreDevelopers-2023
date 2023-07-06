using BrewUp.Sagas.Warehouses.Messages.Commands;
using BrewUp.Sagas.Warehouses.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Saga;
using Muflone.Saga.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Models;
using Muflone.Transport.RabbitMQ.Saga.Consumers;

namespace BrewUp.Sagas.Infrastructures.RabbitMq.Commands;

public sealed class StartBeersReceivedSagaConsumer : SagaStartedByConsumerBase<StartBeersReceivedSaga>
{
	protected override ISagaStartedByAsync<StartBeersReceivedSaga> HandlerAsync { get; }

	public StartBeersReceivedSagaConsumer(IServiceBus serviceBus, ISagaRepository sagaRepository, IMufloneConnectionFactory connectionFactory,

		ILoggerFactory loggerFactory) : base(new ConsumerConfiguration(), connectionFactory, loggerFactory)
	{
		HandlerAsync = new BeersReceivedSaga(serviceBus, sagaRepository, loggerFactory);
	}
}