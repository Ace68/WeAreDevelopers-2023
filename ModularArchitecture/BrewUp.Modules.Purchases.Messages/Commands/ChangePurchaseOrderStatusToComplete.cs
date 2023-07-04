using BrewUp.Shared.Abstracts;
using BrewUp.Shared.DomainIds;

namespace BrewUp.Modules.Purchases.Messages.Commands;

public record ChangePurchaseOrderStatusToComplete(PurchaseOrderId PurchaseOrderId) : Command(PurchaseOrderId);