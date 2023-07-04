using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Shared.Abstracts;
using BrewUp.Shared.Events;
using MediatR;

namespace BrewUp.Modules.Purchases.ReadModel.EventHandlers;

public class PurchaseOrderStatusChangedToCompleteEventHandler : DomainEventHandlerBase<PurchaseOrderStatusChangedToComplete>
{
	private readonly IMediator _serviceBus;

	public PurchaseOrderStatusChangedToCompleteEventHandler(IMediator serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public override async Task Handle(PurchaseOrderStatusChangedToComplete notification, CancellationToken cancellationToken)
	{
		var beersReceived = new BeersReceived(notification.PurchaseOrderId, notification.Lines);
		await _serviceBus.Publish(beersReceived, cancellationToken);
	}
}