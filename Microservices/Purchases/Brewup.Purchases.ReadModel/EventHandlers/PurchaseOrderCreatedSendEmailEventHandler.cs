using Brewup.Purchases.Messages.Events;
using Microsoft.Extensions.Logging;

namespace Brewup.Purchases.ReadModel.EventHandlers;

public sealed class PurchaseOrderCreatedSendEmailEventHandler : DomainEventHandlerBase<PurchaseOrderCreated>
{
	public PurchaseOrderCreatedSendEmailEventHandler(ILoggerFactory loggerFactory) :
		base(loggerFactory)
	{
	}

	public override Task HandleAsync(PurchaseOrderCreated @event, CancellationToken cancellationToken = default)
	{
		//Send order via email to our supplier....

		return Task.CompletedTask;
	}
}