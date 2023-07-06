using Brewup.Purchases.Messages.Events;
using Brewup.Purchases.ReadModel.Services;
using Brewup.Purchases.SharedKernel.DomainIds;
using Microsoft.Extensions.Logging;

namespace Brewup.Purchases.ReadModel.EventHandlers;

public sealed class PurchaseOrderCreatedEventHandler : DomainEventHandlerBase<PurchaseOrderCreated>
{
	private readonly IPurchaseOrderService _purchaseOrderService;

	public PurchaseOrderCreatedEventHandler(ILoggerFactory loggerFactory, IPurchaseOrderService purchaseOrderService) :
		base(loggerFactory)
	{
		_purchaseOrderService = purchaseOrderService;
	}

	public override async Task HandleAsync(PurchaseOrderCreated @event, CancellationToken cancellationToken = default)
	{
		await _purchaseOrderService.CreatePurchaseOrder(new PurchaseOrderId(@event.AggregateId.Value), @event.Date, @event.Lines, @event.SupplierId);
	}
}