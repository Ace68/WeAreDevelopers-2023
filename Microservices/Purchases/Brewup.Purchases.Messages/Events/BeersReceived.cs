using Brewup.Purchases.SharedKernel.DomainIds;
using Brewup.Purchases.SharedKernel.DTOs;
using Muflone.Messages.Events;

namespace Brewup.Purchases.Messages.Events;

public sealed class BeersReceived : IntegrationEvent
{
	public readonly PurchaseOrderId BuyOrderId;
	public readonly IEnumerable<OrderLine> OrderLines;

	public BeersReceived(PurchaseOrderId aggregateId, Guid correlationId, IEnumerable<OrderLine> orderLines) : base(aggregateId, correlationId)
	{
		BuyOrderId = aggregateId;
		OrderLines = orderLines;
	}
}