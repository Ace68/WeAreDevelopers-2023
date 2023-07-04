using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Shared.Abstracts;
using BrewUp.Shared.Dtos;
using MediatR;

namespace BrewUp.Modules.Purchases.Domain.CommandHandlers;

public class ChangePurchaseOrderStatusToCompleteCommandHandler : CommandHandlerBase<ChangePurchaseOrderStatusToComplete>
{
	private readonly IMediator _serviceBus;

	public ChangePurchaseOrderStatusToCompleteCommandHandler(IMediator serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public override async Task Handle(ChangePurchaseOrderStatusToComplete request, CancellationToken cancellationToken)
	{
		// Do something
		var purchaseOrderStatusCompleted = new PurchaseOrderStatusChangedToComplete(request.PurchaseOrderId, Enumerable.Empty<OrderLine>());
		await _serviceBus.Publish(purchaseOrderStatusCompleted, cancellationToken);
	}
}