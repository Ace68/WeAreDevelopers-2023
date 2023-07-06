using Brewup.Purchases.ReadModel.Entities;
using Brewup.Purchases.SharedKernel.DomainIds;
using Brewup.Purchases.SharedKernel.DTOs;
using Microsoft.Extensions.Logging;

namespace Brewup.Purchases.ReadModel.Services;

public class PurchaseOrderService : ServiceBase, IPurchaseOrderService
{
	public PurchaseOrderService(ILoggerFactory loggerFactory, IPersister persister) : base(loggerFactory, persister)
	{
	}

	public async Task CreatePurchaseOrder(PurchaseOrderId purchaseOrderId, DateTime date, IEnumerable<OrderLine> lines,
		SupplierId supplierId)
	{
		var order = PurchaseOrder.Create(purchaseOrderId, date, lines, supplierId);

		await Persister.Insert(order);
	}

	public async Task UpdateStatusToComplete(PurchaseOrderId purchaseOrderId)
	{
		var order = await Persister.GetBy<PurchaseOrder>(purchaseOrderId.ToString());
		order.Status = Status.Complete;
		await Persister.Update(order);
	}
}