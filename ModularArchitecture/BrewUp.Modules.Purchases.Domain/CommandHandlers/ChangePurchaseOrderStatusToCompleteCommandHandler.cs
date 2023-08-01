﻿using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Shared.Abstracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using MediatR;

namespace BrewUp.Modules.Purchases.Domain.CommandHandlers;

public class ChangePurchaseOrderStatusToCompleteCommandHandler : CommandHandlerBase<ChangePurchaseOrderStatusToComplete>
{
	private readonly IPublisher _serviceBus;

	public ChangePurchaseOrderStatusToCompleteCommandHandler(IPublisher serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public override async Task Handle(ChangePurchaseOrderStatusToComplete command, CancellationToken cancellationToken)
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
		var purchaseOrderStatusCompleted = new PurchaseOrderStatusChangedToComplete(command.PurchaseOrderId, lines);
		await _serviceBus.Publish(purchaseOrderStatusCompleted, cancellationToken);
	}
}