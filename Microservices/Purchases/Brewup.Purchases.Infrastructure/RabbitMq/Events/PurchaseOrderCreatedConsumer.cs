using Brewup.Purchases.Messages.Events;
using Brewup.Purchases.ReadModel.EventHandlers;
using Brewup.Purchases.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace Brewup.Purchases.Infrastructure.RabbitMq.Events;

public sealed class PurchaseOrderCreatedConsumer : DomainEventsConsumerBase<PurchaseOrderCreated>
{
	protected override IEnumerable<IDomainEventHandlerAsync<PurchaseOrderCreated>> HandlersAsync { get; }

	public PurchaseOrderCreatedConsumer(IPurchaseOrderService purchaseOrderService, IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory)
		: base(connectionFactory, loggerFactory)
	{
		HandlersAsync = new List<IDomainEventHandlerAsync<PurchaseOrderCreated>>
		{
			new PurchaseOrderCreatedEventHandler(loggerFactory, purchaseOrderService),
			new PurchaseOrderCreatedSendEmailEventHandler(loggerFactory)
		};
	}
}