using Muflone.Core;

namespace BrewUp.Sagas.Warehouses.SharedKernel.DomainIds;

public sealed class PurchaseOrderId : DomainId
{
	public PurchaseOrderId(Guid value) : base(value)
	{
	}
}