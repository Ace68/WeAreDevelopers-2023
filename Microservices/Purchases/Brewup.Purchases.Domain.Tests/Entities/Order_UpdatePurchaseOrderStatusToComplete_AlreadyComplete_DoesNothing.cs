using Brewup.Purchases.Domain.CommandHandlers;
using Brewup.Purchases.Messages.Commands;
using Brewup.Purchases.Messages.Events;
using Brewup.Purchases.SharedKernel.DomainIds;
using Brewup.Purchases.SharedKernel.DTOs;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace Brewup.Purchases.Domain.Tests.Entities;

public class Order_UpdatePurchaseOrderStatusToComplete_AlreadyComplete_DoesNothing : CommandSpecification<ChangePurchaseOrderStatusToComplete>
{
	private readonly PurchaseOrderId _purchaseOrderId;
	private readonly SupplierId _supplierId;
	private readonly DateTime _date;
	private readonly IEnumerable<OrderLine> _lines;

	public Order_UpdatePurchaseOrderStatusToComplete_AlreadyComplete_DoesNothing()
	{
		_purchaseOrderId = new PurchaseOrderId(Guid.NewGuid());
		_supplierId = new SupplierId(Guid.NewGuid());
		_date = DateTime.Today;

		_lines = Enumerable.Empty<OrderLine>();
		_lines = _lines.Concat(new List<OrderLine>
		{
			new()
			{
				BeerId = new BeerId(Guid.NewGuid()),
				BeerName = new BeerName("Product 1"),
				Quantity = new Quantity { UnitOfMeasure = "N.", Value = 1 },
				Price = new Price { Currency = "EUR", Value = 1 }
			},
			new()
			{
				BeerId = new BeerId(Guid.NewGuid()),
				BeerName = new BeerName("Product 2"),
				Quantity = new Quantity { UnitOfMeasure = "N.", Value = 2 },
				Price = new Price { Currency = "EUR", Value = 2 }
			}
		});
	}

	protected override IEnumerable<DomainEvent> Given()
	{
		yield return new PurchaseOrderCreated(_purchaseOrderId, _supplierId, _date, _lines);
		yield return new PurchaseOrderStatusChangedToComplete(_purchaseOrderId, _lines);
	}

	protected override ChangePurchaseOrderStatusToComplete When()
	{
		return new ChangePurchaseOrderStatusToComplete(_purchaseOrderId);
	}

	protected override ICommandHandlerAsync<ChangePurchaseOrderStatusToComplete> OnHandler()
	{
		return new ChangePurchaseOrderStatusToCompleteHandlerAsync(Repository, new NullLoggerFactory());
	}

	protected override IEnumerable<DomainEvent> Expect()
	{
		yield break;
	}
}