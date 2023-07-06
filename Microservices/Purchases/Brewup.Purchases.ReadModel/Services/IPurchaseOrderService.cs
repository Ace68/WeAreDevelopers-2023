using Brewup.Purchases.SharedKernel.DomainIds;
using Brewup.Purchases.SharedKernel.DTOs;

namespace Brewup.Purchases.ReadModel.Services;

public interface IPurchaseOrderService
{
	Task CreatePurchaseOrder(PurchaseOrderId purchaseOrderId, DateTime date, IEnumerable<OrderLine> lines, SupplierId supplierId);
	Task UpdateStatusToComplete(PurchaseOrderId purchaseOrderId);
}