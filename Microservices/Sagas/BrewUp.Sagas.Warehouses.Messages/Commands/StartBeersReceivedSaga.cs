using BrewUp.Sagas.Warehouses.SharedKernel.DomainIds;
using BrewUp.Sagas.Warehouses.SharedKernel.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Sagas.Warehouses.Messages.Commands;

public sealed class StartBeersReceivedSaga : Command
{
	public readonly PurchaseOrderId PurchaseOrderId;

	public readonly IEnumerable<OrderLine> OrderLines;

	public StartBeersReceivedSaga(PurchaseOrderId aggregateId, IEnumerable<OrderLine> orderLines)
		: base(aggregateId)
	{
		PurchaseOrderId = aggregateId;
		OrderLines = orderLines;
	}
}