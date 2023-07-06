using Brewup.Purchases.SharedKernel.DomainIds;
using Muflone.Messages.Commands;

namespace Brewup.Purchases.Messages.Commands;

public class ChangePurchaseOrderStatusToComplete : Command
{
	public ChangePurchaseOrderStatusToComplete(PurchaseOrderId aggregateId) :
		base(aggregateId)
	{
	}
}