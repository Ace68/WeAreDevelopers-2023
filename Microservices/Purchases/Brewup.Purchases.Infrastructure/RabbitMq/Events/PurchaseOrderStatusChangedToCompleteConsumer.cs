using Brewup.Purchases.Messages.Events;
using Brewup.Purchases.ReadModel.EventHandlers;
using Brewup.Purchases.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace Brewup.Purchases.Infrastructure.RabbitMq.Events;

public sealed class
	PurchaseOrderStatusChangedToCompleteConsumer : DomainEventsConsumerBase<PurchaseOrderStatusChangedToComplete>
{
	protected override IEnumerable<IDomainEventHandlerAsync<PurchaseOrderStatusChangedToComplete>> HandlersAsync { get; }
	
	public PurchaseOrderStatusChangedToCompleteConsumer(IEventBus eventBus, IPurchaseOrderService purchaseOrderService, IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory) 
		: base(connectionFactory, loggerFactory)
	{
		HandlersAsync = new List<IDomainEventHandlerAsync<PurchaseOrderStatusChangedToComplete>>
		{
			new PurchaseOrderStatusChangedToCompleteEventHandler(eventBus, loggerFactory, purchaseOrderService)
		};
	}
}