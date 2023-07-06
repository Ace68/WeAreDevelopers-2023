using Muflone.Core;

namespace Brewup.Purchases.SharedKernel.DomainIds;

public class PurchaseOrderId : DomainId
{
	public PurchaseOrderId(Guid value) : base(value)
	{
	}
}