using BrewUp.Sagas.Warehouses.SharedKernel.DomainIds;
using BrewUp.Sagas.Warehouses.SharedKernel.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Sagas.Warehouses.Messages.Events;

public sealed class BeersReceived : IntegrationEvent
{
	public readonly PurchaseOrderId PurchaseOrderId;
	public readonly IEnumerable<OrderLine> OrderLines;

	public BeersReceived(PurchaseOrderId aggregateId, Guid correlationId, IEnumerable<OrderLine> orderLines) : base(aggregateId, correlationId)
	{
		PurchaseOrderId = aggregateId;
		OrderLines = orderLines;
	}
}