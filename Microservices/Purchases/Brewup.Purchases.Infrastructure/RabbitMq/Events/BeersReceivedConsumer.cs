using Brewup.Purchases.Messages.Events;
using Brewup.Purchases.ReadModel.EventHandlers;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace Brewup.Purchases.Infrastructure.RabbitMq.Events;

public sealed class BeersReceivedConsumer : IntegrationEventsConsumerBase<BeersReceived>
{
	protected override IEnumerable<IIntegrationEventHandlerAsync<BeersReceived>> HandlersAsync { get; }

	public BeersReceivedConsumer(IMufloneConnectionFactory mufloneConnectionFactory, ILoggerFactory loggerFactory) : base(mufloneConnectionFactory, loggerFactory)
	{
		HandlersAsync = new List<IIntegrationEventHandlerAsync<BeersReceived>>
		{
			new BeersReceivedEventHandler(loggerFactory)
		};
	}
}