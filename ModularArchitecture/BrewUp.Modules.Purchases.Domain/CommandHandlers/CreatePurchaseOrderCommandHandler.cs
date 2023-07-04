using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Shared.Abstracts;
using MediatR;

namespace BrewUp.Modules.Purchases.Domain.CommandHandlers;

public sealed class CreatePurchaseOrderCommandHandler : CommandHandlerBase<CreatePurchaseOrder>
{
	private readonly IMediator _serviceBus;

	public CreatePurchaseOrderCommandHandler(IMediator serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public override async Task Handle(CreatePurchaseOrder request, CancellationToken cancellationToken)
	{
		// Do something with the request
		var purchaseOrderCreated = new PurchaseOrderCreated(request.PurchaseOrderId, request.SupplierId, request.Date, request.Lines);
		await _serviceBus.Publish(purchaseOrderCreated, cancellationToken);
	}
}