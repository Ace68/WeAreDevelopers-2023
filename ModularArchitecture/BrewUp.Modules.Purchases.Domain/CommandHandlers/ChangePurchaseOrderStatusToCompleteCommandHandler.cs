using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Shared.Abstracts;
using BrewUp.Shared.DomainIds;
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
		var lines = Enumerable.Empty<OrderLine>();
		lines = lines.Concat(new List<OrderLine>
		{
			new ()
			{
				BeerId = new BeerId(Guid.NewGuid()),
				BeerName = new BeerName("Muflone IPA"),
				Quantity = new Quantity()
				{
					Value = 10,
					UnitOfMeasure = "NR"
				},
				Price = new Price()
				{
					Value = 2.5m,
					Currency = "EUR"
				},
			},
		});
		var purchaseOrderStatusCompleted = new PurchaseOrderStatusChangedToComplete(request.PurchaseOrderId, lines);
		await _serviceBus.Publish(purchaseOrderStatusCompleted, cancellationToken);
	}
}