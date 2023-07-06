using Brewup.Purchases.SharedKernel.DomainIds;
using Brewup.Purchases.SharedKernel.DTOs;
using Muflone.Messages.Events;

namespace Brewup.Purchases.Messages.Events;

public class PurchaseOrderStatusChangedToComplete : DomainEvent
{
	public PurchaseOrderStatusChangedToComplete(PurchaseOrderId aggregateId, IEnumerable<OrderLine> lines) : base(aggregateId)
	{
		Lines = lines;
	}

	public IEnumerable<OrderLine> Lines { get; init; }
}